using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.RoleRepositories;

public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
{
    public RoleReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}