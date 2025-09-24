using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.UserRepositories;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}