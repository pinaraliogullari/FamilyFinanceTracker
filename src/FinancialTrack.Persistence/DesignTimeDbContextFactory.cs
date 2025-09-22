using FinancialTrack.Application.Services;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FinancialTrack.Persistence;

public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<FinancialTrackDbContext>
{
     public FinancialTrackDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\FinancialTrack.API"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<FinancialTrackDbContext>();
        var connectionString = configuration.GetConnectionString("PostgresConn");

        optionsBuilder.UseNpgsql(connectionString);
        ICurrentUserService currentUserService = new NullCurrentUserService();

        return new FinancialTrackDbContext(optionsBuilder.Options, currentUserService);

    }
    public class NullCurrentUserService : ICurrentUserService
    {
        public string? UserId => null;
        public string? Token => null;
        public string? Email => null;
        public string? Role => null;
        public string? Referer => null;
        public string? UserAgent => null;
        public string? IPAddress => null;
    }
}