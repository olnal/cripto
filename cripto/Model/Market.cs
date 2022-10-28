using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{
    internal class Market
    {
        public Exchange exchange { get; set; }
        public string symbol { get; set; }
        public Asset baseAssest { get; set; }
        public Asset quoteAssest { get; set; }
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
