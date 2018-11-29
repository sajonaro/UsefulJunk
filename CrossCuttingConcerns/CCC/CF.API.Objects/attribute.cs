using System;

namespace CF.API.Objects
{
    //[Serializable]
    public class Attribute
    {
        private string _key = string.Empty;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _attributeKey = string.Empty;
        public string AttributeKey
        {
            get { return _attributeKey; }
            set { _attributeKey = value; }
        }

        private string _parentAttributeKey = string.Empty;
        public string ParentAttributeKey
        {
            get { return _parentAttributeKey; }
            set { _parentAttributeKey = value; }
        }

        private string _dateKey = string.Empty;
        public string DateKey
        {
            get { return _dateKey; }
            set { _dateKey = value; }
        }


        private string _attributeName;
        public string AttributeName
        {
            get { return _attributeName; }
            set { _attributeName = value; }
        }

        private string _scenarioName;
        public string ScenarioName
        {
            get { return _scenarioName; }
            set { _scenarioName = value; }
        }

        private int _cF_YTDHandling = 0;
        public int CF_YTDHandling
        {
            get { return _cF_YTDHandling; }
            set { _cF_YTDHandling = value; }
        }

        private int _cF_FavorableVarianceDirection = 0;
        public int CF_FavorableVarianceDirection
        {
            get { return _cF_FavorableVarianceDirection; }
            set { _cF_FavorableVarianceDirection = value; }
        }

        private int _cf_DisplayFormat = 0;
        public int Cf_DisplayFormat
        {
            get { return _cf_DisplayFormat; }
            set { _cf_DisplayFormat = value; }
        }

        private int _cF_DataType = 0;
        public int CF_DataType
        {
            get { return _cF_DataType; }
            set { _cF_DataType = value; }
        }
              

        private string _attributeValue;
        public string AttributeValue
        {
            get { return _attributeValue; }
            set { _attributeValue = value; }
        }

        private int _currencyTypeKey;

        public int CurrencyTypeKey
        {
            get { return _currencyTypeKey; }
            set { _currencyTypeKey = value; }
        }

        private DateTime _excelUpdateDate = DateTime.MinValue;
        public DateTime ExcelUpdateDate
        {
            get { return _excelUpdateDate; }
            set { _excelUpdateDate = value; }
        }

        private string _updatedBy;
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }

        private int _displayOrder = 1;

        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        
    }
}
