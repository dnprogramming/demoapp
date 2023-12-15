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
        private readonly ConnectionFactory factory = new() { HostName = Environment.GetEnvironmentVariable("MessageUrl") };

		IProcessingDataInjection _dataInjection;
		public ProcessingMessages(IProcessingDataInjection dataInjection)
		{
			_dataInjection = dataInjection;
		}

		public void ProcessSystemMaintenanceMessages()
		{
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

			channel.QueueDeclareNoWait(
				queue: "maintenanceRecord",
                durable: false,
                exclusive: false,
                autoDelete: true,
                arguments: null
            );

			var consumer = new EventingBasicConsumer(channel);

			consumer.Received += (model, ea) =>
			{
				var data = ea.Body.ToArray();
				var message = Encoding.UTF8.GetString(data);
				List<MaintenanceRecordModel> maintenance = new();
				_dataInjection.InjectSystemMaintenance(maintenance);
			};
        }
	}
}

