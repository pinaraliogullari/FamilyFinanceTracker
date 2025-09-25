using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.CategoryRepositories;

public class CategoryWriteRepository:WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}