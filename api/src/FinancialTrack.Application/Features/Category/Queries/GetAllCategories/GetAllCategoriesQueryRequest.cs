using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Wrappers;
using FinancialTrack.Core.Markers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryRequest: IBaseQueryRequest<List<GetAllCategoriesQueryResponse>>
{
    
}