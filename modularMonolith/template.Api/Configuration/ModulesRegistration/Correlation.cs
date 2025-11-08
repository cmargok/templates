using template.Api.Configuration.Handlers.Contracts;
using template.Api.Configuration.Handlers.Implementations;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class Correlation
    {
        public static IServiceCollection AddTelemetry(this IServiceCollection services)
        {
            services.AddScoped<ICorrelationIdHandler, CorrelationIdHandler>();
            return services;
        }
    }
}
