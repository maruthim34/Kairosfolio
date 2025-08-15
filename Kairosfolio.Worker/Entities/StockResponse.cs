using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kairosfolio.Worker.Entities
{
    public class GlobalQuote
    {
        [JsonPropertyName("05. price")]
        public string Price { get; set; }
    }

    public class StockResponse
    {
        [JsonPropertyName("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }
    }
}
