using cripto.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{
    internal class ExchangesList:GeneralList<Exchange>
    {
        private readonly Context _context;
        public ExchangesList(Context context)
        {
            _context = context;
        }
        //TODO
        public override Exchange Get(string Id)
        {
            return null;
        }
        //TODO
        public override List<Exchange> GetAll()
        {
            return null;
        }
    }
}
