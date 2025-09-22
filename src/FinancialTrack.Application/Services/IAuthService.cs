using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IAuthService
{
    Task<LoginUserResponseDto> LoginAsync(LoginUserDto model);
    Task<LogoutUserResponseDto> LogoutAsync();
    Task<RefreshTokenResponseDto> RefreshTokenLoginAsync(string refreshToken,string expiredAccessToken);
}