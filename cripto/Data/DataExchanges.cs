using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Controls;

namespace crypto.Data
{
    internal class DataExchanges
    {
       
        public List<Exchange> exchangeList;
 
        public DataExchanges()
        {
            
            this.exchangeList = new List<Exchange>();
            
        }

        public async void FillData()
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
    }
}

