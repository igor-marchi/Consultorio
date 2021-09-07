using CL.Manager.Interfaces.Manager;
using CL.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CL.WebApi.Tests.Controllers
{
    public class ClienteControllerTests
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClienteController> logger;
        private readonly ClienteController clientecontroller;

        public ClienteControllerTests()
        {
            clienteManager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClienteController>>();
            clientecontroller = new ClienteController(clienteManager, logger);
        }

        [Fact]
        public async Task Get_Ok()
        {
            //clienteManager.GetClientesAsync().Returns(new List<ClienteView> { });
            var result = (ObjectResult)await clientecontroller.Get();

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}