using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Core.UoW;

public interface IGenericUnitofWork<TContext> : IDisposable where TContext : DbContext
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}