using CL.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();

        Task<Usuario> GetOneAsync(string login);

        Task<Usuario> InsertAsync(Usuario usuario);

        Task<Usuario> UpdateAsync(Usuario usuario);
    }
}