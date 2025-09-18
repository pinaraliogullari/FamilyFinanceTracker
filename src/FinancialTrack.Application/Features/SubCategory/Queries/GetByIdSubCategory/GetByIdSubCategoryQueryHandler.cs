using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Queries.GetByIdSubCategory;

public class
    GetByIdSubCategoryQueryHandler : IRequestHandler<GetByIdSubCategoryQueryRequest, GetByIdSubCategoryQueryResponse>
{
    public Task<GetByIdSubCategoryQueryResponse> Handle(GetByIdSubCategoryQueryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}