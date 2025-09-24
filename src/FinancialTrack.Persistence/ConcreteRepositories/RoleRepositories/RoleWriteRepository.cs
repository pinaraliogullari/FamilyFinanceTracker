using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.RoleRepositories;

public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
{
    public RoleWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}