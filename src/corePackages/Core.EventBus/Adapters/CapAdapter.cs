using Core.EventBus.Messages;
using Core.Logging.Serilog;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public class CapAdapter : ICapAdapter
{
    private readonly ICapPublisher _capPublisher;
    private readonly IEmopLogger _emopLogger;

    public CapAdapter(ICapPublisher capPublisher, IEmopLoggerFactory emopLoggerFactory)
    {
        _capPublisher = capPublisher;
        _emopLogger = emopLoggerFactory.ForContext<CapAdapter>();
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase
    {
        _emopLogger.Information($"Publishing message inside Cap Adapter with factory: {typeof(T).Name}");

        await _capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
