
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.UoW;

public interface IGenericUnitofWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> SaveChangesAsync();
}