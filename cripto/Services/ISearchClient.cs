using crypto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crypto.Services
{
    public interface ISearchClient
    {
        public Task<Asset> GetAssetSearch(string search);
        public Task<Exchange> GetExchangeSearch(string search);
        public Task<Market> GetMarketSearch(string search);
    }
}
