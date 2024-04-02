using Core.EventBus.Messages;
using Core.Logging.Serilog;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public class CapAdapter : ICapAdapter
{
    private readonly ICapPublisher _capPublisher;
    private readonly ILogger _logger;

    public CapAdapter(ICapPublisher capPublisher, ILogger logger)
    {
        _capPublisher = capPublisher;
        _logger = logger;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase
    {
        _logger.Information($"Publishing Async message: {typeof(T).Name}");

        await _capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
