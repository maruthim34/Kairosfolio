using Kairosfolio.Worker.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairosfolio.Worker.Impl
{
    public class StockApiService : IStockApiService
    {
        public Task<decimal> FetchStockDataAsync(string stockSymbol, CancellationToken cancellationToken)
        {
            decimal stockPrice = new Random().Next(100, 500);
            return Task.FromResult(stockPrice);
        }
    }
}
