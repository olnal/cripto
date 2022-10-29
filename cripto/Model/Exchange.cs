using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace crypto.Model
{
    public class ExArr
    {
        public Exchange[] exchanges { get; set; }
    }

    public class Exchange
    {
        [JsonPropertyName("exchange_id")]
        public string exchange_id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("website")]
        public string website { get; set; }

        [JsonPropertyName("volume_24h")]
        public float volume_24h { get; set; }
    }
}
