using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.UserRepositories;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}