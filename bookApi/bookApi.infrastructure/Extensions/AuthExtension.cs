using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace bookApi.infrastructure.Extensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireRole("Admin");
                });
                options.AddPolicy("ManagerPolicy", policy =>
                {
                    policy.RequireRole("Manager");
                });
                options.AddPolicy("EditorPolicy", policy =>
                {
                    policy.RequireRole("Editor");
                });
            })
           .AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(x =>
           {
               var configValue = configuration.GetValue<string>("Jwt:Key");
               var issuer = configuration.GetValue<string>("Jwt:Issuer");
               var audience = configuration.GetValue<string>("Jwt:Audience");

               var key = Encoding.ASCII.GetBytes(configValue);
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = issuer,
                   ValidAudience = audience,
                   IssuerSigningKey = new SymmetricSecurityKey(key)
               };
           });
            return services;
        }

    }
}
