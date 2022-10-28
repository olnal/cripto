using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace crypto.Data
{
    internal static class FillData
    {

        public async static void Initialize()
        {
            using (Context context = new Context())
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/exchanges"))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();
                            
                            try
                            {
                                ExArr json = JsonConvert.DeserializeObject<ExArr>(myContent);

                                for (int i = 0; i < json.exchanges.Length; i++)
                                {
                                    context.exchangeList.Add(json.exchanges[i]);
                                }
                            }
                            catch (Newtonsoft.Json.JsonSerializationException)
                            {
                                //TODO
                                return;
                                //context.marketsList[0].exchange.exchangeId = "Coin is invalid";
                            }
                        }

                    }

                    using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/assets?size=100&start=1"))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();

                            try
                            {
                                AssetArr json = JsonConvert.DeserializeObject<AssetArr>(myContent);

                                for (int i = 0; i < json.assets.Length; i++)
                                {
                                    context.assetList.Add(json.assets[i]);
                                }
                            }
                            catch (Newtonsoft.Json.JsonSerializationException)
                            {
                                //TODO
                                return;
                                //context.marketsList[0].exchange.exchangeId = "Coin is invalid";
                            }
                        }

                    }

                    using (HttpResponseMessage response = await client.GetAsync("https://cryptingup.com/api/markets?size=100&start=1"))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();

                            try
                            {
                                MarketArr json = JsonConvert.DeserializeObject<MarketArr>(myContent);

                                for (int i = 0; i < json.markets.Length; i++)
                                {
                                    context.marketsList.Add(json.markets[i]);
                                }
                            }
                            catch (Newtonsoft.Json.JsonSerializationException)
                            {
                                //TODO
                                return;
                                //context.marketsList[0].exchange.exchangeId = "Coin is invalid";
                            }
                        }

                    }

                }



            }
        }
    }
}
