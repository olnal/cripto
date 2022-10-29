using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Controls;

namespace crypto.Data
{
    internal class DataMarket
    {
        public List<Market> marketsList;
        
        public DataMarket()
        {
            this.marketsList = new List<Market>();            
        }

        public async void FillData()
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
