
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Infrastructure.UoW;

public interface IGenericUnitofWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> SaveChangesAsync();
}