using System;
using ai_data_injector.Models;

namespace ai_data_injector.Interfaces
{
	public interface IProcessingDataInjection
	{
        Task InjectSystemMaintenance(string maintenance);
    }
}

