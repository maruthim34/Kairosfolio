using Kairosfolio.Worker.Contracts.Repositories;
using Kairosfolio.Worker.Contracts.Services;
using Kairosfolio.Worker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kairosfolio.Worker.Services.Impl
{
    public class StockApiService : IStockApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IStockRepository _stockRepository;
        private readonly string _apiKey;
        public StockApiService(HttpClient httpClient, IStockRepository stockRepository, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _stockRepository = stockRepository;
            _apiKey = configuration.GetValue<string>("ApiKey");
        }
        public Task<decimal> FetchStockDataAsync(string stockSymbol, CancellationToken cancellationToken)
        {
            decimal stockPrice = new Random().Next(100, 500);
            return Task.FromResult(stockPrice);
        }
        public async Task<decimal> GetPriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<StockResponse>(json);

            var price = decimal.TryParse(data?.GlobalQuote?.Price, out var parsedPrice) ? parsedPrice : 0m;

            await _stockRepository.InsertStockAsync(symbol, price, "USD", "AlphaVantage");

            return price;
        }

    }
}
