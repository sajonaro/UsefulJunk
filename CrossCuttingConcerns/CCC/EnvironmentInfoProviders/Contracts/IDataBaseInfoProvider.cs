namespace EnvironmentInfoProviders.Contracts
{
    /// <summary>
    /// Interface providing properties that contain database info
    /// </summary>
    public interface IDatabaseInfoProvider : IEnvironmentInfoProvider
	{
		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CMPROD-SQL1.clearfinancials.com
		/// </summary>
		[RequiresEncryption]
		string ProdDatabaseServer { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CMPROD-SQLG.clearfinancials.com\Google
		/// </summary>
		[RequiresEncryption]
		string ProdGoogleDatabaseServer { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CMCORP-SQL-DEV1.clearfinancials.com
		/// </summary>
		[RequiresEncryption]
		string CorpDevDatabaseServer { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CMFSROC1.clearmomentum.com
		/// </summary>
		[RequiresEncryption]
	    string LogDatabaseServer { get; }

	    /// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: ClearFinancials50_Prod
		/// </summary>
		[RequiresEncryption]
		string ProdDatabaseName { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: ClearFinancials_AS
		/// </summary>
		[RequiresEncryption]
		string AsDatabaseName { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: ClearFinancials_AS
		/// </summary>
		[RequiresEncryption]
		string ErrorsDatabaseName { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: Clear Financials AS
		/// </summary>
		[RequiresEncryption]
		string AsCubeName { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: see app.config in UnitTests project
		/// </summary>
		[RequiresEncryption]
		string ConnectionMetadata { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: see app.config in UnitTests project
		/// </summary>
		[RequiresEncryption]
		string CriticalErrorMetadata { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CFAdmin
		/// </summary>
		[RequiresEncryption]
		string AdminUserName { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CFAdmin
		/// </summary>
		[RequiresEncryption]
		string AdminPassword { get; }

		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CFAdmin_PS
		/// </summary>
		[RequiresEncryption]
		string AdminPsUserName { get; }
		
		/// <summary>
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: CFAdmin_PS
		/// </summary>
		[RequiresEncryption]
		string AdminPsPassword { get; }
	}
}
