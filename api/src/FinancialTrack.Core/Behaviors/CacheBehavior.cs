using System.Text.Json;
using FinancialTrack.Application.Markers;
using FinancialTrack.Core.Markers;
using FinancialTrack.Core.AbstractServices;
using MediatR;

namespace FinancialTrack.Core.Behaviors;

public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseQueryRequest<TResponse>
{
    private readonly ICacheService<TResponse> _cacheService;
    private readonly ICurrentUserService _currentUserService;

    public CacheBehavior
    (
        ICacheService<TResponse> cacheService,
        ICurrentUserService currentUserService
    )
    {
        _cacheService = cacheService;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not ICacheableQuery cacheableQuery)
            return await next();
        
        var userId = _currentUserService.UserId;
        var keyParams = cacheableQuery.CacheKeyParams != null && cacheableQuery.CacheKeyParams.Any()
            ? string.Join("_", cacheableQuery.CacheKeyParams)
            : string.Empty;

        var cacheKey = string.IsNullOrWhiteSpace(keyParams)
            ? $"{typeof(TRequest).Name}_{userId}"
            : $"{typeof(TRequest).Name}_{userId}_{keyParams}";
        
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