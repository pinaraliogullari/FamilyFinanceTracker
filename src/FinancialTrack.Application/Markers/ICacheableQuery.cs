namespace FinancialTrack.Application.Markers;

public interface ICacheableQuery
{
    string QueryCacheKey { get; }
}