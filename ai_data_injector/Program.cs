using ai_data_injector;
using ai_data_injector.Interfaces;
using ai_data_injector.Processing;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<IProcessingDataInjection, ProcessingDataInjection>();
builder.Services.AddTransient<IProcessingMessages, ProcessingMessages>();

var host = builder.Build();
host.Run();

