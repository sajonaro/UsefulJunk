using System;

namespace CF.API.Objects
{
    public class iPut
    {

        private string _activeUpload = "1";
        public string ActiveUpload
        {
            get { return _activeUpload; }
            set { _activeUpload = value; }
        }


        private string _iputID = Guid.Empty.ToString();
        public string iPutID
        {
            get { return _iputID; }
            set { _iputID = value; }
        }

        private string _entityName = string.Empty;
        public string EntityKey
        {
            get { return _entityName; }
            set { _entityName = value; }
        }

        private string _entityMDX = string.Empty;
        public string EntityMDX
        {
            get { return _entityMDX; }
            set { _entityMDX = value; }
        }

        private string _scenarioName = string.Empty;
        public string ScenarioName
        {
            get { return _scenarioName; }
            set { _scenarioName = value; }
        }

        private string _parentAccountName = string.Empty;
        public string ParentAccountName
        {
            get { return _parentAccountName; }
            set { _parentAccountName = value; }
        }

        private string _parentAccountPath = string.Empty;
        public string ParentAccountPath
        {
            get { return _parentAccountPath; }
            set { _parentAccountPath = value; }
        }

        private string _accountName = string.Empty;
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }


        private string _currencyType = string.Empty;
        public string CurrencyType
        {
            get { return _currencyType; }
            set { _currencyType = value; }
        }

        private string _cF_CurrencyConversionMode = string.Empty;
        public string CF_CurrencyConversionMode
        {
            get { return _cF_CurrencyConversionMode; }
            set { _cF_CurrencyConversionMode = value; }
        }
        private string _period = string.Empty;
        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        private string _periodMDX = string.Empty;
        public string PeriodMDX
        {
            get { return _periodMDX; }
            set { _periodMDX = value; }
        }

        private string _amount = string.Empty;
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        private string _favorableVarianceDirection = "";
        public string FavorableVarianceDirection
        {
            get { return _favorableVarianceDirection; }
            set { _favorableVarianceDirection = value; }
        }

        private string _dataUnit = "";
        public string DataUnit
        {
            get { return _dataUnit; }
            set { _dataUnit = value; }
        }

        private string _yTDHandling = "";
        public string YTDHandling
        {
            get { return _yTDHandling; }
            set { _yTDHandling = value; }
        }

        private string _dataType = "";
        public string DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private int _displayOrder = 1;
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

    }
}
