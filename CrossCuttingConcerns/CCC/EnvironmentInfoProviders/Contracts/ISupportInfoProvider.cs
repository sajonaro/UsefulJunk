namespace EnvironmentInfoProviders.Contracts
{
    /// <summary>
    /// Interface responsible for providing support team info.
    /// </summary>
    public interface ISupportInfoProvider : IEnvironmentInfoProvider
    {
        /// <summary>
		/// Projects: CM.Shared (Desktop)
        /// Default value: jdroach@clearmomentum.com
        /// </summary>
		[RequiresEncryption]
        string DesktopEmail { get; }

        /// <summary>
		/// Projects: CM.Shared (Desktop)
        /// Default value: (585)393-1734
        /// </summary>
		[RequiresEncryption]
        string DesktopPhone { get; }

		/// <summary>
		/// Projects: ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: support@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string ProfessionalServicesEmail { get; }

		/// <summary>
		/// Projects:  ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: helpdesk@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string HelpDeskEmail { get; }

		/// <summary>
		/// Projects:  ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: administrator@clearfinancials.com
		/// </summary>
		[RequiresEncryption]
		string AdministratorEmail { get; }

		/// <summary>
		/// Projects:  ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: dataalerts@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string DataAlertsEmail { get; }

		/// <summary>
		/// Projects:  ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: datacenter@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string DataCenterEmail { get; }

		/// <summary>
		/// Projects:  ProfessionalServicesApplication (ProfessionalServices)
		/// Default value: Engineering@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string EngineeringEmail { get; }

        /// <summary>
        /// Projects:  CM.ClearFinancialsCommon.PL (Desktop)
        /// Default value: http://www.clearmomentum.com/Support/
        /// </summary>
		[RequiresEncryption]
        string SupportUrl { get; }

        /// <summary>
        /// Projects:  CM.ClearFinancialsCommon.PL (Desktop)
        /// Default value: www.clearmomentum.com/releasenotes2010/
        /// </summary>
		[RequiresEncryption]
        string ReleaseNotesUrl { get; }

        /// <summary>
        /// Projects: ProfessionalServicesApplication (ProfessionalServices)
        /// Default value: alerts@clearmomentum.com
        /// </summary>
		[RequiresEncryption]
        string AlertEmail { get; }
    }
}