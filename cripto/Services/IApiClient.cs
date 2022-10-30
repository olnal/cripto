using crypto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crypto.Services
{
    public interface IApiClient
    {
        public Task<List<Asset>> GetAsset();
        public Task<List<Exchange>> GetExchange();
        public Task<List<Market>> GetMarket();
        
    }
}
