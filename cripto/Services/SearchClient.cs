using crypto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crypto.Services
{
    public class SearchClient:ISearchClient
    {
        private readonly IApiClient _client;
        public SearchClient(IApiClient client)
        {
            _client = client;
        }

        public async Task<Asset> GetAssetSearch(string search)
        {
            List<Asset> assets = await _client.GetAsset();
            return assets.Where(n => n.assetId == search || n.name == search).FirstOrDefault();
        }

        public async Task<Exchange> GetExchangeSearch(string search)
        {
            List<Exchange> exchanges = await _client.GetExchange();
            return exchanges.Where(n => n.exchange_id == search || n.name == search).FirstOrDefault();
        }
        public async Task<Market> GetMarketSearch(string search)
        {
            List<Market> market = await _client.GetMarket();
            return market.Where(n => n.exchange_id == search || n.symbol == search).FirstOrDefault();
        }
    }
}
