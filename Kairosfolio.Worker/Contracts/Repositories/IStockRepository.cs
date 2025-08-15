using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairosfolio.Worker.Contracts.Repositories
{
    public interface IStockRepository
    {
        Task InsertStockAsync(string symbol, decimal price, string currency, string source);
    }
}
