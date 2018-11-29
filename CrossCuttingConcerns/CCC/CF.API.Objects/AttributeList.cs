using System.Collections.Generic;

namespace CF.API.Objects
{
    //[Serializable]
    public class AttributeList
    {
        private string _timeTakentoRequestData = "";
        public string TimeTakentoRequestData
        {
            get { return _timeTakentoRequestData; }
            set { _timeTakentoRequestData = value; }
        } 

        public List<Attribute> attributes = new List<Attribute>();
    }
}
