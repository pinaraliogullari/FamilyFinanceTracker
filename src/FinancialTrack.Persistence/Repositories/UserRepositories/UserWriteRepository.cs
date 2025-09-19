using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.UserRepositories;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}