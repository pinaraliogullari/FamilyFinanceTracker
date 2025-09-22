using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IRoleService
{
    Task<List<RoleDto>> GetAllRolesAsync();
}