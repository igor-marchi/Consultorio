using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(long id);

        Task<Cliente> GetClienteAsync(long id);

        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);

        Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente);
    }
}