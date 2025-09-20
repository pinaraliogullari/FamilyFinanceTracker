using FinancialTrack.Application.Services;
using FinancialTrack.Domain.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace FinancialTrack.Infrastructure.Services;

public class CacheService : ICacheService
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

    public async Task<string> GetFromCacheAsync(string key)
        => await _distributedCache.GetStringAsync(key);


    public async Task RemoveFromCacheAsync(string key)
        => await _distributedCache.RemoveAsync(key);
}