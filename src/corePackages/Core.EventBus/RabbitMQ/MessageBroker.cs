using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Core.EventBus.RabbitMQ;

public class MessageBroker : IMessageBroker
{

    private readonly ConnectionFactory _factory;
    private int _counter { get; set; } = 0;

    public MessageBroker(ConnectionFactory factory)
    {
        _factory = factory;
    }

    public void PublishMessage(string queueName, string message)
    {
        using (var connection = _factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }

    public void ConsumeMessage(string queueName, Action<string> action)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        var messageCount = channel.MessageCount(queueName);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            action(message + messageCount);
        };
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    }

}
