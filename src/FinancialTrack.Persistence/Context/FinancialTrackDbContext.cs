using System.Reflection;
using FinancialTrack.Application.Services;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Context;

public class FinancialTrackDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public FinancialTrackDbContext(DbContextOptions<FinancialTrackDbContext> options,
        ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FinancialRecord> FinancialRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //created by ilk kayıt işleminde set edilsin daha sonraki update işlemlerinde değişmesin.
         foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                      .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType)))
         {
             modelBuilder.Entity(entityType.ClrType)
                 .Property<long?>("CreatedById")
                 .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
         }
        
        // modelBuilder.Entity<User>()
        //     .Property(x => x.CreatedById)
        //     .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var userId = long.TryParse(_currentUserService.UserId, out var id) ? id : (long?)null;
        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var item in data)
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.CreatedDate = DateTime.UtcNow;
                item.Entity.CreatedById = userId;
            }

            else if (item.State == EntityState.Modified)
            {
                item.Entity.UpdatedDate = DateTime.UtcNow;
                item.Entity.UpdatedById = userId;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}