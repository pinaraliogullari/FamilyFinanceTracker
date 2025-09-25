namespace FinancialTrack.Application.Markers;

public interface ICacheableQuery
{
    //string QueryCacheKey { get; }
    string [] CacheKeyParams { get; }
    TimeSpan? CacheDuration { get; }
}