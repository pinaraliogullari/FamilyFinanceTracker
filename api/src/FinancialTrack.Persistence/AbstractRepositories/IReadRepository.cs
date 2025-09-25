using System.Linq.Expressions;
using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Persistence;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
    Task<T> GetByIdAsync(long id, bool tracking = true);
}