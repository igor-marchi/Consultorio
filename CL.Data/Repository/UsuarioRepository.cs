using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClContext context;

        public UsuarioRepository(ClContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await context.Usuario
                .Include(p => p.Funcoes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario> GetOneAsync(string login)
        {
            return await context.Usuario
                .Include(x => x.Funcoes)    
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await InsertUsuarioFuncaoAsync(usuario);
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        private async Task InsertUsuarioFuncaoAsync(Usuario usuario)
        {
            var funcoesConsultadas = new List<Funcao>();

            foreach (var funcao in usuario.Funcoes)
            {
                var funcaoConsultada = await context.Funcao.FindAsync(funcao.Id);
                funcoesConsultadas.Add(funcaoConsultada);
            }

            usuario.Funcoes = funcoesConsultadas;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var usuarioConsultado = await GetOneAsync(usuario.Login);

            if (usuarioConsultado == null)
                return null;

            context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await context.SaveChangesAsync();
            return usuarioConsultado;
        }
    }
}