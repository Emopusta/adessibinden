using Core.EventBus.Messages;
using DotNetCore.CAP;

namespace Core.EventBus.Extensions;

public static class CapExtensions
{

    public static async Task PublishAsync<T>(this ICapPublisher capPublisher, T message, CancellationToken cancellationToken) where T : MessageBase
    {
        await capPublisher.PublishAsync(typeof(T).Name, contentObj: message, cancellationToken: cancellationToken);
    }
}
