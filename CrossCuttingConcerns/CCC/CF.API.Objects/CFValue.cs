using System;

namespace CF.API.Objects
{
    public class CFValue
    {
        private string _key;

        private Boolean _hasBeenSet = false;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private object _value;

        public Boolean HasBeenSet()
        {
            return _hasBeenSet;
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; _hasBeenSet = true; }
        }

    }
}
