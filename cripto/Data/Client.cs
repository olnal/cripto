using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            using HttpResponseMessage response = await _httpClient.GetAsync("https://cryptingup.com/api/assets?size=100&start=1");
            using HttpContent content = response.Content;
            string myContent = await content.ReadAsStringAsync();
            AssetArr json = JsonConvert.DeserializeObject<AssetArr>(myContent);
            for (int i = 0; i < json.assets.Length; i++)
            {
                assetList.Add(json.assets[i]);
            }
            return assetList;
        }




        public async Task<List<Exchange>> GetExchange()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/exchanges"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        ExArr json = JsonConvert.DeserializeObject<ExArr>(myContent);

                        for (int i = 0; i < json.exchanges.Length; i++)
                        {
                            exchangeList.Add(json.exchanges[i]);
                        }
                        return exchangeList;
                    }
                }
            }

        }

        public async Task<List<Market>> GetMarket()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/markets?size=100&start=1"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        MarketArr json = JsonConvert.DeserializeObject<MarketArr>(myContent);
                        for (int i = 0; i < json.markets.Length; i++)
                        {
                            marketsList.Add(json.markets[i]);
                        }
                        return marketsList;
                    }
                }
            }
        }
    }
}
