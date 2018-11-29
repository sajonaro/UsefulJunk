using System;

namespace CF.API.Objects
{
    public class FeatureDetails : System.Attribute
    {
        string _display = string.Empty;

        public string Display
        {
            get { return _display; }
            set { _display = value; }
        }
        string _description = string.Empty;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _parent = string.Empty;

        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }


        public FeatureDetails(string displayIn, string descriptionIn, string parent)
        {
            _display = displayIn;
            _description = descriptionIn;
            _parent = parent;
        }
        public FeatureDetails(string displayIn)
        {
            _display = displayIn;
        }

    }
    [FlagsAttribute]
    public enum CF_Feature : ulong
    {

        [FeatureDetails("ClearFinancials", "Can access ClearFinancials. (Must have this feature to sign into application.)", "ClearFinancials")]
        ClearFinancials = 1,
        [FeatureDetails("Multi Entity", "Not working...", "ClearFinancials")]
        Multi_Entity = 2,
        [FeatureDetails("Multi Year", "Not working...", "ClearFinancials")]
        Multi_Year = 4,
        [FeatureDetails("Non Financial", "Not woring...", "ClearFinancials")]
        Non_Financial = 8,
        [FeatureDetails("Standard Metrics", "Always On", "ClearFinancials")]
        Standard_Metrics = 16,
        [FeatureDetails("Metric Builder", "Always On", "ClearFinancials")]
        Metric_Builder = 32,
        [FeatureDetails("Reporting", "Can access Reporting Tab", "ClearFinancials")]
        Reporting = 64,
        [FeatureDetails("Commentary", "Always On in ClearFinancials, Turns on | off the Add / Edit Commentary Option In EAI 2012", "Excel Add In")]
        Commentary = 128,
        [FeatureDetails("Budget Data", "Always On", "ClearFinancials")]
        Budget_Data = 256,
        [FeatureDetails("Income Statement", "Always On", "ClearFinancials")]
        Income_Statement = 512,
        [FeatureDetails("Balance Sheet", "Always On", "ClearFinancials")]
        Balance_Sheet = 1024,
        [FeatureDetails("Cash Flow", "Always On", "ClearFinancials")]
        Cash_Flow = 2048,
        [FeatureDetails("Data Views", "Always On", "ClearFinancials")]
        Data_Views = 4096,
        [FeatureDetails("Library", "Always On", "ClearFinancials")]
        Library = 8192,
        [FeatureDetails("Data Entry", "Can access Actual/Budget Data Entry Tab", "ClearFinancials")]
        Data_Entry = 16384,
        [FeatureDetails("EDL", "Can access Data Integration Tab", "ClearFinancials")]
        EDL = 32768,
        [FeatureDetails("URD" , "Always On", "ClearFinancials")]
        URD = 65536,
        [FeatureDetails("Scorecard", "Can access Scorecard Tab (Note: This only gives user read only access) \n To be able to create scorecards the feature scorecard modify should be enabled.", "ClearFinancials")]
        Scorecard = 131072,
        [FeatureDetails("Planning", "Can access Planning Tab", "ClearFinancials")]
        Planning = 262144,
        [FeatureDetails("Scorecard Modify", "Can create new or modify existing scorecards.", "ClearFinancials")]
        ScorecardModify = 524288,
        [FeatureDetails("Benchmark Data", "Always On", "ClearFinancials")]
        Benchmark_Data = 1048576,
        [FeatureDetails("Currency Conversion", "Always On", "ClearFinancials")]
        Currency_Conversion = 2097152,
        [FeatureDetails("Document Mgmt Excel", "Always On", "ClearFinancials")]
        Document_Mgmt_Excel = 4194304,
        [FeatureDetails("Manage Groups", "Always On", "ClearFinancials")]
        Manage_Groups = 8388608,
        [FeatureDetails("Manage Users", "Always On", "ClearFinancials")]
        Manage_Users = 16777216,
        [FeatureDetails("ExcelAddIn", "Can use Excel Add In.", "Excel Add In")]
        ExcelAddIn = 33554432,
        [FeatureDetails("Portal", "Can use Portal.", "Portal")]
        Portal = 67108864,
        [FeatureDetails(@"iPhone/iPad App", "Can use iPhone or iPad App.", "iPhone/iPad App")]
        IphoneIpad = 134217728,
        [FeatureDetails(@"Excel Data Put", "Can use Excel Data Put in EAI 2012", "Excel Add In")]
        ExcelDataPut = 268435456,
        [FeatureDetails(@"Excel Data Put Modify", "Can Edit/Add new Excel Data Puts", "Excel Add In")]
        ExcelDataPutModify = 536870912,
        [FeatureDetails(@"Approval Workflow", "Enable/Disable Workflow", "Excel Add In")]
        workFlow = 1073741824,
        //dpatel : 8/7/2014
        [FeatureDetails(@"Cap Table", "Enable/Disable CapTable", "Excel Add In")]
        capTable = 2147483648

    }
   
   
  
}
