using System.Linq.Expressions;
using System.Reflection;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.Context;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinancialTrack.Persistence.Context;

public class FinancialTrackDbContext : BaseDbContext
{
    private readonly ICurrentUserService _currentUserService;

    public FinancialTrackDbContext(DbContextOptions<FinancialTrackDbContext> options,
        ICurrentUserService currentUserService) : base(options, currentUserService)
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
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            //Global query filter=>IsDeleted=false
            //Tüm querylere IsDeleted==false şeklinde filter eklenecek.

            var param = Expression.Parameter(entityType.ClrType, "entity");
            var prop = Expression.PropertyOrField(param, nameof(BaseEntity.IsDeleted));
            var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(entityNotDeleted);
        }

        base.OnModelCreating(modelBuilder);
    }
}