using System;
using System.Collections.Generic;
using System.Text;

namespace cripto.Model
{

    public abstract class GeneralList<T>
    {
        public abstract T Get(string Id);
        public abstract List<T> GetAll();
    }
}
