using System.Text;
using System;
using L2AccountPanel.Infrastructure.Services;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace L2AccountPanel.Infrastructure.Extensions
{
    public static class AddJwtExtension
    {
        public static void AddJwt(this IServiceCollection services, JwtSettings jwtSettings)
        {
            IConfiguration configuration;

           
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var options = jwtSettings;                    
            services.AddSingleton<IJwtHandler, JwtHandler>();
            
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               
            })
                .AddJwtBearer(cfg =>
                {
                    
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key)),
                        ValidIssuer = options.Issuer,
                        ValidAudience = options.Issuer,
                        ValidateLifetime = true
                    };
                });
        }        
    }
}