using System;

namespace CF.API.Objects
{
    [Serializable]
    public class NonFinancialAccount
    {
        public NonFinancialAccount()
        { 
        }

        public string Caption { get; set;}
        public string Name { get; set; }
        public string MDX { get; set; }
        public string LevelName { get; set; }
        public int LevelDepth { get; set; }


    }
}
