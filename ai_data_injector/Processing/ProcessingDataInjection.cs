using System.Threading.Tasks;
using ai_data_injector.Interfaces;
using ai_data_injector.Models;
using Cassandra;

namespace ai_data_injector.Processing
{
	public class ProcessingDataInjection : IProcessingDataInjection
	{
        Cluster cluster = Cluster
						  .Builder()
						  .AddContactPoint("127.0.0.1")
						  .WithCredentials(
							 Environment.GetEnvironmentVariable("CassandraUserName"),
							 Environment.GetEnvironmentVariable("CassandraPassword")
						  )
                          .WithCompression(CompressionType.LZ4)
                          .Build();
        public ProcessingDataInjection()
		{
		}

		internal async Task InjectingSystemMaintenance(string maintenance)
		{
			ISession session = await cluster.ConnectAsync(Environment.GetEnvironmentVariable("CassandraSystemMaintenanceKeyspace"));

			var prepare = await session.PrepareAsync("INSERT INTO system_maintenance (key, text, date) VALUES (?, ?, ?)");
			var batch = new BatchStatement();
			batch.Add(prepare.Bind(Guid.NewGuid(), maintenance, DateTime.Now));
			await session.ExecuteAsync(batch);
		}
        public async Task InjectSystemMaintenance(string maintenance)
		{
			await InjectingSystemMaintenance(maintenance);
		}
    }
}

