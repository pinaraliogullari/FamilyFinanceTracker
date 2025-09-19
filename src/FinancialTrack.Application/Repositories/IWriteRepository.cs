using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<int>SaveChangesAsync();
}