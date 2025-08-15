using Kairosfolio.Worker.Contracts.Services;

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
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    //var price = await _stockApiService.FetchStockDataAsync("TataSteel", stoppingToken);
                    //_logger.LogInformation($"TataSteel: {price}");

                    var price = await _stockApiService.GetPriceAsync("TSLA");
                    _logger.LogInformation($"TSLA: {price}");

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
