using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.FinancialRecordRepositories;

public class FinancialRecordReadRepository : ReadRepository<FinancialRecord>, IFinancialRecordReadRepository
{
    public FinancialRecordReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}