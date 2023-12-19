using ai_data_injector.Interfaces;

namespace ai_data_injector;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IProcessingMessages _messages;

    public Worker(ILogger<Worker> logger, IProcessingMessages messages)
    {
        _logger = logger;
        _messages = messages;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _messages.ProcessSystemMaintenanceMessages();
            await Task.Delay(1000, stoppingToken);
        }
    }
}

