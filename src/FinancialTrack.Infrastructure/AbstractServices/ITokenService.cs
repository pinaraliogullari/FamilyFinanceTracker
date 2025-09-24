using System.Security.Claims;
using FinancialTrack.Application.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace FinancialTrack.Infrastructure.AbstractServices;

public interface ITokenService
{
    Task<Token> CreateAccessTokenAsync(params Claim[] claims);
    string CreateRefreshToken();
    List<Claim> GetClaims(string accessToken);
    Task RemoveOldTokens(string userId);
    bool IsValidAccessToken(string accessToken, TokenValidationParameters validationParameters);
    bool IsValidRefrehToken(string userId, string refreshToken);
}