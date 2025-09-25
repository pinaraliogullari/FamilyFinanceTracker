using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.UserRepositories;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}