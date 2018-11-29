namespace EnvironmentInfoProviders.Contracts
{
	/// <summary>
	/// Interface responsible for providing settings for SMTP connection.
	/// </summary>
	public interface ISmtpSettingsProvider : IEnvironmentInfoProvider
	{
		/// <summary>
		/// Uses for send emails
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: mail.clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string SmtpServerName { get; }

		/// <summary>
		/// Uses for send emails
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: 25
		/// </summary>
		[RequiresEncryption]
		string SmtpPort { get; }

		/// <summary>
		/// Uses for send emails
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: datacenter
		/// </summary>
		[RequiresEncryption]
		string SmtpUserName { get; }

		/// <summary>
		/// Uses for send emails
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: datacenter
		/// </summary>
		[RequiresEncryption]
		string SmtpPassword { get; }

		/// <summary>
		/// Email addres uses to send email
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: datacenter@clearmomentum.com
		/// </summary>
		[RequiresEncryption]
		string SmtpUserEmail { get; }

		/// <summary>
		/// Uses for enable SSL for SMTP client.
		/// Project: ProfessionalServicesApplication (ProfessionalServices);
		/// Default value: true
		/// Possible values: true/false
		/// </summary>
		[RequiresEncryption]
		string SmtpClientEnableSsl { get; }

	}
}