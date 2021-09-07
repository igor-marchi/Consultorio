using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Cliente;
using CL.Manager.Interfaces.Manager;
using CL.Manager.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClienteView>> GetClientesAsync()
        {
            var clientes = await clienteRepository.GetClientesAsync();

            return mapper.Map<IEnumerable<ClienteView>>(clientes);
        }

        public async Task<ClienteView> GetClienteAsync(long id)
        {
            var cliente = await clienteRepository.GetClienteAsync(id);
            return mapper.Map<ClienteView>(cliente);
        }

        public async Task DeleteClienteAsync(long id)
        {
            await clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<ClienteView> InsertClienteAsync(NovoCliente novoCliente)
        {
            var cliente = mapper.Map<Cliente>(novoCliente);
            cliente = await clienteRepository.InsertClienteAsync(cliente);

            return mapper.Map<ClienteView>(cliente);
        }

        public async Task<ClienteView> UpdateClienteAsync(AlteraCliente alteraCliente)
        {
            var cliente = mapper.Map<Cliente>(alteraCliente);
            cliente = await clienteRepository.UpdateClienteAsync(cliente);

            return mapper.Map<ClienteView>(cliente);
        }
    }
}