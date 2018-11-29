using System.Configuration;
using EnvironmentInfoProviders.Contracts;
using EnvironmentInfoProviders.Infrastructure.DependencyResolution;
using NUnit.Framework;
using Utilities;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders.Tests
{
    [TestFixture]
    public class TypeFactoryTestsForAssemblyBoundAppConfigTestFixture: TestBase
    {
        [SetUp]
        public void SetUp()
        {
            ExpectedConfigurationCollection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).AppSettings.Settings;
            TypeFactory.ApplyContainerExtension(new AssemblyBoundAppConfigEnvironmentInfoProviderExtension(){DefaultKeyValueCollection = () => ExpectedConfigurationCollection});
			TypeFactory.RegisterType<IEncryptorDecryptor,EncryptorDecryptor>();
        }

		[Test]
        public void TestInfoProvidersWithUnityExtension()
		{
			//we purposely rely on AssemblyBoundAppConfigEnvironmentInfoProviderExtension strategy to be able to  
			//delegate the calls of Get<T> to IAssemblyBoundAppConfigEIPFactory.Get<T>
			AssertAllProvidersAreCorrectlyFilled < IAssemblyBoundAppConfigEIPFactory>( );
        }

    
    }  
}