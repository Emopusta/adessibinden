namespace Core.EventBus.RabbitMQ;

public interface IMessageBroker
{
    void PublishMessage(string queueName, string message);

    void ConsumeMessage(string queueName, Action<string> action);
}