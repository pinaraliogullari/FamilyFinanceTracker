namespace FinancialTrack.Application.Markers;

public interface ICacheableQuery
{
    //string QueryCacheKey { get; }
    object[] CacheKeyParams { get; }
    TimeSpan? CacheDuration { get; }
}