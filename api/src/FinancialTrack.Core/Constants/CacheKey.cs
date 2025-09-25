namespace FinancialTrack.Application.Constants;

public static class CacheKey
{
    public static string AccessTokenKey(string userId) => $"access token for user:{userId}";
    public static string RefreshTokenKey(string userId) => $"refresh token for user:{userId}";
        
}