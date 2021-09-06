using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Manager
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