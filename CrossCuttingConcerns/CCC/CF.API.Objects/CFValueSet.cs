using System.Collections.Generic;

namespace CF.API.Objects
{
    public class CFValueSet
    {
        private List<CFValue> _data = new List<CFValue>();

        public List<CFValue> Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
