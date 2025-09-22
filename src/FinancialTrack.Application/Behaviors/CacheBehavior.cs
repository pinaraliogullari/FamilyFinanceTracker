using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Behaviors;

public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICacheService<TResponse> _cacheService;

    public CacheBehavior(ICacheService<TResponse> cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not ICacheableQuery cacheableQuery)
            return await next();

        var cachedData = await _cacheService.GetFromCacheAsync(cacheableQuery.QueryCacheKey);
        return cachedData ?? await next();
    }
}