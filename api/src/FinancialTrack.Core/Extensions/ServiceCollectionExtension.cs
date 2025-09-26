using System.Text;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.ConcreteServices;
using FinancialTrack.Core.Context;
using FinancialTrack.Core.UoW;
using FinancialTrack.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinancialTrack.Core.Extensions;

public static class ServiceCollectionExtension
{
    private static IServiceCollection JwtAuthenticationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            })
            .AddJwtBearer("Bearer", options =>
            {
                var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecurityKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        return services;
    }

    private static IServiceCollection ConfigurationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        return services;
    }

    private static IServiceCollection CacheSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheSettings = configuration.GetSection(nameof(CacheSettings)).Get<CacheSettings>();
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = $"{cacheSettings.Host}:{cacheSettings.Port}";
        });
        return services;
    }

    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.JwtAuthenticationSettings(configuration);
        services.CacheSettings(configuration);
        services.ConfigurationSettings(configuration);
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped(typeof(ICacheService<>),typeof(CacheService<>));
        services.AddScoped(typeof(IGenericUnitofWork<>), typeof(GenericUnitofWork<>));
        services.AddScoped(typeof(ICurrentUserService),typeof(CurrentUserService));
        services.AddScoped(typeof(IBaseDbContext),typeof(BaseDbContext));

        return services;
    }
}