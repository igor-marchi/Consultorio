using CL.Core.Shared.ModelViews.Cliente;
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
        private readonly ClienteView cliente;
        private readonly List<ClienteView> listaClienteView;

        public ClienteControllerTests()
        {
            clienteManager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClienteController>>();
            clientecontroller = new ClienteController(clienteManager, logger);

            cliente = new ClienteViewFaker().Generate();
            listaClienteView = new ClienteViewFaker().Generate(10);
        }

        [Fact]
        public async Task Get_Ok()
        {
            var controle = new List<ClienteView>();
            listaClienteView.ForEach(p => controle.Add(p.CloneTipado()));

            clienteManager.GetClientesAsync().Returns(listaClienteView);
            var result = (ObjectResult)await clientecontroller.Get();

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);
        }
    }
}