using cripto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace cripto.Data
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

                }
            }
        }
    }
}
