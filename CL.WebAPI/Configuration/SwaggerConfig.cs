using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CL.WebAPI.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(configs =>
            {
                configs.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Consultório",
                        Version = "v1",
                        Description = "API da aplicação consultório.",
                        Contact = new OpenApiContact
                        {
                            Name = "Igostoso",
                            Email = "igostoso@gmail.com",
                            Url = new Uri("https://github.com/igor-marchi")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                configs.IncludeXmlComments(xmlPath);

                xmlPath = Path.Combine(AppContext.BaseDirectory, "CL.Core.Shared.xml");
                configs.IncludeXmlComments(xmlPath);
            });

            services.AddFluentValidationRulesToSwagger();
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(configs =>
            {
                configs.RoutePrefix = string.Empty;
                configs.SwaggerEndpoint("./swagger/v1/swagger.json", "CL V1");
            });
        }
    }
}