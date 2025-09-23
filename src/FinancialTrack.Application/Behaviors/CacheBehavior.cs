using System.Text.Json;
using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Behaviors;

public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseQueryRequest<TResponse>
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
        
        var keyParams = string.Join("_", cacheableQuery.CacheKeyParams);
        var cacheKey = $"{typeof(TRequest).Name}_{keyParams}"; //key->GetUserByIdQuery_5
        var cachedData = await _cacheService.GetFromCacheAsync(cacheKey);
        if (cachedData != null)
            return cachedData;

        var response = await next();
        var serializedResponse = JsonSerializer.Serialize(response);


        await _cacheService.SetToCacheAsync(cacheKey, serializedResponse,
            cacheableQuery.CacheDuration ?? TimeSpan.FromMinutes(5));

        return response;
    }
}