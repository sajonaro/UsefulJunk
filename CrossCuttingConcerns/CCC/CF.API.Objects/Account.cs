using System.Collections.Generic;

namespace CF.API.Objects
{
    public class Account
    {
        public string name;
        public List<Account> accounts = new List<Account>();
        public List<Period> periods = new List<Period>();

        private Account _parent;

        public Account getParent()
        {
            return _parent;
        }

        public void setParent(Account parent) 
        {
            _parent = parent;
        }

    }
}