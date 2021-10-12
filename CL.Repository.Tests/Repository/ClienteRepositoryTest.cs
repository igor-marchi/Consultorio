using CL.Core.Domain;
using CL.Data.Context;
using CL.Data.Repository;
using CL.FakeData.ClienteData;
using CL.FakeData.TelefoneData;
using CL.Manager.Interfaces.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CL.Repository.Tests.Repository
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository repository;
        private readonly ClContext context;
        private readonly Cliente cliente;

        private readonly ClienteFaker clienteFaker;

        public ClienteRepositoryTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ClContext>();
            optionBuilder.UseInMemoryDatabase("Db_Teste");

            context = new ClContext(optionBuilder.Options);
            repository = new ClienteRepository(context);

            clienteFaker = new ClienteFaker();
            cliente = clienteFaker.Generate();
        }

        private async Task<List<Cliente>> InsereRegistros()
        {
            var clientes = clienteFaker.Generate(100);

            clientes.ForEach(async cli =>
            {
                cli.Id = 0;
                await context.Cliente.AddAsync(cli);
            });

            await context.SaveChangesAsync();
            return clientes;
        }

        [Fact]
        public async Task GetClientesAsync_ComRetorno()
        {
            var registros = await InsereRegistros();
            var retorno = await repository.GetClientesAsync();

            retorno.Should().HaveCount(registros.Count);
            retorno.First().Endereco.Should().NotBeNull();
            retorno.First().Telefones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            var retorno = await repository.GetClientesAsync();

            retorno.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClienteAsync_Encontrado()
        {
            var registros = await InsereRegistros();
            var primeiroRegistro = registros.First();
            var retorno = await repository.GetClienteAsync(primeiroRegistro.Id);

            retorno.Should().BeEquivalentTo(primeiroRegistro);
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            long numeroQualquer = 1;
            var retorno = await repository.GetClienteAsync(numeroQualquer);

            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            var retorno = await repository.InsertClienteAsync(cliente);
            retorno.Should().BeEquivalentTo(cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            var registros = await InsereRegistros();
            var primeiroRegistro = registros.First();
            var clienteAlterado = clienteFaker.Generate();
            clienteAlterado.Id = primeiroRegistro.Id;

            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            var retorno = await repository.UpdateClienteAsync(cliente);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task UpdateClienteAsync_AdicionarTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());

            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoverTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());

            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoverTodosTelefones()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Clear();

            var retorno = await repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            var registros = await InsereRegistros();
            var primeiroRegisto = registros.First();
            var retorno = await repository.DeleteClienteAsync(primeiroRegisto.Id);

            retorno.Should().BeEquivalentTo(primeiroRegisto);
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            var retorno = await repository.DeleteClienteAsync(cliente.Id);

            retorno.Should().BeNull();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}