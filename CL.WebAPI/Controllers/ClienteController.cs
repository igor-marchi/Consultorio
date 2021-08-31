using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Core.Shared.ModelViews.Cliente;
using CL.Manager.Interfaces;
using CL.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System;
using System.Threading.Tasks;

namespace CL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClienteController> logger;

        public ClienteController(IClienteManager clienteManager, ILogger<ClienteController> logger)
        {
            this.clienteManager = clienteManager;
            this.logger = logger;
        }

        /// <summary>
        /// Busca todos os cliente consultados na base.
        /// </summary>
        /// <returns>Retorna todos os cliente consultados na base.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var clientes = await clienteManager.GetClientesAsync();

            return Ok(clientes);
        }

        /// <summary>
        /// Busca o cliente consultado pelo id.
        /// </summary>
        /// <param name="id" example="1">Id do cliente.</param>
        /// <returns>Retorna o cliente consultado pelo id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            var cliente = await clienteManager.GetClienteAsync(id);

            return Ok(cliente);
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="novoCliente"></param>
        /// <returns>Retorna o cliente inserido.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] NovoCliente novoCliente)
        {
            logger.LogInformation($"Objeto recebido {@novoCliente}", novoCliente);

            Cliente clienteCriado;

            using (Operation.Time("Tempo de adição de um novo cliente."))
            {
                logger.LogInformation("Feita request para inserção de um novo cliente");
                clienteCriado = await clienteManager.InsertClienteAsync(novoCliente);
            };

            return CreatedAtAction(nameof(Get), new { id = clienteCriado.Id }, clienteCriado);
        }

        /// <summary>
        /// Altera o cliente informado.
        /// </summary>
        /// <param name="alteraCliente"></param>
        /// <returns>Retorna o cliente alterado.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] AlteraCliente alteraCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alteraCliente);

            if (clienteAtualizado == null)
                return NotFound();

            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Deleta um cliente.
        /// </summary>
        /// <param name="id" example="1">Id do cliente</param>
        /// <remarks>Ao deletar um cliente o mesmo será excluído da base de dados</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}