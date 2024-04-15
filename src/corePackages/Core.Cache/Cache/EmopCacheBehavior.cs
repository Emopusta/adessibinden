using Core.Application.CQRS;
using Core.Logging.Serilog;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace Core.Cache.Cache;
public class EmopCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IDistributedCache _distributedCache;

    private readonly CacheConfiguration _cacheConfiguration;
    private readonly IEmopLogger _emopLogger;

    private static string _baseGroupKey = "BaseCacheGroup";

    public EmopCacheBehavior(IDistributedCache distributedCache, IOptions<CacheConfiguration> optionsMonitor, IEmopLoggerFactory emopLoggerFactory)
    {
        _emopLogger = emopLoggerFactory.ForContext<EmopCacheBehavior<TRequest, TResponse>>();
        _distributedCache = distributedCache;
        _cacheConfiguration = optionsMonitor.Value;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;

        var cacheKey = GenerateCacheKey(request);

        response = typeof(TRequest).GetInterfaces().Any(p => p.Name == typeof(ICommandRequest<>).Name)
            ? await RemoveAllCacheFromServer(next, cancellationToken)
            : await AddOrFetchCache(cacheKey, next, cancellationToken); ;

        return response;
    }

    private string GenerateCacheKey(TRequest request)
    {
        return $"{request.GetType().FullName} | {JsonSerializer.Serialize<TRequest>(request)}";
    }
    private async Task<TResponse> RemoveCache(string cacheKey, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
    
        if (cacheKey != null)
        {
            await _distributedCache.RemoveAsync(cacheKey, cancellationToken);
            _emopLogger.Information($"Removed Cache: {cacheKey}");
        }
        return response;
    }
  
    private async Task<TResponse> RemoveAllCacheFromServer(RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        var opt = ConfigurationOptions.Parse("localhost:6379");
        opt.AllowAdmin = true;
        var redis = ConnectionMultiplexer.Connect(opt);
        var endpoints = redis.GetEndPoints();
        var server = redis.GetServer(endpoints.First());
        await server.FlushAllDatabasesAsync();

        return response;
    }
   
    private async Task<TResponse> RemoveAllCache(RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        await RemoveAllBaseGroup(cancellationToken);
         
        return response;
    }
   
    private async Task<TResponse> AddOrFetchCache(string cacheKey, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;


        var cachedResponse = await _distributedCache.GetAsync(cacheKey, cancellationToken);
        if (cachedResponse != null)
        {
            response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
            _emopLogger.Information($"Fetched from Cache: {cacheKey}");
        }
        else
        {
            response = await next();

            var slidingExpiration = TimeSpan.FromMinutes(_cacheConfiguration.SlidingExpiration);
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = slidingExpiration };

            var serializedData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));
            await _distributedCache.SetAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

            await AddBaseGroup(cacheKey, cacheOptions, cancellationToken);

            _emopLogger.Information($"Added to Cache: {cacheKey}");
        }

        return response;
    }

    private async Task AddBaseGroup(string cacheKey, DistributedCacheEntryOptions cacheOptions, CancellationToken cancellationToken)
    {
        var cachedGroup = await _distributedCache.GetAsync(_baseGroupKey, cancellationToken);
        HashSet<string> keys;
        if(cachedGroup != null)
        {
            keys = JsonSerializer.Deserialize<HashSet<string>>(Encoding.Default.GetString(cachedGroup))!;
            if (!keys.Contains(cacheKey))
            {
                keys.Add(cacheKey);
            }
        }
        else
        {
            keys = new HashSet<string>([cacheKey]);
        }

        var serializedGroupData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(keys));
        await _distributedCache.SetAsync(_baseGroupKey, serializedGroupData, cacheOptions, cancellationToken);
    }

    private async Task RemoveAllBaseGroup(CancellationToken cancellationToken)
    {
        var cachedGroup = await _distributedCache.GetAsync(_baseGroupKey, cancellationToken);
        HashSet<string> keys;

        if (cachedGroup != null)
        {
            keys = JsonSerializer.Deserialize<HashSet<string>>(Encoding.Default.GetString(cachedGroup))!;
            
            foreach (var key in keys)
            {
                await _distributedCache.RemoveAsync(key, cancellationToken);
                _emopLogger.Information($"Removed Cache: {_baseGroupKey} {key}");
            }

        }

        await _distributedCache.RemoveAsync(_baseGroupKey, cancellationToken);

    }
}
