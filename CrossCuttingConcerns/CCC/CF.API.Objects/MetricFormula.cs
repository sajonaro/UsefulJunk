using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
	
	public enum MetricFormulaType {
		Undefined = 0,
		Standard = 1,
		UserDefined = 2
	}


   
	public class MetricFormula
	{
        /// <summary>
        /// Contains properties of a Metric from ClearFinancials50_Prod.dbo.CMFormula
        /// </summary>
        public MetricFormula()
        { }


		public Guid CMFormulaID				{get; set;}
		public Guid CFSiteID				{get; set;}
		public Guid FundID					{get; set;}
		public Guid CFCompanyID				{get; set;}
		public Guid CFDivisionID			{get; set;}
		//public Guid? ProformaModelID		{get; set;}
		public Guid OwnerID					{get; set;}
		public string Name					{get; set;}
		public string Formula				{get; set;}
		public int?	DataType				{get; set;}
		public int? DataUnit				{get; set;}
		public int? YTDHandling				{get; set;}
		public DateTime DateAdded			{get; set;}
		public DateTime DateChanged			{get; set;}
		public Guid AddedBy					{get; set;}
		public Guid ChangedBy				{get; set;}
		public byte[] ChangeStamp			{get; set;}
		public int? MetricUserVisibility	{get; set;}
		public int? MetricClass				{get; set;}
		public int? MetricEntityScope		{get; set;}
	 	public string ThresholdLine1		{get; set;}
		public string ThresholdLine2		{get; set;}
		public decimal? ThresholdValue1		{get; set;}
		public decimal? ThresholdValue2		{get; set;}
		public string ReportLabel			{get; set;}
		public int? DisplayOnStandardMetricGrid		{get; set;}
        public int? CF_FavorableVarianceDirection { get; set; }     /// [LessThanTarget = 0, GreaterThanTarget = 1, Default = 2]
        
		public string Description					{get; set;}
		public Guid? CMFormulaOrganizationUnitsID	{get; set;}
	
		public MetricFormulaType FormulaType {get; set;}

		//private string _displayFormulaName = string.Empty;

		//public string DisplayFormulaName
		//{
		//	get 
		//	{
		//		if (FormulaType == MetricFormulaType.UserDefined || (_displayFormulaName != null && _displayFormulaName.Length > 0))
		//			return _displayFormulaName;
		//		else
		//			return Name;
		//	}
		//	set
		//	{
				
		//	}	
		//}


	}

	public class MetricFormulaNameComparer : IComparer<MetricFormula>
	{
		public int Compare( MetricFormula x,  MetricFormula y)
		{
			if (x == null)
			{
				if (y == null)
					return 0;
				else
					return -1;
			}
			else
			{
				if (y == null)
					return 1;
				else
				{
					int retval = x.Name.CompareTo(y.Name);

					if (retval != 0)
					{
						return retval;
					}
					else
					{
						return x.Name.CompareTo(y.Name);
					}
				}
			}
		}
	}

	public class MetricFormulaReportLabelComparer : IComparer<MetricFormula>
	{
		public int Compare( MetricFormula x,  MetricFormula y)
		{
			if (x == null)
			{
				if (y == null)
					return 0;
				else
					return -1;
			}
			else
			{
				if (y == null)
					return 1;
				else
				{
					int retval = x.Name.CompareTo(y.Name);

					if (retval != 0)
					{
						return retval;
					}
					else
					{
						return x.Name.CompareTo(y.Name);
					}
				}
			}
		}
	}

}
