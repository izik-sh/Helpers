using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class ExchangeRate2
    {
        [JsonProperty(PropertyName = "Key")]
        public string key { get; set; }

        [JsonProperty(PropertyName = "currentExchangeRate")]
        public decimal currentExchangeRate { get; set; }

        [JsonProperty(PropertyName = "currentChange")]
        public string currentChange { get; set; }
     
        [JsonProperty(PropertyName = "lastUpdate")]
        public DateTime lastUpdate { get; set; }




    }

    public class ExchangeRate
    {
        public string key { get; set; }
        public double currentExchangeRate { get; set; }
        public double currentChange { get; set; }
        public int unit { get; set; }
        public DateTime lastUpdate { get; set; }
    }

    public class ExchangeRates
    {
        public List<ExchangeRate> exchangeRates { get; set; }
    }
}
