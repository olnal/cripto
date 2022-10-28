using cripto.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{
    internal class MarketsList: GeneralList<Market>
    {
        private readonly Context _context;
        public MarketsList(Context context)
        {
            _context = context;
        }
        //TODO
        public override Market Get(string Id)
        {
            return null;
        }
        //TODO
        public override List<Market> GetAll()
        {
            return null ;
        }
    }
}
