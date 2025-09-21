namespace FinancialTrack.Domain.Options;

public class CacheSettings
{
    public string Host { get; set; }
    public string Port { get; set; }
    public int TokenCacheLifetimeDays{get;set;}
}