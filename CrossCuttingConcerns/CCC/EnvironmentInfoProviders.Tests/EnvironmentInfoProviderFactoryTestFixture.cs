using System.Configuration;
using EnvironmentInfoProviders.Contracts;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Utilities;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders.Tests
{
    [TestFixture]
    public class EnvironmentInfoProviderFactoryTestFixture:TestBase
    {
        [SetUp]
        public void SetUp()
        {
            ExpectedConfigurationCollection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).AppSettings.Settings;

			TypeFactory.RegisterType<IEnvironmentInfoProviderFactory, EnvironmentInfoProviderFactory>(new InjectionConstructor(ExpectedConfigurationCollection));
	        TypeFactory.RegisterType<IEncryptorDecryptor, EncryptorDecryptor>();
        }

        [Test]
        public void TestInfoProviders()
        {
            var factory = TypeFactory.Get<IEnvironmentInfoProviderFactory>();
	        AssertAllProvidersAreCorrectlyFilled(factory);
        }

		[Test]
        public void TestAssemblyBoundAppConfigEIPFactory()
        {

            var factory = new AssemblyBoundAppConfigEIPFactory() { DefaultKeyValueCollection = () => ExpectedConfigurationCollection };
	        AssertAllProvidersAreCorrectlyFilled(factory);
        }



    }
}
