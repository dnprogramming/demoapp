using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ai_data_injector.Interfaces;
using ai_data_injector.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ai_data_injector
{
	public class ProcessingMessages : IProcessingMessages
	{
		IProcessingDataInjection _dataInjection;
		public ProcessingMessages(IProcessingDataInjection dataInjection)
		{
			_dataInjection = dataInjection;
		}

		public void ProcessSystemMaintenanceMessages()
		{
			Console.WriteLine(" [*] Waiting for messages.");
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672/") };
			using var connection = factory.CreateConnection();
			using var channel = connection.CreateModel();

			channel.QueueDeclare(queue: "queue",
								durable: false,
								exclusive: false,
								autoDelete: false,
								arguments: null);
			channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

			var consumer = new EventingBasicConsumer(channel);

			consumer.Received += (model, ea) =>
			{
				var data = ea.Body.ToArray();
				var message = Encoding.UTF8.GetString(data);
				_dataInjection.InjectSystemMaintenance(message);
			};

			channel.BasicConsume(queue: "queue",
                     autoAck: true,
                     consumer: consumer);
        }
	}
}

