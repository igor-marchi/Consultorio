using CL.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace CL.WebAPI.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
              .AddFluentValidation(configs =>
              {
                  configs.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                  configs.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                  configs.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
              });
        }
    }
}