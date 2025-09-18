using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Queries.GetAllSubCategories;

public class
    GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQueryRequest, GetAllSubCategoriesQueryResponse>
{
    public Task<GetAllSubCategoriesQueryResponse> Handle(GetAllSubCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}