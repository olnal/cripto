using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace crypto.Model
{
    public class MarketArr
    {
        public Market[] markets;
    }
    public class Market
    {
        [JsonPropertyName("exchange_id")]
        public string exchange_id { get; set; }

        [JsonPropertyName("symbol")]
        public string symbol { get; set; }

        [JsonPropertyName("base_assest")]
        public string base_assest { get; set; }

        [JsonPropertyName("quote_assest")]
        public string quote_assest { get; set; }

        [JsonPropertyName("priceUnconverted")]
        public double priceUnconverted { get; set; }

        [JsonPropertyName("price")]
        public double price { get; set; }

        [JsonPropertyName("change_24h")]
        public double change_24h { get; set; }

        [JsonPropertyName("spread")]
        public double spread { get; set; }

        [JsonPropertyName("volume_24h")]
        public double volume_24h { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
