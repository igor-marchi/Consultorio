using CL.Core.Domain;
using CL.Data.Context;
using CL.Data.Repository;
using CL.FakeData.ClienteData;
using CL.Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace CL.Repository.Tests.Repository
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository repository;
        private readonly ClContext context;
        private readonly Cliente cliente;

        private ClienteFaker clienteFaker;

        public ClienteRepositoryTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ClContext>();
            optionBuilder.UseInMemoryDatabase("Db_Teste");

            context = new ClContext(optionBuilder.Options);
            repository = new ClienteRepository(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}