using CL.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CL.WebAPI.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoClienteMappingProfile),
                typeof(AlteraClienteMappingProfile),
                typeof(UsuarioMappingProfile)
            );
        }
    }
}