using template.Api.Common.Models.Authentication;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class Authentication
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            AddClientOptions<JwtSettings>(services, "JwtSettings");

            services.PostConfigure<JwtSettings>(opt => opt.SecureKey = Environment.GetEnvironmentVariable("symKey")!);
         
            return services;
        }

        private static void AddClientOptions<T>(IServiceCollection services, string serviceRoute) where T : class
        {
            services
                .AddOptions<T>()
                .BindConfiguration(serviceRoute)
                .ValidateDataAnnotations()
                .ValidateOnStart();
        }
    }

}
