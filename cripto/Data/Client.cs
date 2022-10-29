using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Controls;

namespace crypto.Data
{
    internal class Client
    {
        [JsonPropertyName("markets")]
        public List<Market> marketsList { get; set; }

        [JsonPropertyName("exchanges")]
        public List<Exchange> exchangeList { get; set; }

        [JsonPropertyName("assets")]
        public List<Asset> assetList { get; set; }
        public  Client()
        {
            this.marketsList=new List<Market>();
            this.exchangeList=new List<Exchange>();
            this.assetList=new List<Asset>();
        }
        public  async void GetAsset()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/assets?size=100&start=1"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        AssetArr json = JsonConvert.DeserializeObject<AssetArr>(myContent);
                        for (int i = 0; i < json.assets.Length; i++)
                        {
                            assetList.Add(json.assets[i]);
                        }
                    }
                }
            }
        }

        public async void GetExchange()
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
                    }
                }
            }
        }

        public async void GetMarket()
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
                    }
                }
            }
        }
    }
}
