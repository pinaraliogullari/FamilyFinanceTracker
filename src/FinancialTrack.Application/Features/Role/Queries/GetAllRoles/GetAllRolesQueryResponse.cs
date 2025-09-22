using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.Role.Queries.GetAllRoles;

public class GetAllRolesQueryResponse
{
    public List<RoleDto> Roles { get; set; }
}