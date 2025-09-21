using System.Linq.Expressions;
using FinancialTrack.Application.Repositories;
using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly FinancialTrackDbContext _dbContext;

    public ReadRepository(FinancialTrackDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public DbSet<T> Table => _dbContext.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
    {
        var query = Table.Where(predicate).AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetByIdAsync(long id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }
}