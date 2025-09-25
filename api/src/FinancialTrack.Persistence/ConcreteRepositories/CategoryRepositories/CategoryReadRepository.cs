using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.ConcreteRepositories.CategoryRepositories;

public class CategoryReadRepository:ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}