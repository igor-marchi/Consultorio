using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Usuario;
using CL.Manager.Interfaces.Manager;
using CL.Manager.Interfaces.Repository;
using CL.Manager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public UsuarioManager(IUsuarioRepository usuarioRepository, IMapper mapper, IJwtService jwtService)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task<List<UsuarioView>> GetAllAsync()
        {
            return mapper.Map<List<UsuarioView>>(await usuarioRepository.GetAllAsync());
        }

        public async Task<UsuarioView> GetOneAsync(string login)
        {
            return mapper.Map<UsuarioView>(await usuarioRepository.GetOneAsync(login));
        }

        public async Task<UsuarioView> InsertAsync(NovoUsuario novoUsuario)
        {
            var usuario = mapper.Map<Usuario>(novoUsuario);
            ConverterSenhaEmHash(usuario);
            var usuarioAlterado = await usuarioRepository.InsertAsync(usuario);
            return mapper.Map<UsuarioView>(usuarioAlterado);
        }

        private static void ConverterSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }

        public async Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
        {
            ConverterSenhaEmHash(usuario);
            return mapper.Map<UsuarioView>(await usuarioRepository.UpdateAsync(usuario));
        }

        public async Task<UsuarioLogado> ValidarUsuarioEGerarTokenAsync(Usuario usuario)
        {
            var usuarioConsultado = await usuarioRepository.GetOneAsync(usuario.Login);

            if (usuarioConsultado == null)
                return null;

            if (!await ValidarEAtualizarHashAsync(usuario, usuarioConsultado.Senha))
                return null;

            var usuarioLogado = mapper.Map<UsuarioLogado>(usuarioConsultado);
            usuarioLogado.Token = jwtService.GerarToken(usuarioConsultado);

            return usuarioLogado;
        }

        private async Task<bool> ValidarEAtualizarHashAsync(Usuario usuario, string hash)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUsuarioAsync(usuario);
                    return true;

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}