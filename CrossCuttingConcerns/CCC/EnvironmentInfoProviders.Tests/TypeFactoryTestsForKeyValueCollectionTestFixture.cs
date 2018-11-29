using EnvironmentInfoProviders.Contracts;
using EnvironmentInfoProviders.Infrastructure.DependencyResolution;
using NUnit.Framework;
using System.Configuration;
using Utilities;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders.Tests
{
	[TestFixture]
	public class TypeFactoryTestsForKeyValueCollectionTestFixture : TestBase
	{
		[SetUp]
		public void SetUp()
		{
			ExpectedConfigurationCollection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).AppSettings.Settings;
			TypeFactory.ApplyContainerExtension(new KeyValueConfigurationEnvironmentInfoProviderExtension(ExpectedConfigurationCollection));
			TypeFactory.RegisterType<IEncryptorDecryptor, EncryptorDecryptor>();
		}

		[Test]
		public void TestInfoProvidersWithUnityExtension()
		{
			var factory = TypeFactory.Get<IEnvironmentInfoProviderFactory>();
			AssertAllProvidersAreCorrectlyFilled(factory);
		}
	}
}