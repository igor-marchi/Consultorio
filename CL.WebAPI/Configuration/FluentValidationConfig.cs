using CL.Manager.Validator.Cliente;
using CL.Manager.Validator.Endereco;
using CL.Manager.Validator.Medico;
using CL.Manager.Validator.Telefone;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace CL.WebAPI.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(configs =>
                {
                    configs.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    configs.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    configs.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                    configs.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                    configs.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
                    configs.RegisterValidatorsFromAssemblyContaining<AlteraMedicoValidator>();
                    configs.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}