using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class NonFinancialAccountList : List<NonFinancialAccount>
    {
        
        /// <summary>
        /// A list of NonFinancialAccount objects which are generally processed as a group
        /// </summary>
        public NonFinancialAccountList()
        { }


	}

}

