using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.RoleRepositories;

public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
{
    public RoleWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}