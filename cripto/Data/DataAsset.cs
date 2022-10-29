using crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Controls;

namespace crypto.Data
{
    internal class DataAsset
    {
        public List<Asset> assetList;
        public DataAsset()
        {
            this.assetList = new List<Asset>();
        }

        public async void FillData()
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
    }
}

