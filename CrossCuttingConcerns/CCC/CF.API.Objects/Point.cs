using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
     [Serializable]
    public class Point
    {

        


        string _actual;

        public string actual
        {
          get { return _actual; }
          set { _actual = value; }
        }
        
         string _plan;

        public string plan
        {
          get { return _plan; }
          set { _plan = value; }
        }

        string _period;

        public string period
        {
          get { return _period; }
          set { _period = value; }
        }

    }

    [Serializable]
    public class PointList
    {
        public List<Point> points = new List<Point>();
        string _highValue;
        string _caption;
        bool _overBudgetIsGood = true;
        public string displayFormat = "0";

        public bool overBudgetIsGood
        {
            get { return _overBudgetIsGood; }
            set { _overBudgetIsGood = value; }
        }
        public string caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        string _accountPath;

        public string AccountPath
        {
            get { return _accountPath; }
            set { _accountPath = value; }
        }

        public string highValue
        {
            get { return _highValue; }
            set { _highValue = value; }
        }
        string _lowValue;

        public string lowValue
        {
            get { return _lowValue; }
            set { _lowValue = value; }
        }
    }
}
