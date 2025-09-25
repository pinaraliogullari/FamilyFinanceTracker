using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetByIdCategory;

public class
    GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
{
    public Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}