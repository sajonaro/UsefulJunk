using System.Text.RegularExpressions;
using System;

namespace CF.API.Objects
{

    public enum DataQueryTypeEnum 
    {
        Undefined,

        [AccountRootPath("\\QVAL\\CAPTABLE")]
        CapTable_SI = 100, //Investors/Totals data
        
        [AccountRootPath("\\QVAL\\SCENARIOS")]
        CapTable_SI_SCENARIOS = 101, //Scenarios
        
        [AccountRootPath("\\DETAILS")]
        CapTable_SI_SCENARIODETAILS = 102, //Scenario Details

        [AccountRootPath("\\QVAL\\VALUATIONS")]
        CapTable_SI_VALUATIONS = 103, //Valuations

        [AccountRootPath("\\QVAL\\CAPTABLE\\TERMS")]
        CapTable_SI_TERMS = 104, //Terms

        [AccountRootPath("\\QVAL\\CAPTABLE\\SERIES")]
        CapTable_SI_SERIES = 105, //Series

         [AccountRootPath("\\WATERFALLS")]
        CapTable_SI_SCENARIOWATERFALLS = 106, //Scenario Waterfalls //Note: This was initial cut before we knew how waterfall data was going to be integrated.

         [AccountRootPath("\\QVAL\\WATERFALLS")]
         CapTable_SI_WATERFALLS = 107, //Waterfalls

    }


    public interface IDataQuery
    {
        string Key { get; set; }
        string EntityName { get; set; }
        string DataPath { get; set; }
        string Period { get; set; }
        DataQueryTypeEnum QueryType { get; }
        object Value { get; set; }

    }

   // [Serializable]
    public class DataQuery : IDataQuery 
	{

        public DataQuery()
		{
		}

		public string Key				{ get; set;}
		public string EntityName		{ get; set; }
        public string DataPath { get; set;  }
        public string Period { get; set; }

        public string WaterfallStartValue { get; set; }
        public string WaterfallExitValue { get; set; }

		public DataQueryTypeEnum QueryType		
		{
			get
			{
				DataQueryTypeEnum retEnum = DataQueryTypeEnum.Undefined;

				if (!string.IsNullOrEmpty(DataPath))
				{
          
                    if (Regex.IsMatch(DataPath, @"^\\QVAL\\CAPTABLE\\TERMS", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI_TERMS;
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\QVAL\\CAPTABLE\\SERIES", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI_SERIES;
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\QVAL\\CAPTABLE\\", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI;
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\QVAL\\SCENARIOS\\", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI_SCENARIOS;
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\QVAL\\VALUATIONS\\", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI_VALUATIONS;
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\QVAL\\WATERFALLS\\", RegexOptions.IgnoreCase))
                    {
                        retEnum = DataQueryTypeEnum.CapTable_SI_WATERFALLS;
                    }
                }
			
				return retEnum;
			}
		}
		
		public object Value				{ get; set; }

	}

}