using FinancialTrack.Application.Constants;
using FinancialTrack.Application.Markers;
using MediatR;

namespace FinancialTrack.Application.Features;

public class SampleQueryForCacheBehavior:IRequest<object>, ICacheableQuery
{
    //diyelim ki kullanıcının access tokenına ulaşmak istiyoruz. 
    public string UserId { get; set; }
    public string QueryCacheKey => CacheKey.AccessTokenKey(UserId);
}