using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class CustomerList
    {
        public List<Customer> customers = new List<Customer>();
    }
}
