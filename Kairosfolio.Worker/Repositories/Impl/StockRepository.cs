using Dapper;
using Kairosfolio.Worker.Contracts.Repositories;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Kairosfolio.Worker.Repositories.Impl
{
    public class StockRepository : IStockRepository
    {
        private readonly string _connectionString;
        public StockRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StockDb");
        }
        public async Task InsertStockAsync(string symbol, decimal price, string currency, string source)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"INSERT INTO Stocks (Symbol, Price, Currency, FetchedAt, Source)
                        VALUES (@Symbol, @Price, @Currency, @FetchedAt, @Source)";

            await connection.ExecuteAsync(sql, new
            {
                Symbol = symbol,
                Price = price,
                Currency = currency,
                FetchedAt = DateTime.Now,
                Source = source
            });
        }
    }
}
