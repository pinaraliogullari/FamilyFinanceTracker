using FinancialTrack.Application.Repositories.FinancialRecordRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.FinancialRecordRepositories;

public class FinancialRecordReadRepository : ReadRepository<FinancialRecord>, IFinancialRecordReadRepository
{
    public FinancialRecordReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}