﻿using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace crypto.Data
{
    public class Client : IClient
    {
        [JsonPropertyName("markets")]
        public List<Market> marketsList { get; set; }

        [JsonPropertyName("exchanges")]
        public List<Exchange> exchangeList { get; set; }

        [JsonPropertyName("assets")]
        public List<Asset> assetList { get; set; }


        private readonly HttpClient _httpClient = new HttpClient(new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(1) })
        {
            BaseAddress = new Uri("https://cryptingup.com/api/")
        };
        public Client()
        {
            this.marketsList = new List<Market>();
            this.exchangeList = new List<Exchange>();
            this.assetList = new List<Asset>();
        }

        public async Task<List<Asset>> GetAsset()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("assets?size=100&start=100");
            using HttpContent content = response.Content;
            string myContent = await content.ReadAsStringAsync();
            AssetArr json = JsonConvert.DeserializeObject<AssetArr>(myContent);            
            return json.assets.ToList<Asset>();
        }
        public async Task<List<Exchange>> GetExchange()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("exchanges");
            using HttpContent content = response.Content;
            string myContent = await content.ReadAsStringAsync();
            ExArr json = JsonConvert.DeserializeObject<ExArr>(myContent);
            return json.exchanges.ToList<Exchange>();
        }

        public async Task<List<Market>> GetMarket()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("markets?size=100&start=1");
            using HttpContent content = response.Content;
            string myContent = await content.ReadAsStringAsync();
            MarketArr json = JsonConvert.DeserializeObject<MarketArr>(myContent);
            return json.markets.ToList<Market>();            
        }
        public Asset GetAssetSearch(string search)
        {
            //TODO
            return new Asset();
        }
    }
}
