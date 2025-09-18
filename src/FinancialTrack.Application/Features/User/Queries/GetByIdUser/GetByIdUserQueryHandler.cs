using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetByIdUser;

public class GetByIdUserQueryHandler:IRequestHandler<GetByIdUserQueryRequest,GetByIdUserQueryResponse>
{
    public Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}