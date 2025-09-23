using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryResponse
{
   public List<CategoryDto> Categories{ get; set; }
}