using CL.Core.Shared.ModelViews.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Manager
{
    public interface IClienteManager
    {
        Task<ClienteView> DeleteClienteAsync(long id);

        Task<ClienteView> GetClienteAsync(long id);

        Task<IEnumerable<ClienteView>> GetClientesAsync();

        Task<ClienteView> InsertClienteAsync(NovoCliente novoCliente);

        Task<ClienteView> UpdateClienteAsync(AlteraCliente alteraCliente);
    }
}