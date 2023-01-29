using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    public class ExchangeRate
    {
        [JsonConstructor]
        public ExchangeRate(
            [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore, Order = 1)] string key,
            [JsonProperty("currentExchangeRate", NullValueHandling = NullValueHandling.Ignore, Order = 2)] double? currentExchangeRate,
            [JsonProperty("currentChange", NullValueHandling = NullValueHandling.Ignore, Order = 3)] double? currentChange,
            [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore, Order = 4)] int? unit,
            [JsonProperty("lastUpdate", NullValueHandling = NullValueHandling.Ignore, Order = 5)] DateTime? lastUpdate
        )
        {
            this.Key = key;
            this.CurrentExchangeRate = currentExchangeRate;
            this.CurrentChange = currentChange;
            this.Unit = unit;
            this.LastUpdate = lastUpdate;
        }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        [JsonProperty("currentExchangeRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? CurrentExchangeRate { get; }

        [JsonProperty("currentChange", NullValueHandling = NullValueHandling.Ignore)]
        public double? CurrentChange { get; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Unit { get; }

        [JsonProperty("lastUpdate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastUpdate { get; }
    }

    public class Root
    {
        [JsonConstructor]
        public Root(
            [JsonProperty("exchangeRates", NullValueHandling = NullValueHandling.Ignore)] List<ExchangeRate> exchangeRates
        )
        {
            this.ExchangeRates = exchangeRates;
        }

        [JsonProperty("exchangeRates", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<ExchangeRate> ExchangeRates { get; }
    }
}
