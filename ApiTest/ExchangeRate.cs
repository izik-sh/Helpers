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
        public string key { get; set; }
        public double currentExchangeRate { get; set; }
        public double currentChange { get; set; }
        public int unit { get; set; }
        public DateTime lastUpdate { get; set; }
    }

    public class Root
    {
        public List<ExchangeRate> exchangeRates { get; set; }
    }
}
