using FinancialTrack.Application.Markers;
using MediatR;

namespace FinancialTrack.Application.Features;

public class SampleQueryForCacheBehavior:IRequest<object>, ICacheableQuery
{
    //diyelim ki kullanıcının access tokenına ulaşmak istiyoruz. 
    //public string QueryCacheKey => CacheKey.AccessTokenKey(UserId); 
    public string UserId { get; set; }
   
    //opsiyonel, parametre eklenebilir.
    public string[] CacheKeyParams =>Array.Empty<string>();
    public TimeSpan? CacheDuration => TimeSpan.FromMinutes(5);
}