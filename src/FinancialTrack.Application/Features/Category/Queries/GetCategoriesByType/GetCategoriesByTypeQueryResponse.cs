using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class GetCategoriesByTypeQueryResponse
{
   public List<CategoryDto> Categories{ get; set; }
}