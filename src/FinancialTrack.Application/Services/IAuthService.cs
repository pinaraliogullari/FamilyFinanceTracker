using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IAuthService
{
    Task<LoginUserResponse> LoginAsync(LoginUser model);
    Task<LogoutUserResponse> LogoutAsync();
    Task<RefreshTokenResponse> RefreshTokenLoginAsync(string refreshToken,string expiredAccessToken);
}