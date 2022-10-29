using crypto.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.Model
{
    internal class ExchangesList
    {
        private readonly DataExchanges _dataExchanges;
        public ExchangesList(DataExchanges dataExchanges)
        {
           this._dataExchanges=dataExchanges;
        }
        
    }
}
