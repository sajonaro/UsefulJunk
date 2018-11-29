namespace EnvironmentInfoProviders.Contracts
{
    /// <summary>
    /// Interface responsible for providing environment related urls.
    /// </summary>
    public interface ICfEnvironmentInfoProvider : IEnvironmentInfoProvider
    {
		[RequiresEncryption]
        string SqlCmProdUrl { get; }

		[RequiresEncryption]
        string SqlGoogleProdDatabase { get; }

		[RequiresEncryption]
        string PortalUrl { get; }
		
		[RequiresEncryption]
        string SsasConnectionString { get; }

		[RequiresEncryption]
        string DatabaseConnection { get; }

		[RequiresEncryption]
        string ConnectClearfinancialsUrl { get; }

		[RequiresEncryption]
        string SupportClearmomentum { get; }

		[RequiresEncryption]
        string LocalDomain1 { get; }

		[RequiresEncryption]
        string LocalDomain2 { get; }

		/// <summary>
		/// URL path of API including "API"
		/// e.g. http://adress.com/public-api/
		/// </summary>
		[RequiresEncryption]
		string apiURL { get; }

        /// <summary>
        /// Uses for user domain verification
        /// Projects: CF.ClearFinancials, CM.ActualDataEntry, CM.Administration, CM.AnalyticsModule, CM.DataIntegration (Desktop);
        /// Default value: CLEARMOMENTUM
        /// </summary>
		//TODO: Currently "CLEARMOMENTUM" domain name is used for AD in Desktop
		[RequiresEncryption]
		string DefaultDomainName { get; }

		/// <summary>
		/// Uses for user domain verification
		/// Projects: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CLEARFINANCIALS
		/// </summary>
		[RequiresEncryption]
		string CFDomainName { get; }

        /// <summary>
        /// Uses for user domain verification
        /// Project: CF.ClearFinancials (Desktop);
        /// Default values: CAP;KYIV;TSCRM
        /// </summary>
		[RequiresEncryption]
        string[] DesktopAdditionalDomainNames { get; }

        /// <summary>
        /// Uses for user domain verification
		/// Project: CM.ActualDataEntry (Desktop), ProfessionalServicesApplication (ProfessionalServices);
        /// Default value: CAP
        /// </summary>
		//TODO: Currently "CAP" domain name is used for AD in Desktop
		[RequiresEncryption]
        string DomainName1 { get; }

        /// <summary>
        /// Solution: ClearFinancials4 (Desktop)
        /// Project: CM.EntityRepositoryModule
        /// Usage: \BusinessObjects\Ping.cs(42, 65)
        /// </summary>
        /// <returns>
        /// DNS name of ClearFinancials Web Applications host
        /// </returns>
		[RequiresEncryption]
        string ClearFinancialsWebHost { get; }

        /// <summary>
        /// Project: CM.Shared, CM.ReportingUserDesigner
        /// Default value: https://cfwebs.clear-momentum.com/HelpDocuments/PDF/UserReportDesignerHelpGuide.pdf
        /// </summary>
		[RequiresEncryption]
        string UserReportDesignerHelpGuide { get; }

	}
}