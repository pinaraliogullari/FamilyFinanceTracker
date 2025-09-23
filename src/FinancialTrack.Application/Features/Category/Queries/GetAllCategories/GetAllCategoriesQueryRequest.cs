using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryRequest: IRequest<ApiResult<GetAllCategoriesQueryResponse>>
{
    
}