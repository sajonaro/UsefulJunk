using System;
using System.Data;  

namespace CF.API.Objects
{
    
    [Serializable]
    public class MetricETL : Metric
    {

        public enum Metric_Grouping
        {
            CY_MONTH, CY_QTR, CY_YTD, FY_MONTH, FY_QTR, FY_YTD, P13_MONTH, P13_YTD
        }

        // 2/18/2014 JDR Added
        public Guid CFCompanyID { get; set; }
        public Guid CFDivisionID { get; set; }
        // 2/18/2014 JDR Added
        public DataTable dtFormula { get; set; }
        // 6/11/2014 JDR Added
        public DataTable dtDimEntity { get; set; }


        /// <summary>
        /// A date which is the last day of the period for Monthly, Quarterly, and YTD metric requests. Used when processed by SQL Server.
        /// </summary>
        public DateTime PeriodEnd { get; set; }

        /// <summary>
        /// Indicates the group/metric type for processing
        /// </summary>
        public Metric_Grouping ProcessingGroup { get; set; }

        /// <summary>
        /// A general use property
        /// </summary>
        public string Tag { get; set; }

        // 1/13/14 JDR: EntityAttributes
        public int PortalCustomerKey { get; set; }
        public int EntityKey { get; set; }
        public Guid EntityCommonKey { get; set; }
        public int AnnualPeriods { get; set; }
        public int ScenarioKey { get; set; }
        public int iCurrencyTypeKey { get; set; }
        public string FiscalCalendarKey { get; set; }
        public DateTime LastCommonClosedPeriod { get; set; }

        public string FYBasedOn { get; set; }
        public int FYStartMonth { get; set; }

        // 1/13/14 JDR: EntityAttributes
        public Guid CMFormulaID { get; set; }
        public string Name { get; set; }
        public string ReportLabel { get; set; }
        public int CF_YTDHandling { get; set; }
        public int CF_FavorableVarianceDirection { get; set; }
        public int CF_DisplayFormat { get; set; }
        public string SortTitle { get; set; }

        #region Date Methods

        /// <summary>
        /// Finds the last day of the year for the selected day's year.
        /// </summary>
        public DateTime LastDayOfYear(int year)
        {
            // 1. Get first of next year.
            DateTime n = new DateTime(year + 1, 1, 1);

            // 2. Subtract one from it.
            return n.AddDays(-1);
        }

        public DateTime GetEndOfQuarter(int Year, int Qtr)
        {
            if (Qtr == 1)    // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 3,
                       DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == 2) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 6,
                       DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == 3) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 9,
                       DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 12,
                       DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

      public  DateTime LastDayOfQuarter(DateTime today)
        {
            int quarter = (today.Month - 1) / 3;
            int lastMonthInQuarter = (quarter + 1) * 3;
            int lastDayInMonth = DateTime.DaysInMonth(today.Year, lastMonthInQuarter);
            return new DateTime(today.Year, lastMonthInQuarter, lastDayInMonth);
        }

        #endregion

    }
}
