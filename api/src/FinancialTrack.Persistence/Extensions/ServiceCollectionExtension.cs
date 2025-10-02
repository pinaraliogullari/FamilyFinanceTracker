using FinancialTrack.Core.Context;
using FinancialTrack.Domain.Options;
using FinancialTrack.Persistence.ConcreteRepositories;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FinancialTrack.Persistence.Extensions;

public static class ServiceCollectionExtension
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
       services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
       services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
       services.AddScoped<IBaseDbContext>(sp => sp.GetRequiredService<FinancialTrackDbContext>());

     

        return services;
    }
}