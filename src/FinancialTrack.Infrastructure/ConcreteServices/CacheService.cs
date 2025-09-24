using System.Text.Json;
using FinancialTrack.Domain.Options;
using FinancialTrack.Infrastructure.AbstractServices;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace FinancialTrack.Infrastructure.ConcreteServices;

public class CacheService<TResponse> : ICacheService<TResponse>
{
    private readonly IDistributedCache _distributedCache;
    private readonly CacheSettings _cacheSettings;

    public CacheService(IDistributedCache cache, IOptions<CacheSettings> cacheSettings)
    {
        _distributedCache = cache;
        _cacheSettings = cacheSettings.Value;
    }

    public async Task SetToCacheAsync(string key, string value,TimeSpan absoluteExpiration)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = absoluteExpiration,
        };
        await _distributedCache.SetStringAsync(key, value, options);
    }

    public async Task<TResponse?> GetFromCacheAsync(string key)
    {
        var cachedString = await _distributedCache.GetStringAsync(key);
        if (cachedString == null) return default;

        return JsonSerializer.Deserialize<TResponse>(cachedString);
    }


    public async Task RemoveFromCacheAsync(string key)
        => await _distributedCache.RemoveAsync(key);
}