using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUser dto);
    Task UpdateUserRoleAsync(UpdateUserRole dto);
    Task UpdateUserPasswordAsync(UpdateUserPassword dto);
}
