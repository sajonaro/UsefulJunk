

using System.Collections.Generic;
namespace CF.API.Objects
{
    public class FinancialDTO 
	{
		public object		balanceSheet		= string.Empty;
		public object		incomeStatement		= string.Empty;
		public Metrics		metrics				= new Metrics();
		public object		nonFinancials		= string.Empty;

		/*
			For Step 3 - Add Financial data points. Robin has instructed us to use the following:
			- trailing 5 quarters of data from the last closed period in CF
			- quarterly data only
			- account detail that is common across ALL companies (I believe this would mean down to Level 2 for IS, Level 3 for BS, and all Non-Financials).
			- Additional Metrics/Calculations Below:
			Cash and ST Investments (public metric)
			GV Cash Burn Reporting Frequency (public metric)
			GV Cash Burn Rate (public metric)
			GV Monthly Cash Burn Rate - calculated off the two metrics above, see Nate for calc.
			Total Debt (public metric)
			*/
		}

		public class GVPeriodMetric
		{
			public GVPeriodMetric()
			{
			}

			public string period	= null;
			public object value		= null;	

		}

		

		public class Metrics 
		{
			public List<GVPeriodMetric> CashAndSTInvestments {get; set;}
			public List<GVPeriodMetric> CashBurnRate {get; set;}
			public List<GVPeriodMetric> CashBurnReportingFrequency {get; set;}
			public List<GVPeriodMetric> CalculatedCashOutDate {get; set;}
			public List<GVPeriodMetric> CashMonthlyBurnRate {get; set;}
			public List<GVPeriodMetric> TotalDebt {get; set;}
		}

}

