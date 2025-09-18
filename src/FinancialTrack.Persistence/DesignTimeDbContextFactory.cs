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

        return new FinancialTrackDbContext(optionsBuilder.Options); 
    }
}