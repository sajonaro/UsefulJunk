using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
     [Serializable]
    public class Statement
    {
        public List<Account> accounts = new List<Account>();
        public List<Period> periods = new List<Period>();
    }
}