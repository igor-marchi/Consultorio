using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CL.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddSDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Repository
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}