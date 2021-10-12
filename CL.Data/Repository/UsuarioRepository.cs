using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
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
            return await context.Usuario.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetOneAsync(string login)
        {
            return await context.Usuario.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
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