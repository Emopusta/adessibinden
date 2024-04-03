using Core.EventBus.Messages;
using Core.Logging.Serilog;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public class CapAdapter : ICapAdapter
{
    private readonly ICapPublisher _capPublisher;
    private readonly IEmopLogger _logger;
    private readonly IEmopLoggerFactory _emopLoggerFactory;

    public CapAdapter(ICapPublisher capPublisher, IEmopLogger logger, IEmopLoggerFactory emopLoggerFactory)
    {
        _capPublisher = capPublisher;
        _logger = logger;
        _emopLoggerFactory = emopLoggerFactory;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase
    {
        _logger.ForContext<CapAdapter>().Information($"Publishing message inside Cap Adapter: {typeof(T).Name}");
        _logger.ForContext<CapAdapter>().Fatal($"Publishing message inside Cap Adapter: {typeof(T).Name}");
        _logger.Information("Test log (This log must written because it has no Context Filter) (CapAdapter PublishAsync<T>)");
        //_logger.Fatal("Test log (This log must written because it has no Context Filter) (CapAdapter PublishAsync<T>)");
        _emopLoggerFactory.ForContext<CapAdapter>().Information($"Publishing message inside Cap Adapter with factory: {typeof(T).Name}");
        //_emopLoggerFactory.ForContext<CapAdapter>().Fatal($"Publishing message inside Cap Adapter: {typeof(T).Name}");

        await _capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
