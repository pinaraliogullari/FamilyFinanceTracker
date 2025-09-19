using FinancialTrack.Application.UoW;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.UoW;

public class GenericUnitofWork<TContext> : IGenericUnitofWork<TContext> where TContext : DbContext
{
    private readonly TContext _dbContext;

    public GenericUnitofWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Dispose()
        => _dbContext.Dispose();
    
    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}