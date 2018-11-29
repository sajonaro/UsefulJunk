namespace EnvironmentInfoProviders.Contracts
{
	/// <summary>
	/// https://en.wikipedia.org/wiki/Lightweight_Directory_Access_Protocol
	/// </summary>
	public interface ILdapInfoProvider : IEnvironmentInfoProvider
	{
		/// <summary>
		/// Base server url with prefix
		/// </summary>
		[RequiresEncryption]
		string PathUrl { get; }

		/// <summary>
		/// Base server url
		/// </summary>
		[RequiresEncryption]
		string PathUrl2 { get; }

		/// <summary>
		/// Users' folder root path
		/// </summary>
		[RequiresEncryption]
		string RootUsersOrgUnitPath { get; }

		/// <summary>
		/// Users' folder root name
		/// </summary>
		[RequiresEncryption]
		string RootUsersOrgUnitName { get; }

		/// <summary>
		/// Users' folder root filter
		///  </summary>
		[RequiresEncryption]
		string RootUsersOrgUnitFilter { get; }

		/// <summary>
		/// Domain name, second level
		/// </summary>
		[RequiresEncryption]
		string DomainName { get; }

		/// <summary>
		/// Domain login
		/// </summary>
		[RequiresEncryption]
		string ServerBindLogin { get; }

		/// <summary>
		/// Domain password
		/// </summary>
		[RequiresEncryption]
		string ServerBindPassword { get; }
	}
}
