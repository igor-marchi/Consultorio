using CL.Core.Domain;
using CL.Data.Configuratio;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Context
{
    public class ClContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public ClContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}