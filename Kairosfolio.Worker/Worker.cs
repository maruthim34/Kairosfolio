using Kairosfolio.Core.Contracts.Services;

namespace Kairosfolio.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IStockApiService _stockApiService;
    public Worker(ILogger<Worker> logger, IStockApiService stockApiService)
    {
        _logger = logger;
        _stockApiService = stockApiService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var symbols = new[] { "TSLA", "AAPL", "MSFT" }; // configurable later maybe from appsettings

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var prices = await _stockApiService.GetPricesAsync(symbols);

                foreach (var kvp in prices)
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                    {
                        _logger.LogInformation($"{kvp.Key}: {kvp.Value}");
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the worker.");
            throw;
        }
    }

}
