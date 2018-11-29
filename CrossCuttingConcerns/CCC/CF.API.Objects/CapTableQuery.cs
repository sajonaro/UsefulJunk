using System.Text.RegularExpressions;

namespace CF.API.Objects
{

    public enum CapTableQueryTypeEnum
    {
        Undefined,
        CompanyData,
        NoteInvestments,
        SeriesData,
        //CompanyData_IndexQuery,
        //NoteInvestments_IndexQuery,
        //SeriesData_IndexQuery,
        NoteInvestments_FundQuery,
        SeriesData_HolderQuery,
        CompanyData_HolderQuery,
    }
    

   // [Serializable]
	public class CapTableQuery
	{

		public CapTableQuery()
		{
		}

		public string Key				{ get; set;}
		public string EntityName		{ get; set; }
		public string DataPath			{ get; set; }

		public string MatchExpression	{ get; set;}
		public string IndexPosition		{ get; set;}

		public CapTableQueryTypeEnum QueryType		
		{
			get
			{
				/*
				The DataPath property should always take one of the following forms depicted below:
					1.) \CAPTABLE\COMPANY DATA
					2.) \CAPTABLE\NOTE INVESTMENTS
					3.) \CAPTABLE\SERIES DATA
				 
				Derive the query type from the data path 
				
				*/

				CapTableQueryTypeEnum retEnum = CapTableQueryTypeEnum.Undefined;

				if (!string.IsNullOrEmpty(DataPath))
				{
                   
                    if (Regex.IsMatch(DataPath, @"^\\CAPTABLE\\COMPANY DATA", RegexOptions.IgnoreCase))
                    {
                        retEnum = (!string.IsNullOrEmpty(MatchExpression) && !string.IsNullOrEmpty(IndexPosition) ? CapTableQueryTypeEnum.CompanyData_HolderQuery : CapTableQueryTypeEnum.CompanyData);
					}
                    else if (Regex.IsMatch(DataPath, @"^\\CAPTABLE\\NOTE INVESTMENTS", RegexOptions.IgnoreCase))
                    {
                        retEnum = (!string.IsNullOrEmpty(MatchExpression) && !string.IsNullOrEmpty(IndexPosition) ? CapTableQueryTypeEnum.NoteInvestments_FundQuery : CapTableQueryTypeEnum.NoteInvestments);
                    }
                    else if (Regex.IsMatch(DataPath, @"^\\CAPTABLE\\SERIES DATA", RegexOptions.IgnoreCase))
                    {
                        retEnum = (!string.IsNullOrEmpty(MatchExpression) && !string.IsNullOrEmpty(IndexPosition) ? CapTableQueryTypeEnum.SeriesData_HolderQuery : CapTableQueryTypeEnum.SeriesData);
                    }
                }
			
				return retEnum;
			}
		}
		
		public object Value				{ get; set; }

	}

	//public class CapTableIndexQuery : CapTableQuery
	//{

	//	public CapTableIndexQuery() : base()
	//	{
	//	}

	//	public string MatchExpression { get; set;}

	//	public override CapTableQueryTypeEnum QueryType		
	//	{
	//		get
	//		{
	//			/*
	//			The DataPath property should always take one of the following forms depicted below:
	//				1.) \CAPTABLE\COMPANY DATA
	//				2.) \CAPTABLE\NOTE INVESTMENTS
	//				3.) \CAPTABLE\SERIES DATA
				 
	//			Derive the query type from the data path 
				
	//			*/

	//			CapTableQueryTypeEnum retEnum = CapTableQueryTypeEnum.Undefined;

	//			if (!string.IsNullOrEmpty(DataPath))
	//			{
	//				//Example: "\CAPTABLE\COMPANY DATA\CAPTABLEASOFDATE"
	//				string tmp	= DataPath;
	//				tmp			= tmp.Replace(@"\CAPTABLE\","");
	//				tmp			= tmp.Replace(@"CAPTABLE\","");	//Just in case handle scenarios where the slash may not be present!
					
	//				if (tmp.Contains("\\"))
	//					tmp			= tmp.Substring(0,tmp.IndexOf("\\"));

	//				switch (tmp.ToUpper())
	//				{
	//					case "COMPANY DATA":
	//						retEnum = CapTableQueryTypeEnum.CompanyData_IndexQuery;
	//						break;
						
	//					case "NOTE INVESTMENTS":
	//						retEnum = CapTableQueryTypeEnum.NoteInvestments_IndexQuery;
	//						break;

	//					case "SERIES DATA":
	//						retEnum = CapTableQueryTypeEnum.SeriesData_IndexQuery;
	//						break;
						
	//					default:
	//						retEnum = CapTableQueryTypeEnum.Undefined;
							
	//						break;
	//				}

	//			}
			
	//			return retEnum;
	//		}
	//	}
		
	//}
}