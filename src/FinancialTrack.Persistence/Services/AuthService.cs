using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinancialTrack.Application.Constants;
using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinancialTrack.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly ITokenService _tokenService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<AuthService> _logger;

    public AuthService
    (
        IUserReadRepository userReadRepository,
        IRoleReadRepository roleReadRepository,
        ITokenService tokenService,
        ICurrentUserService currentUserService,
        ILogger<AuthService> logger
    )
    {
        _userReadRepository = userReadRepository;
        _roleReadRepository = roleReadRepository;
        _tokenService = tokenService;
        _currentUserService = currentUserService;
        _logger = logger;
    }

    public async Task<LoginUserResponse> LoginAsync(LoginUser model)
    {
        var user = _userReadRepository.GetWhere(x => x.Email == model.Email).FirstOrDefault();
        if (user == null || !PasswordHasher.Verify(model.Password, user.Password))
            throw new AuthenticationFailedException();

        var role = await _roleReadRepository.GetWhere(r => r.Id == user.RoleId)
            .FirstOrDefaultAsync();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimKey.UserId, user.Id.ToString()),
            new Claim(ClaimKey.Email, user.Email),
            new Claim(ClaimKey.Role, role.Name) //burası null olduğu için token servise girmiyor olabilir
        };
        var token = await _tokenService.CreateAccessTokenAsync(claims);
        return new LoginUserResponse()
        {
            Token = token,
        };
    }

    public async Task<LogoutUserResponse> LogoutAsync()
    {
        var accessToken = _currentUserService.Token;
        var userId = _currentUserService.UserId;
        var claims = _tokenService.GetClaims(accessToken);

        if (claims == null || !claims.Any())
        {
            /*Claims null ise kullanıcı authorize şekilde bu komuta gelmiş fakat sistem tarafından üretilmeyen bir access tokena sahip demektir.*/
            var ipAddress = _currentUserService.IPAddress;
            _logger.LogWarning($"UnAuthorize request with access token: {accessToken} on ip: {ipAddress}");
            return new LogoutUserResponse()
            {
                Message = "UnAuthorize request with access token",
                Success = false
            };
        }

        await _tokenService.RemoveOldTokens(userId);
        return new LogoutUserResponse()
        {
            Message = "User logged out successfully",
            Success = true
        };
    }

    public async Task<RefreshTokenResponse> RefreshTokenLoginAsync(string refreshToken, string expiredAccessToken)
    {
        var claims = _tokenService.GetClaims(expiredAccessToken);
        if (claims == null || !claims.Any())
            throw new UnauthorizedAccessException("Invalid claims");

        var userId = claims.FirstOrDefault(x => x.Type == ClaimKey.UserId)?.Value;
        if (userId == null)
            throw new UnauthorizedAccessException("User not found");
        if (!_tokenService.IsValidRefrehToken(userId, refreshToken))
            throw new UnauthorizedAccessException("Invalid or expired refresh token");

        await _tokenService.RemoveOldTokens(userId);
        var newToken = await _tokenService.CreateAccessTokenAsync(claims.ToArray());
        return new RefreshTokenResponse()
        {
            Token = newToken,
        };
    }
}