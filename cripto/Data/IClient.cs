﻿using crypto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace crypto.Data
{
    public interface IClient
    {
        public Task<List<Asset>> GetAsset();
        public Task<List<Exchange>> GetExchange();
        public Task<List<Market>> GetMarket();
        public Task<Asset> GetAssetSearch(string search);
        public Task<Exchange> GetExchangeSearch(string search);
        public Task<Market> GetMarketSearch(string search);
    }
}
