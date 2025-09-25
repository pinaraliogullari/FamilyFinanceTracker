using FinancialTrack.Application.Features.User.Queries.GetByIdUser;
using MediatR;

namespace FinancialTrack.Application.Features.Role.Queries.GetByIdRole;

public class GetByIdRoleQueryHandler:IRequestHandler<GetByIdRoleQueryRequest,GetByIdRoleQueryResponse>
{
    public Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}