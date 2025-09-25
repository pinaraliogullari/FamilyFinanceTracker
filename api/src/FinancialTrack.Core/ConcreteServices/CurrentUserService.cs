using System.Security.Claims;
using FinancialTrack.Application.Constants;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace FinancialTrack.Core.ConcreteServices;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITokenService _tokenService;
    private IEnumerable<Claim> _cachedClaims;

    public CurrentUserService
    (
        IHttpContextAccessor httpContextAccessor,
        ITokenService tokenService
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenService = tokenService;
    }

    public string? Token
    {
        get
        {
            var value = _httpContextAccessor?.HttpContext?.Request?.Headers
                ?.FirstOrDefault(x => x.Key == "Authorization").Value.ToString() ?? "";
            if (string.IsNullOrEmpty(value) || !value.StartsWith("Bearer "))
                return string.Empty;
            return value.Substring("Bearer ".Length - 1)?.Trim();
        }
    }

    private IEnumerable<Claim>? Claims
    {
        get
        {
            if (_cachedClaims == null)
            {
                _cachedClaims = _tokenService.GetClaims(Token);
            }

            return _cachedClaims;
        }
    }

    public string UserId => Claims?.FirstOrDefault(x => x.Type == ClaimKey.UserId)?.Value;
    public string Email => Claims?.FirstOrDefault(x => x.Type == ClaimKey.Email)?.Value;
    public string Role => Claims?.FirstOrDefault(x => x.Type == ClaimKey.Role)?.Value;
    public string Referer => _httpContextAccessor?.HttpContext?.GetReferer() ?? string.Empty;
    public string UserAgent => _httpContextAccessor?.HttpContext?.GetUserAgent() ?? string.Empty;
    public string IPAddress => _httpContextAccessor?.HttpContext?.GetClientIpAddress() ?? string.Empty;
}