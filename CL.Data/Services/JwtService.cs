using CL.Core.Domain;
using CL.Manager.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CL.Data.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = configuration.GetSection("Jwt:Secret").Value;
            //var audience = configuration.GetSection("Jwt:Audience").Value;
            //var issuer = configuration.GetSection("Jwt:Issuer").Value;
            var expires = configuration.GetSection("Jwt:Expires").Value;
            var chaveASCII = Encoding.ASCII.GetBytes(chave);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login)
            };

            claims.AddRange(usuario.Funcoes.Select(x => new Claim(ClaimTypes.Role, x.Descricao)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Audience = audience,
                //Issuer = issuer,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expires)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveASCII), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}