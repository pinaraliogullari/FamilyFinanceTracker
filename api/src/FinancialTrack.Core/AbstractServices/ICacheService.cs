namespace FinancialTrack.Core.AbstractServices;

public interface ICacheService<TResponse>
{
    Task SetToCacheAsync(string key,string value,TimeSpan absoluteExpiration);
    Task<TResponse?> GetFromCacheAsync(string key);
    Task RemoveFromCacheAsync(string key);
}