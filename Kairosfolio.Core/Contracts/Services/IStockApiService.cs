namespace Kairosfolio.Core.Contracts.Services
{
    public interface IStockApiService
    {
        Task<decimal> FetchStockDataAsync(string stockSymbol, CancellationToken cancellationToken);
        Task<decimal> GetPriceAsync(string stockSymbol);
        Task<Dictionary<string, decimal>> GetPricesAsync(IEnumerable<string> symbols);
        Task<decimal> FetchAndSavePriceAsync(string stockSymbol);
    }
}
