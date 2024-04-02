using Core.EventBus.Messages;

namespace Core.EventBus.Extensions
{
    public interface ICapAdapter
    {
        Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : MessageBase;
    }
}