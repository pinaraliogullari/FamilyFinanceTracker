namespace FinancialTrack.Application.Services;

public interface ICacheService
{
    Task SetToCacheAsync(string key,string value,TimeSpan absoluteExpiration);
    Task<string> GetFromCacheAsync(string key);
    Task RemoveFromCacheAsync(string key);
}