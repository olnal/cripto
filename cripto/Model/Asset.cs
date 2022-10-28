using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{
    internal class Asset
    {
        public string assetId { get; set; }
        public string name { get; set; }
        public double volume_24h { get; set; }
        public double change_1h { get; set; }
        public double change_24h { get; set; }
        public double change_7d { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
