using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.CategoryRepositories;

public class CategoryWriteRepository:WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}