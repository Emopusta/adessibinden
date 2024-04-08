using Core.Application.CQRS;
using Core.Logging.Serilog;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Cache.Cache;

public class EmopCacheRemoveBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandRequest<TResponse>, IEmopCacheRemove
{
    private readonly IDistributedCache _distributedCache;

    private readonly IEmopLogger _emopLogger;

    public EmopCacheRemoveBehavior(IDistributedCache distributedCache, IEmopLoggerFactory emopLoggerFactory)
    {
        _distributedCache = distributedCache;
        _emopLogger = emopLoggerFactory.ForContext<EmopCacheRemoveBehavior<TRequest, TResponse>>();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var response = await next();

        if(request.CacheKey != null)
        {
            await _distributedCache.RemoveAsync(request.CacheKey, cancellationToken);
            _emopLogger.Information($"Removed Cache: {request.CacheKey}");
        }

        return response;
    }
}
