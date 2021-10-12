using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces.Manager;
using CL.Manager.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CL.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddSDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Manager
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRespository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}