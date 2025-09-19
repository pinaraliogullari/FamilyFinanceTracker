using FinancialTrack.Application.Repositories;
using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly FinancialTrackDbContext _dbContext;

    public WriteRepository(FinancialTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<T> Table => _dbContext.Set<T>();

    public async Task AddAsync(T entity)
        => await Table.AddAsync(entity);


    public void Update(T entity)
        => Table.Update(entity);


    public void Remove(T entity)
        => Table.Remove(entity);

    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}