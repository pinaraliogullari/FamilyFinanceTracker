namespace FinancialTrack.Domain.Options;

public class CacheSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public int DefaultExpirationMinutes { get; set; }
    public int SlidingExpirationMinutes { get; set; }
}