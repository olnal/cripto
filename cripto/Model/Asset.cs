using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace crypto.Model
{
    public class AssetArr
    {
        public Asset[] assets;
    }    
    public class Asset
    {
        [JsonPropertyName("asset_id")]
        public string assetId { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("volume_24")]
        public double volume_24h { get; set; }

        [JsonPropertyName("change_1h")]
        public double change_1h { get; set; }

        [JsonPropertyName("change_24h")]
        public double change_24h { get; set; }

        [JsonPropertyName("change_7d")]
        public double change_7d { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime updated_at { get; set; }

    }
}
