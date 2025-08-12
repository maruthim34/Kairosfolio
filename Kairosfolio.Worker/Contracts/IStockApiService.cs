using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairosfolio.Worker.Contracts
{
    public interface IStockApiService
    {
        Task<decimal> FetchStockDataAsync(string stockSymbol, CancellationToken cancellationToken);
    }
}
