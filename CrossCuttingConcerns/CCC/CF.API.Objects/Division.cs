using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class Division
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


        private object _parent;

        public List<Year> years = new List<Year>();
        public List<Division> divisions = new List<Division>();

        public void setParent(object fund)
        {
            _parent = fund;
        }

        public object getParent()
        {
            return _parent;
        }
    }
}