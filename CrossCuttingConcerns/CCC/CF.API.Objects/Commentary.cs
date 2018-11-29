using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class Commentary
    {
        private string _periodName;
        List<CommentarySection> _sections;

        public List<CommentarySection> sections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public string periodName
        {
            get { return _periodName; }
            set { _periodName = value; }
        }
        
        public Commentary()
        {
            sections = new List<CommentarySection>();

            for (int i = 1; i < 6; i++)
            {
                sections.Add(new CommentarySection("Section " + i));
            }
        }
    }
}
