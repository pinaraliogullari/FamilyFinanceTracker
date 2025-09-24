using FinancialTrack.Infrastructure.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTrack.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(CacheBehavior<,>));
        });
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
        return services;
    }
}