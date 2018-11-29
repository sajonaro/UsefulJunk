using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    
    public class BudgetList
    {
        private string _timeTakentoRequestData = "";
        public string TimeTakentoRequestData
        {
            get { return _timeTakentoRequestData; }
            set { _timeTakentoRequestData = value; }
        } 

        public List<Budget> budgets = new List<Budget>();
    }
}
