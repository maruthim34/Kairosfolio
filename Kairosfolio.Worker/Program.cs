using Kairosfolio.Worker;
using Kairosfolio.Worker.Contracts;
using Kairosfolio.Worker.Impl;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IStockApiService, StockApiService>();

var host = builder.Build();
host.Run();
