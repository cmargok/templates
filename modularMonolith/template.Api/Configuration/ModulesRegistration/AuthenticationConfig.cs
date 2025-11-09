using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace template.Api.Configuration.ModulesRegistration
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
        {

          /*  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer =  Environment.GetEnvironmentVariable("JwtSettings:Issuer"),
                        ValidAudience = Environment.GetEnvironmentVariable("JwtSettings:Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtSettings:Key")!))
                    };
                });*/

            return services;

        }
    }

}
