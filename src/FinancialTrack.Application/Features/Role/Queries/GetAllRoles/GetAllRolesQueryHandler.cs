using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using MediatR;

namespace FinancialTrack.Application.Features.Role.Queries.GetAllRoles;

public class GetAllRolesQueryHandler: IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
{
    public Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}