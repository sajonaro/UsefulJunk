using System;

namespace CF.API.Objects
{
    [Serializable]
    public class CommentarySubSection
    {

        public CommentarySubSection(string name)
        {
            _name = name;
            _data = "";
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _data;

        public string data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
