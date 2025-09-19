using FinancialTrack.Application.Repositories.FinancialRecordRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.FinancialRecordRepositories;

public class FinancialRecordWriteRepository : WriteRepository<FinancialRecord>, IFinancialRecordWriteRepository
{
    public FinancialRecordWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}