using FinancialTrack.Application.Repositories;
using FinancialTrack.Application.UoW;
using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Persistence.Context;
using FinancialTrack.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.UoW;

public class GenericUnitofWork<TContext> : IGenericUnitofWork<TContext> where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly Dictionary<Type, object> _readRepos = new();
    private readonly Dictionary<Type, object> _writeRepos = new();

    public GenericUnitofWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadRepository<TEntity> Read<TEntity>() where TEntity : BaseEntity
    {
        var type = typeof(TEntity);
        if (!_readRepos.ContainsKey(type))
        {
            if (_dbContext is FinancialTrackDbContext ftDb)
                _readRepos[type] = new ReadRepository<TEntity>(ftDb);
            //else if (_dbContext is OtherDbContext otherDb)
            //_readRepos[type] = new OtherReadRepository<TEntity>(otherDb);
            else
                throw new NotSupportedException("Bu DbContext ile ReadRepository desteklenmiyor");
        }

        return (IReadRepository<TEntity>)_readRepos[type];
    }

    public IWriteRepository<TEntity> Write<TEntity>() where TEntity : BaseEntity
    {
        var type = typeof(TEntity);
        if (!_readRepos.ContainsKey(type))
        {
            if (_dbContext is FinancialTrackDbContext ftDb)
                _readRepos[type] = new WriteRepository<TEntity>(ftDb);
            //else if (_dbContext is OtherDbContext otherDb)
            //_readRepos[type] = new OtherReadRepository<TEntity>(otherDb);
            else
                throw new NotSupportedException("Bu DbContext ile WriteRepository desteklenmiyor");
        }

        return (IWriteRepository<TEntity>)_writeRepos[type];
    }


    public void Dispose()
        => _dbContext.Dispose();


    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}