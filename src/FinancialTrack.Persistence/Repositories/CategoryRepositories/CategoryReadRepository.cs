using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Repositories.CategoryRepositories;

public class CategoryReadRepository:ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(FinancialTrackDbContext dbContext) : base(dbContext)
    {
    }
}