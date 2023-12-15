using System;
namespace ai_data_injector.Models
{
	public class MaintenanceRecordModel
	{
		public int Key { get; set; }
		public required object Data { get; set; }
		public DateTime Date { get; set; }
	}
}

