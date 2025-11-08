using System.Reflection;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class Swagger
    {
        public static IServiceCollection AddSwaggerUI(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "modular monolotih template",
                    Description = "Allows developer to develop the template",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }

    }
}
