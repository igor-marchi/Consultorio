using CL.Core.Shared.ModelViews.Cliente;
using CL.FakeData.ClienteData;
using CL.Manager.Interfaces.Manager;
using CL.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CL.WebApi.Tests.Controllers
{
    public class ClienteControllerTests
    {
        private readonly IClienteManager manager;
        private readonly ILogger<ClienteController> logger;
        private readonly ClienteController controller;
        private readonly ClienteView clienteView;
        private readonly List<ClienteView> listaClienteView;
        private readonly NovoCliente novoCliente;

        public ClienteControllerTests()
        {
            manager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClienteController>>();
            controller = new ClienteController(manager, logger);

            clienteView = new ClienteViewFaker().Generate();
            listaClienteView = new ClienteViewFaker().Generate(10);
            novoCliente = new NovoClienteFaker().Generate();
        }

        [Fact]
        public async Task Get_Ok()
        {
            //Arranje
            var controle = new List<ClienteView>();
            listaClienteView.ForEach(p => controle.Add(p.CloneTipado()));
            manager.GetClientesAsync().Returns(listaClienteView);

            // Act
            var result = (ObjectResult)await controller.Get();

            //Assert
            await manager.Received().GetClientesAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            manager.GetClientesAsync().Returns(new List<ClienteView>());

            var result = (StatusCodeResult)await controller.Get();

            await manager.Received().GetClientesAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            manager.GetClienteAsync(Arg.Any<long>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Get(clienteView.Id);

            await manager.Received().GetClienteAsync(Arg.Any<long>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            manager.GetClienteAsync(Arg.Any<long>()).Returns(new ClienteView());

            var result = (StatusCodeResult)await controller.Get(1);

            await manager.Received().GetClienteAsync(Arg.Any<long>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            manager.InsertClienteAsync(Arg.Any<NovoCliente>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Post(novoCliente);

            await manager.Received().InsertClienteAsync(Arg.Any<NovoCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Put(new AlteraCliente());

            await manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).ReturnsNull();

            var result = (StatusCodeResult)await controller.Put(new AlteraCliente());

            await manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            manager.DeleteClienteAsync(Arg.Any<long>()).Returns(clienteView);

            var result = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteClienteAsync(Arg.Any<long>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete_NotFound()
        {
            manager.DeleteClienteAsync(Arg.Any<long>()).ReturnsNull();

            var result = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteClienteAsync(Arg.Any<long>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}