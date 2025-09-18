using FinancialTrack.Domain.Options;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinancialTrack.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        services.AddDbContext<FinancialTrackDbContext>((sp, options) =>
        {
            var dbSettings = sp.GetRequiredService<IOptions<ConnectionStrings>>().Value;
            options.UseNpgsql(dbSettings.PostgresConn);
        });
        return services;
    }
}