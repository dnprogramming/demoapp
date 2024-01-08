namespace api.Utilities;

public class MessageHelper : IMessageHelper {
    private static void PublishingMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "host.docker.internal",
            UserName = "guest",
            Password = "guest" 
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "queue", null, body);
        }
    }

    public void PublishMessage(string message)
    {
        PublishingMessage(message);
    }
}