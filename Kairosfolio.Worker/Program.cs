using Kairosfolio.Worker;
using Kairosfolio.Worker.Contracts.Repositories;
using Kairosfolio.Worker.Contracts.Services;
using Kairosfolio.Worker.Repositories.Impl;
using Kairosfolio.Worker.Services.Impl;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddHttpClient<IStockApiService, StockApiService>(client =>
{
    client.BaseAddress = new Uri("https://www.alphavantage.co/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IStockRepository, StockRepository>();


var host = builder.Build();
host.Run();
