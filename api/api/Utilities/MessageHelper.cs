using System.Threading.Tasks;

namespace api.Utilities;

public class MessageHelper : IMessageHelper {
    private static async Task PublishingMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "host.docker.internal",
            UserName = "guest",
            Password = "guest" 
        };

        using (var connection = factory.CreateConnectionAsync())
        using (var channel = connection.Result.CreateChannelAsync())
        {
            channel.Result.QueueDeclareAsync("queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            // var body = Encoding.UTF8.GetBytes(message);
            // channel.Result.BasicPublishAsync(exchange: "", routingKey: "queue",
            //     basicProperties: null, body: body);
            channel.Result.CloseAsync();
            connection.Result.CloseAsync();
        }
    }

    public void PublishMessage(string message)
    {
        PublishingMessage(message);
    }
}