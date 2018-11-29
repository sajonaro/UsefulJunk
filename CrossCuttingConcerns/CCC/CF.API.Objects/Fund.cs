using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    //[Serializable]
    public class Fund
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Guid _identifier = Guid.NewGuid();
        public Guid identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        public List<Company> companies = new List<Company>();


        
    }
}