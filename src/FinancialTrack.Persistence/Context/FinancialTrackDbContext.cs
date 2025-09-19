using System.Reflection;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Context;

public class FinancialTrackDbContext : DbContext
{
    public FinancialTrackDbContext(DbContextOptions<FinancialTrackDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FinancialRecord> FinancialRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var item in data)
        {
            _ = item.State switch
            {
                EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}