using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinancialTrack.Core.UoW;

public class GenericUnitofWork<TContext> : IGenericUnitofWork<TContext> where TContext : DbContext
{
    private readonly TContext _dbContext;
    private IDbContextTransaction _transaction;

    public GenericUnitofWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        => _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken);
    
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
            if (_transaction != null)
                await _transaction.CommitAsync(cancellationToken);
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }
    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (_transaction != null)
                await _transaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    private async Task DisposeTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
        => _dbContext.Dispose();
}