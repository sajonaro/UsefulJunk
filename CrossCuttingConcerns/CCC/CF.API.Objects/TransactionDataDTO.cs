using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.API.Objects
{

    public class TransactionDTO
    {
        public EntityData entityData = new EntityData();
    }

    public class CompanyData
    {
        public CompanyData()
        {
        }

        public object KeyCoInvestors { get; set; }
        public object CurrentCapTableDate { get; set; }
        public object CurrentFDSO { get; set; }
        public object GVPartner { get; set; }
        public object GVPercentOwnership { get; set; }

        public object NumofGVBoardObservers { get; set; }
        public object NumofGVBoardSeats { get; set; }
        public object CoStatus { get; set; }
        public object CommonName { get; set; }
        public object CompanyName { get; set; }
        public object CurrentFVPerSh { get; set; }
        public object FEIN { get; set; }
        public object FormerName { get; set; }
        public object FullyExitedCo { get; set; }
        public object FYE { get; set; }
        public object GVAcctgMethod { get; set; }
        public object GVBoardDesignee { get; set; }
        public object GVBoardObserverDesignee { get; set; }
        public object ID { get; set; }
        public object Impaired { get; set; }
        public object Location { get; set; }
        public object Sector { get; set; }
        public object CMReportingStatus { get; set; }
        public object OriginalGVPartner { get; set; }
        public object CreditPartner { get; set; }
        public object CoCurrentStatus { get; set; }
        public object CoOriginalStatus { get; set; }
        public object Ticker { get; set; }
        public object LockupDate { get; set; }
        public object ExitCategory { get; set; }
        public object ExitCategoryDetail { get; set; }
        public object Purchaser { get; set; }
        public object FirstReqdQuarter { get; set; }

        public object Country { get; set; }
        public object Region { get; set; }

    }

    public class EntityData
    {
        public EntityData()
        {
        }

        public CompanyData companyData = new CompanyData();
        public List<TransactionData> transactionData = new List<TransactionData>();

    }


    public class TransactionData
    {
        public TransactionData()
        {
        }

        public string CompanyName { get; set; }
        public string Securities { get; set; }
        public string Date { get; set; }
        public string Fund { get; set; }
        public string Shares { get; set; }
        public string FDPercent { get; set; }
        public string CostShare { get; set; }
        public string CashInvested { get; set; }
        public string PreMoney { get; set; }
        public string TotalRaise { get; set; }
        public string PostMoney { get; set; }
        public string Series_NormalizedForAnalysis { get; set; }
        public string ConversionDiscount { get; set; }
        public string ConversionValuationCap { get; set; }
        public string TransactionDescription { get; set; }
        public string Proceeds { get; set; }
        public string Realized { get; set; }
        public string DistributionFV { get; set; }
        public string DistributionCost { get; set; }

        public string InterestConvertedAccrued { get; set; }
        public string Cost1 { get; set; }
        public string FairValue1 { get; set; }
        public string FollowOn { get; set; }
        public string FullyDilutedSharesAtTransaction { get; set; }
        public string RoundingDirection { get; set; }
        public string CoInvestors { get; set; }
        public string LeadInvestorOfRound { get; set; }
        public string PercentTotalAmountRaisedByLead { get; set; }
        public string InterestRate { get; set; }
        public string MaturityDate { get; set; }
        public string Quarter { get; set; }
        public string CoC { get; set; }
        public string GVPercentOfCurrentRound { get; set; }
        public string CoStatus { get; set; }
        public string Sector { get; set; }

        public string TransactionClass { get; set; }
        public string FundPortfolioCo { get; set; }
        public string OverallPortfolioCo { get; set; }
        public string TransactionID { get; set; }

        public string GVTransactionID { get; set; }
        public string RealizedByPartner { get; set; }
        public string TransactionPartner { get; set; }
        public string GVRegion { get; set; }

    }

}
