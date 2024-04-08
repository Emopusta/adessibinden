﻿using Core.Application.CQRS;
using Core.Logging.Serilog;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Core.Cache.Cache;
public class EmopCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IQueryRequest<TResponse>, IEmopCache
{
    private readonly IDistributedCache _distributedCache;

    private readonly CacheConfiguration _cacheConfiguration;
    private readonly IEmopLogger _emopLogger;

    public EmopCacheBehavior(IDistributedCache distributedCache, IOptions<CacheConfiguration> optionsMonitor, IEmopLoggerFactory emopLoggerFactory)
    {
        _emopLogger = emopLoggerFactory.ForContext<EmopCacheBehavior<TRequest, TResponse>>();
        _distributedCache = distributedCache;
        _cacheConfiguration = optionsMonitor.Value;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;
        
        var cachedResponse = await _distributedCache.GetAsync(request.CacheKey, cancellationToken);
        if (cachedResponse != null)
        {
            response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
            _emopLogger.Information($"Fetched from Cache: {request.CacheKey}");
        }
        else
        {
            response = await next();

            TimeSpan? slidingExpiration = TimeSpan.FromDays(_cacheConfiguration.SlidingExpiration);
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = slidingExpiration };

            var serializedData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));
            await _distributedCache.SetAsync(request.CacheKey, serializedData, cacheOptions, cancellationToken);
            _emopLogger.Information($"Added to Cache: {request.CacheKey}");
        }

        return response;
    }
}
