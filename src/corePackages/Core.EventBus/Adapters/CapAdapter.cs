using Core.EventBus.Messages;
using Core.Logging.Serilog;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public class CapAdapter : ICapAdapter
{
    private readonly ICapPublisher _capPublisher;
    private readonly IEmopLoggerFactory _emopLoggerFactory;

    public CapAdapter(ICapPublisher capPublisher, IEmopLoggerFactory emopLoggerFactory)
    {
        _capPublisher = capPublisher;
        _emopLoggerFactory = emopLoggerFactory;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase
    {
        _emopLoggerFactory.ForContext<CapAdapter>().Information($"Publishing message inside Cap Adapter with factory: {typeof(T).Name}");

        await _capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
