using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class CommentarySection
    {
        private string _name;
        private string _periodName;

        public string periodName
        {
            get { return _periodName; }
            set { _periodName = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<CommentarySubSection> _subSections;

        public List<CommentarySubSection> subSections
        {
            get { return _subSections; }
            set { _subSections = value; }
        }


        public CommentarySection(string name)
        {
            _name = name;
            _periodName = "N/A";
            subSections = new List<CommentarySubSection>();

            for (int i = 1; i < 11; i++) {
                subSections.Add(new CommentarySubSection("User Defined " + i));
            }
        }
    }
}
