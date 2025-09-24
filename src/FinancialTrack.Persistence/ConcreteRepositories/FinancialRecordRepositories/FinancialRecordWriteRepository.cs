using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.FinancialRecordRepositories;

public class FinancialRecordWriteRepository : WriteRepository<FinancialRecord>, IFinancialRecordWriteRepository
{
    public FinancialRecordWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}