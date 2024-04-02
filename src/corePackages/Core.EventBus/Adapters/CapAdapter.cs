using Core.EventBus.Messages;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public class CapAdapter : ICapAdapter
{
    private readonly ICapPublisher _capPublisher;

    public CapAdapter(ICapPublisher capPublisher)
    {
        _capPublisher = capPublisher;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase
    {
        await _capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
