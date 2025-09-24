using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.RoleRepositories;

public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
{
    public RoleReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}