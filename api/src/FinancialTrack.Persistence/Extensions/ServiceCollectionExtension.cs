using FinancialTrack.Domain.Options;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.ConcreteRepositories.CategoryRepositories;
using FinancialTrack.Persistence.ConcreteRepositories.FinancialRecordRepositories;
using FinancialTrack.Persistence.ConcreteRepositories.RoleRepositories;
using FinancialTrack.Persistence.ConcreteRepositories.UserRepositories;
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
        
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IRoleReadRepository, RoleReadRepository>();
        services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IFinancialRecordReadRepository, FinancialRecordReadRepository>();
        services.AddScoped<IFinancialRecordWriteRepository, FinancialRecordWriteRepository>();

        return services;
    }
}