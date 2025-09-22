using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto dto);
    Task UpdateUserRoleAsync(UpdateUserRoleDto dto);
    Task UpdateUserPasswordAsync(UpdateUserPasswordDto dto);
    Task<List<UserDto>> GetAllUsersAsync();
}
