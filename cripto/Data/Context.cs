using cripto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace cripto.Data
{
    internal class Context:IDisposable
    {
        public List<Market> marketsList;
        public List<Exchange> exchangeList;
        public List<Asset> assetList;
        public Context()
        {
            this.marketsList=new List<Market>();
            this.exchangeList=new List<Exchange>();
            this.assetList=new List<Asset>();
        }
        public void Dispose() { }
    }
}
