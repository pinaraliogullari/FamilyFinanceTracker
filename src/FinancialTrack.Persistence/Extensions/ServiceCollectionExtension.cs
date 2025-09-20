using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Application.Repositories.FinancialRecordRepository;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.UoW;
using FinancialTrack.Domain.Options;
using FinancialTrack.Persistence.Context;
using FinancialTrack.Persistence.Repositories.CategoryRepositories;
using FinancialTrack.Persistence.Repositories.FinancialRecordRepositories;
using FinancialTrack.Persistence.Repositories.RoleRepositories;
using FinancialTrack.Persistence.Repositories.UserRepositories;
using FinancialTrack.Persistence.Services;
using FinancialTrack.Persistence.UoW;
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

        services.AddScoped(typeof(IGenericUnitofWork<>), typeof(GenericUnitofWork<>));
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IRoleReadRepository, RoleReadRepository>();
        services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IFinancialRecordReadRepository, FinancialRecordReadRepository>();
        services.AddScoped<IFinancialRecordWriteRepository, FinancialRecordWriteRepository>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}