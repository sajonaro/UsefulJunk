using System;

namespace CF.API.Objects
{
    
    public class Budget
    {

        private string _name = string.Empty;
        /// <summary>
        /// Budget Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
    }
}
