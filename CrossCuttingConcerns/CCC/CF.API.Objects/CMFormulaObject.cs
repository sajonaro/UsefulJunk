using System;
using System.Data;

namespace CF.API.Objects
{
    public class CMFormula
    {

        public enum Status
        {
            None, Updated, New, Deleted
        }

        /// <summary>
        /// 6/19/09 JDR: Renamed UserDefined to AsCalculated.  This will be used
        ///     to indicate how the YTD value of a StandardRatio is determined.
        ///     See Also: RatioObject.
        /// 1/30/09 rwb : added AccountValues
        ///                     AccountValues = 
        ///                                     for IS + BS = values in dtCurrentDate  
        ///                                     for TTPSum + TTPAvg = to be determined
        /// 
        /// Default is SUM_P1_P12.  Indicates how the YTD Total Column is computed 
        /// [ UserDefined, LastPeriod, LastPeriodWithData, SUM_P1_P12 | PeriodAverage | NoYTDValue] 
        /// See: DataTable_Enum() below
        /// Note: enum ordinal int values stored in DB
        /// </summary>
        
        public enum CF_YTDHandling
        {
            AsCalculated, LastPeriod, LastPeriodWithData, SUM_P1_P12, PeriodAverage, NoYTDValue, YTD_AccountValues
        }

        /// <summary>
        /// Indicates the type of data contained in the row [ Numeric | String ]
        /// Default is Numeric.  Currently, only numeric is supported
        /// Note: enum ordinal int values stored in DB
        /// </summary>
        /// 
        
        public enum CF_DataType
        {
            Numeric, String // Default, Numeric, String
        }

        /// <summary>
        /// 7/8/11 JDR:  Used in Cube as well.  See Cube Calculations Script
        /// 8/14/09 JDR: Added [NONE] so I can tell when to set DB Field to DBNull
        /// 8/14/09 JDR: Renamed to CF_DisplayFormat
        /// 7/28/08 rwb - added ALPHA type
        /// 10/27/09 JDR: Added additional comments
        /// 7/28/08 rwb - added ALPHA type
        /// Default will be "N0".  
        /// Indicates the DisplayFormat for numeric the data in the row [C, N0, N1, N2, P0, P1, P2, C0, ALPHA, NONE]
        /// 
        /// Indicates the DisplayFormat for numeric the data in the row [C, N0, N1, N2, P0, P1, P2, C0, ALPHA]
        /// Int value corresponds to ordinal position in _editorsValueList (CF_Gridbase). Exception is ALPHA.
        /// ALPHA Int value (8) requires an editor in index 11 of _editorsValueList (CF_Gridbase)
        /// Please See: _editorsValueList (CF_Gridbase) when making changes to this list
        /// </summary>
        
        public enum CF_DisplayFormat
        {
            C, N0, N1, N2, P0, P1, P2, C0, ALPHA, NONE
        }


        public enum CF_MetricEntityScope
        {
            None, Global, GlobalRestricted, GlobalAndDataLimitedTo, CompanyRestricted, CompanyDataLimited
        }

        /// <summary>
        /// 8/24/09 JDR: Added Default = 2, so we can leave DB field value NULL where appropriate
        /// Indicates the direction between Actual and Plan data that represents a favorable variance.
        /// [LessThanTarget = 0, GreaterThanTarget = 1, Default = 2]
        /// </summary>
        
        public enum CF_FavorableVarianceDirection
        {
            LessThanTarget = 0, GreaterThanTarget = 1, Default = 2
        }


        private Guid _cmFormulaID = Guid.Empty;
        public Guid CMFormulaID
        {
            get { return _cmFormulaID; }
            set { _cmFormulaID = value; }
        }

        private Guid _cMFormulaClassID = new Guid("00000000-0000-0000-0000-000000000001");
        public Guid CMFormulaClassID
        {
            get { return _cMFormulaClassID; }
            set { _cMFormulaClassID = value; }
        }

        private Status _cfStatus = Status.None;
        public Status CFStatus
        {
            get { return _cfStatus; }
            set { _cfStatus = value; }
        }

        //private Guid _owerID = Guid.Empty;
        //public Guid OwnerID
        //{
        //    get { return _owerID; }
        //    set { _owerID = value; }
        //}
        public enum CF_MetricUserVisibility
        {
            None, Public, Private, PlanningPublic, PlanningPrivate, PlanSpecific
        }

        private CF_MetricUserVisibility _metricUserVisibility = CF_MetricUserVisibility.Public;
        public CF_MetricUserVisibility MetricUserVisibility
        {
            get { return _metricUserVisibility; }
            set { _metricUserVisibility = value; }
        }

        /// <summary>
        /// 6/4/09 JDR: Added Scorecard, Planning
        /// Metric Class can be [ None, UserDefined, Standard, DashBoard, Capitalization, CrossPlot, Scorecard, Planning ]
        /// Metric Class applies to CMFormula.MetricClass in the database and dsFormula,dsDashBoard typed datasets
        /// 9/4/08  rwb : added
        /// 02/25/09 rwb : added crossplot  
        /// </summary>
        public enum CF_MetricClass
        {
            None, UserDefined, Standard, DashBoard, Capitalization, CrossPlot, Scorecard, Planning
        }
        private CF_MetricClass _metricClass = CF_MetricClass.UserDefined;
        public CF_MetricClass MetricClass
        {
            get { return _metricClass; }
            set { _metricClass = value; }
        }

        private string siteName = string.Empty;
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }

        private string _cFSiteID = string.Empty;
        public string CFSiteID
        {
            get { return _cFSiteID; }
            set { _cFSiteID = value; }
        }


        private string _cfCompanyID = string.Empty;

        public string CFCompanyID
        {
            get { return _cfCompanyID; }
            set { _cfCompanyID = value; }
        }
      

        private string _companyName = string.Empty;
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _formula = string.Empty;
        public string Formula
        {
            get { return _formula; }
            set { _formula = value; }
        }


        private bool _displayOnStandardMetricGrid = true;
        public bool DisplayOnStandardMetricGrid
        {
            get { return _displayOnStandardMetricGrid; }
            set { _displayOnStandardMetricGrid = value; }
        }

        private string _description = string.Empty;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        private CF_DataType _dataType = CF_DataType.Numeric;
        public CF_DataType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private CF_YTDHandling _yTDHandling = CF_YTDHandling.SUM_P1_P12;
        public CF_YTDHandling YTDHandling
        {
            get { return _yTDHandling; }
            set { _yTDHandling = value; }
        }

        private CF_DisplayFormat _dataUnit = CF_DisplayFormat.N0;
        public CF_DisplayFormat DataUnit
        {
            get { return _dataUnit; }
            set { _dataUnit = value; }
        }

        private CF_FavorableVarianceDirection _favorableVarianceDirection = CF_FavorableVarianceDirection.Default;

        public CF_FavorableVarianceDirection FavorableVarianceDirection
        {
            get { return _favorableVarianceDirection; }
            set { _favorableVarianceDirection = value; }
        }

        private CF_MetricEntityScope _metricEntityScope = CF_MetricEntityScope.Global;
        public CF_MetricEntityScope MetricEntityScope
        {
            get { return _metricEntityScope; }
            set { _metricEntityScope = value; }
        }


        private DateTime _dateAdded = DateTime.Now;
        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; }
        }

        private DateTime _dateChanged = DateTime.Now;
        public DateTime DateChanged
        {
            get { return _dateChanged; }
            set { _dateChanged = value; }
        }

        private string _addedby = string.Empty;

        public string Addedby
        {
            get { return _addedby; }
            set { _addedby = value; }
        }

        private string _changedBy = string.Empty;

        public string ChangedBy
        {
            get { return _changedBy; }
            set { _changedBy = value; }
        }

        /// <summary>
        /// 8/24/09 JDR: Added support for CF_FavorableVarianceDirection
        /// //8/13/09 JDR: Remove LastPeriod from output
        /// 8/14/09 JDR: Set new CF_DisplayFormat.NONE to be excluded from list
        /// 8/13/09 JDR: Remove LastPeriod from output
        /// Returns a DataTable with two fields (Key, Value), containing the values of the specified Enum.  
        /// Key contains the string part of the enum and Value contains the numeric value of the Enum.
        /// </summary>
        /// <returns></returns>
        public static DataTable DataTable_Enum(Type enumType)
        {
            using (DataTable dtDataTypes = new DataTable("DataType"))
            {
                dtDataTypes.Columns.Add("Key", typeof(string));
                dtDataTypes.Columns.Add("Value", typeof(int));

                Type DataTypes = enumType;
                int enumValue = 0;
                string displayString;
                foreach (string s in Enum.GetNames(DataTypes))  //Not Sorted
                {


                    if (enumType == typeof(CF_DisplayFormat)) // Special handling for this Enum
                    {
                        displayString = "Unknown Format";

                        if (s == "C")
                            displayString = "Currency ($9,999.99)";
                        if (s == "C0")
                            displayString = "Currency ($9,999)";
                        else if (s == "N0")
                            displayString = "Numeric (9,999)";
                        else if (s == "N1")
                            displayString = "Numeric (9,999.9)";
                        else if (s == "N2")
                            displayString = "Numeric (9,999.99)";
                        else if (s == "P0")
                            displayString = "Percent (9,999%)";
                        else if (s == "P1")
                            displayString = "Percent (9,999.9%)";
                        else if (s == "P2")
                            displayString = "Percent (9,999.99%)";
                        else if (s == "ALPHA")
                            displayString = "String";
                        else if (s == "NONE")
                            continue;

                        //if (s == "N") // make this the default
                        //    dtDataTypes.Rows.Add(new object[] { "Default", enumValue });

                        dtDataTypes.Rows.Add(new object[] { displayString, enumValue++ });
                    }
                    else if (enumType == typeof(CF_YTDHandling)) // Special handling for this Enum
                    {
                        displayString = "Unknown Format";

                        if (s == "AsCalculated")                        //6/19/09 JDR: Renamed from user defined
                        {    //continue; // Ignor this one for now
                            displayString = "As Calculated";
                            enumValue = 0;
                        }
                        else if (s == "LastPeriod")
                        {
                            continue;   // Ignor this one for now //8/13/09 JDR:
                            //displayString = "Last Period";
                            //enumValue = 1;
                        }
                        else if (s == "LastPeriodWithData")
                        {
                            displayString = "Last Period With Data";
                            enumValue = 2;
                        }
                        else if (s == "SUM_P1_P12")
                        {
                            displayString = "SUM Period 1 through 12";
                            enumValue = 3;
                        }
                        else if (s == "PeriodAverage")
                        {
                            displayString = "Period Average";
                            enumValue = 4;
                        }
                        else if (s == "NoYTDValue")
                        {
                            displayString = "No YTD Value";
                            enumValue = 5;
                        }
                        else if (s == "YTD_AccountValues")  // 02/02/09 rwb : added YTD_Account Values
                        {
                            displayString = "YearToDate Account Values";
                            enumValue = 6;
                        }

                        // if (s == "SUM_P1_P12") // make this the default
                        //     dtDataTypes.Rows.Add(new object[] { "Default", enumValue });

                        dtDataTypes.Rows.Add(new object[] { displayString, enumValue });
                    }
                    else if (enumType == typeof(CF_FavorableVarianceDirection)) // Special handling for this Enum
                    {
                        displayString = "Default";

                        if (s == "GreaterThanTarget")
                        {    //continue; // Ignor this one for now
                            displayString = "Actual Greater than Target";
                            enumValue = 1;
                        }
                        if (s == "LessThanTarget")
                        {    //continue; // Ignor this one for now
                            displayString = "Actual Less than Target";
                            enumValue = 0;
                        }
                        if (s == "Default")
                        {    //continue; // Ignor this one for now
                            displayString = "Default (Greater than Target) ";
                            enumValue = 2;
                        }
                        dtDataTypes.Rows.Add(new object[] { displayString, enumValue });
                    }
                    else
                    {
                        dtDataTypes.Rows.Add(new object[] { s, enumValue++ });
                    }
                }

                DataTable dtReturn = dtDataTypes.Clone();
                DataRow[] draReturn = dtDataTypes.Select("", "Key");
                foreach (DataRow dr in draReturn)
                {
                    dtReturn.Rows.Add(dr.ItemArray);
                }

                return dtReturn;
            }
        }


    }
}
