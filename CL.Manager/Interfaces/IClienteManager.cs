using CL.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(long id);

        Task<Cliente> GetClienteAsync(long id);

        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> InsertClienteAsync(Cliente cliente);

        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}