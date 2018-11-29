using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
     [Serializable]
    public class Year
    {
        public string name;
        public List<StatementDetail> statements = new List<StatementDetail>();

        public Year(string value)
        {
            name = value;
        }

        public Year()
        {
        }
    }
}