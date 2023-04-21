using System.Text;
using ChargeManagement.Application.Common.Interfaces.Authentication;
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Application.Common.Interfaces.Services;
using ChargeManagement.Infrastructure.Authentication;
using ChargeManagement.Infrastructure.Persistence;
using ChargeManagement.Infrastructure.Persistence.Repositories;
using ChargeManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChargeManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDbContext<ChargeManagementDbContext>(options =>
                  options.UseNpgsql("Server=ep-wandering-thunder-622225.us-east-2.aws.neon.tech;Port=5432;Database=neondb;User ID=barisrakardevelopment;Password=QxktRDHo14UY")
              );

        //    postgres://develop:0PIgno7yEJYN@ep-wandering-thunder-622225.us-east-2.aws.neon.tech/neondb
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services,
    ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        jwtSettings.Audience = "ChargeManagement";
        jwtSettings.Issuer = "ChargeManagement";
        jwtSettings.ExpiryMinutes = 60;

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        var key = "This is my first Test Key";
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        });

        return services;
    }
}
