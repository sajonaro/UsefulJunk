using System;

namespace CF.API.Objects
{
    [Serializable]
    public class StatementValue
    {
        string _value = null;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

    }
}
