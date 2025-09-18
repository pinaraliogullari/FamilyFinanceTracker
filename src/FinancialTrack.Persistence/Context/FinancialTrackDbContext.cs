using System.Reflection;
using FinancialTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Context;

public class FinancialTrackDbContext : DbContext
{
    public FinancialTrackDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<FinancialRecord> FinancialRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}