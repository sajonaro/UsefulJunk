using EnvironmentInfoProviders.Contracts;
using System;
using System.Configuration;

namespace EnvironmentInfoProviders
{
	/// <summary>
	/// default implementation of IAssemblyBoundAppConfigEIPFactory
	/// </summary>
	public class AssemblyBoundAppConfigEIPFactory : IAssemblyBoundAppConfigEIPFactory
	{
		/// <summary>
		/// optional, Used in Get method if defined
		/// </summary>
		public Func<KeyValueConfigurationCollection> DefaultKeyValueCollection { get; set; }

		private static KeyValueConfigurationCollection GetKeyValueCollection(string assemblyLocation)
		{
			var settings = ConfigurationManager.OpenExeConfiguration(assemblyLocation).AppSettings.Settings;
			if (settings.Count == 0)
			{
				throw new Exception("Keys not found!");
			}
			return settings;
		}

		public T Get<T>() where T : class, IEnvironmentInfoProvider
		{
			var keyValueCollection = DefaultKeyValueCollection != null ?
				DefaultKeyValueCollection() :
				GetKeyValueCollection(typeof(T).Assembly.CodeBase.Replace("file:///", ""));
			var factory = new EnvironmentInfoProviderFactory(keyValueCollection);
			return factory.Get<T>();
		}
	}
}