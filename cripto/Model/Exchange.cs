using System;
using System.Collections.Generic;
using System.Text;

namespace crypto.Model
{
    public class ExArr
    {
        public Exchange[] exchanges { get; set; }
    }

    public class Exchange
    {
        public string exchange_id { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public float volume_24h { get; set; }
    }
}
