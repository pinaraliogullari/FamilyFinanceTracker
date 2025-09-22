using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FinancialTrack.Application.Constants;
using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Services;
using FinancialTrack.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinancialTrack.Infrastructure.Services;

public class TokenService : ITokenService

{
    private readonly JwtSettings _jwtSettings;
    private readonly CacheSettings _cacheSettings;
    private readonly ICacheService<string> _cacheService;

    public TokenService
    (
        IOptions<JwtSettings> jwtSettings,
        ICacheService<string> cacheService,
        IOptions<CacheSettings> cacheSettings
    )
    {
        _jwtSettings = jwtSettings.Value;
        _cacheService = cacheService;
        _cacheSettings = cacheSettings.Value;
    }

    public async Task<Token> CreateAccessTokenAsync(params Claim[] claims)
    {
        var claimList = claims.ToList();
        var userId = claimList.FirstOrDefault(x => x.Type == ClaimKey.UserId)?.Value;
        Token token = new Token();

        SymmetricSecurityKey symmetricSecurityKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        SigningCredentials signingCredentials =
            new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        token.AccessTokenExpiration =
            DateTime.UtcNow.Add(TimeSpan.FromMinutes(_jwtSettings.AccessTokenLifetimeMinutes));
        token.RefreshTokenExpiration = DateTime.UtcNow.Add(TimeSpan
            .FromDays(_jwtSettings.RefreshTokenLifetimeDays));

        //access token ve refresh token üretiliyor.
        JwtSecurityToken tokenDescriptor = new JwtSecurityToken(
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            signingCredentials: signingCredentials,
            expires: token.AccessTokenExpiration,
            notBefore: DateTime.UtcNow,
            claims: claimList
        );
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        var accessToken = tokenHandler.WriteToken(tokenDescriptor);
        token.AccessToken = accessToken;
        token.RefreshToken = CreateRefreshToken();

        //access token ve refresh token cacheleniyor.
        //ikisinin de cachete kalma süreleri aynı.
        _cacheService.SetToCacheAsync(CacheKey.AccessTokenKey(userId), token.AccessToken,
            TimeSpan.FromDays(_cacheSettings.TokenCacheLifetimeDays));
        _cacheService.SetToCacheAsync(CacheKey.RefreshTokenKey(userId), token.RefreshToken,
            TimeSpan.FromDays(_cacheSettings.TokenCacheLifetimeDays));
        return token;
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        var refreshToken = Convert.ToBase64String(number);
        return refreshToken;
    }

    public List<Claim> GetClaims(string accessToken)
    {
        var validationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)),
        };
        if (IsValidAccessToken(accessToken, validationParameters))
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(accessToken);

            return jwtToken.Claims.ToList();
        }

        return null;
    }

    public async Task RemoveOldTokens(string userId)
    {
        var keys = new[]
        {
            CacheKey.AccessTokenKey(userId),
            CacheKey.RefreshTokenKey(userId),
        };
        var tasks = keys.Select(key => _cacheService.RemoveFromCacheAsync(key));
        await Task.WhenAll(tasks);
    }

    public bool IsValidAccessToken(string accessToken, TokenValidationParameters tokenValidationParameters)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out _);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool IsValidRefrehToken(string userId, string refreshToken)
    {
        var storedRefreshToken = _cacheService.GetFromCacheAsync(CacheKey.RefreshTokenKey(userId)).Result;

        if (storedRefreshToken is null || storedRefreshToken != refreshToken)
            return false;

        return true;
    }
}