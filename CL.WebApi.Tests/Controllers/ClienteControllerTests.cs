using CL.Core.Domain;
using CL.FakeData.ClienteData;
using CL.Manager.Interfaces.Manager;
using CL.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CL.WebApi.Tests.Controllers
{
    public class ClienteControllerTests
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClienteController> logger;
        private readonly ClienteController clientecontroller;
        private readonly Cliente cliente;
        private readonly List<Cliente> lstCliente;

        public ClienteControllerTests()
        {
            clienteManager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClienteController>>();
            clientecontroller = new ClienteController(clienteManager, logger);

            cliente = new ClienteViewFaker().Generate();
            lstCliente = new ClienteViewFaker().Generate(10);
        }

        [Fact]
        public async Task Get_Ok()
        {
            clienteManager.GetClientesAsync().Returns(lstCliente);
            var result = (ObjectResult)await clientecontroller.Get();

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(lstCliente);
        }
    }
}