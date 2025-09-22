using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Features.Role.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetAllRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var roles = await _roleService.GetAllRolesAsync();
        return new GetAllRolesQueryResponse { Roles = roles };
    }
}