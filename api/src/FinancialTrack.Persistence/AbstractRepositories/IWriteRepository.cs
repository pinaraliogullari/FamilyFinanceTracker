using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Persistence;

public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
 
}