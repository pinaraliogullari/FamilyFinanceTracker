using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTrack.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtension));
        return services;
    }
}