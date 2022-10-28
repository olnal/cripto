using crypto.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.Model
{
    internal class AssetsList:GeneralList<Asset>
    {
        private readonly Context _context;
        public AssetsList(Context context)
        {
            _context = context;
        }
        //TODO
        public override Asset Get(string Id)
        {
            return null;
        }
        //TODO
        public override List<Asset> GetAll()
        {
            return null;
        }
    }
}
