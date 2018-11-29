using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
    [Serializable]
    public class Company
    {
        private string _debt;
        public string debt
        {
            get { return _debt; }
            set { _debt = value; }
        }
        private string _assets;
        public string assets
        {
            get { return _assets; }
            set { _assets = value; }
        }

        private string _equity;
        public string equity
        {
            get { return _equity; }
            set { _equity = value; }
        }

        private string _monthsofcash;
        public string monthsofcash
        {
            get { return _monthsofcash; }
            set { _monthsofcash = value; }
        }

        private string _missedLastPeriod;
        public string missedLastPeriod
        {
            get { return _missedLastPeriod; }
            set { _missedLastPeriod = value; }
        }

        private string _missedRevenueLastPeriod;
        public string missedRevenueLastPeriod
        {
            get { return _missedRevenueLastPeriod; }
            set { _missedRevenueLastPeriod = value; }
        }

        private string _revenuePlan;
        public string revenuePlan
        {
            get { return _revenuePlan; }
            set { _revenuePlan = value; }
        }

        private string _ebitdaPlan;
        public string ebitdaPlan
        {
            get { return _ebitdaPlan; }
            set { _ebitdaPlan = value; }
        }

        private string _revenue;
        public string revenue
        {
            get { return _revenue; }
            set { _revenue = value; }
        }

        private string _grossMargin;
        public string grossMargin
        {
            get { return _grossMargin; }
            set { _grossMargin = value; }
        }

        private string _cash;
        public string cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        private string _nibcls;
        public string nibcls
        {
            get { return _nibcls; }
            set { _nibcls = value; }
        }

        private string _ftes;
        public string ftes
        {
            get { return _ftes; }
            set { _ftes = value; }
        }

        private string _ebitda;
        public string ebitda
        {
            get { return _ebitda; }
            set { _ebitda = value; }
        }

        private string _reportingcurrencySymbol;
        public string reportingCurrencySymbol
        {
            get { return _reportingcurrencySymbol; }
            set { _reportingcurrencySymbol = value; }
        }

        private string _functionalcurrencySymbol;
        public string functionalCurrencySymbol
        {
            get { return _functionalcurrencySymbol; }
            set { _functionalcurrencySymbol = value; }
        }

        private string _lccp;
        public string lccp
        {
            get { return _lccp; }
            set { _lccp = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _displayName;
        public string displayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        private string _entityKeyMDX;
        public string EntityKeyMDX
        {
            get { return _entityKeyMDX; }
            set { _entityKeyMDX = value; }
        }

        private Guid _identifier = Guid.NewGuid();
        public Guid identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        private int _annualPeriod = 1;
        public int AnnualPeriod
        {
            get { return _annualPeriod; }
            set { _annualPeriod = value; }
        }

        private Fund _parent;
        public List<Division> divisions = new List<Division>();

        public void setParent(Fund fund) {
            _parent = fund;
        }

        public Fund getParent()
        {
            return _parent;
        }

	    public Guid CFSiteID { get; set; }

	    // 0 - Default metrics, 1-2 Metric Group, 3 Custom list of metrics
        public int metricGroup = 0;
        public List<string[]> customMetrics = new List<string[]>();
        public List<string[]> metricValues = new List<string[]>();
    }
}