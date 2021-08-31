using CL.Manager.Validator.Cliente;
using CL.Manager.Validator.Endereco;
using CL.Manager.Validator.Telefone;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Globalization;

namespace CL.WebAPI.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
              .AddFluentValidation(configs =>
              {
                  configs.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                  configs.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                  configs.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                  configs.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                  configs.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
              });
        }
    }
}