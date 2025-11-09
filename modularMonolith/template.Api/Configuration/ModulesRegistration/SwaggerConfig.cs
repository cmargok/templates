using Microsoft.OpenApi.Models;
using System.Reflection;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerUI(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                var openApiInfo = new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Modular Monolith Template",
                    Description = "Allows developer to develop the template",
                    Contact = new OpenApiContact()
                    {
                        Name = "Just valid for Cmargok Systems",
                    }
                };

                options.SwaggerDoc("v1", openApiInfo);
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }

    }
}
