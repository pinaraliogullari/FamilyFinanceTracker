using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Core.Context;

public abstract class BaseDbContext: DbContext
{
    private readonly ICurrentUserService _currentUserService;

    protected BaseDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var userId = long.TryParse(_currentUserService.UserId, out var id) ? id : (long?)null;
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.CreatedById = userId;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
                entry.Entity.UpdatedById = userId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}