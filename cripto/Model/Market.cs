using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{
    internal class MarketArr
    {
        public Market[] markets;
    }
    internal class Market
    {
        public string exchange_id { get; set; }
        public string symbol { get; set; }
        public string base_assest { get; set; }
        public string quote_assest { get; set; }
        public double priceUnconverted { get; set; }
        public double price { get; set; }
        public double change_24h { get; set; }
        public double spread { get; set; }
        public double volume_24h { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
