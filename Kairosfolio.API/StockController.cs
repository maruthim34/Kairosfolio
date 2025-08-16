using Microsoft.AspNetCore.Mvc;
using Kairosfolio.Core.Contracts.Services;

namespace Kairosfolio.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockApiService _stockPriceService;

        public StockController(IStockApiService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

        // GET: api/stock/prices?symbols=AAPL,MSFT,GOOG,AMZN
        [HttpGet("prices")]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetPrices([FromQuery] string symbols)
        {
            if (string.IsNullOrWhiteSpace(symbols))
                return BadRequest("Please provide at least one stock symbol");

            var symbolList = symbols.Split(',', System.StringSplitOptions.RemoveEmptyEntries);

            var result = await _stockPriceService.GetPricesAsync(symbolList);

            return Ok(result);
        }
    }
}
