using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using EnvironmentInfoProviders.Contracts;
using EnvironmentInfoProviders.Infrastructure.DependencyResolution;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Utilities;
using Utilities.Cryptography;

namespace EnvironmentInfoProviders.Tests
{
    [TestFixture(Category = "Integration"), Ignore]
    public class LdapIntegrationTestFixture : TestBase
    {
        const string ExpectedUid = "testuser";
        const string ExpectedGroupName = "TestGroup";

        [SetUp]
        public void SetUp()
        {
            ExpectedConfigurationCollection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).AppSettings.Settings;

            TypeFactory.ApplyContainerExtension(new KeyValueConfigurationEnvironmentInfoProviderExtension(ExpectedConfigurationCollection));
            TypeFactory.RegisterType<IEncryptorDecryptor, EncryptorDecryptor>();
        }

        [Test]
        public void UserSearchTest()
        {
            ILdapInfoProvider ldapInfoProvider = TypeFactory.Get<ILdapInfoProvider>();

            using (DirectoryEntry entry = new DirectoryEntry(ldapInfoProvider.PathUrl + "/" + ldapInfoProvider.RootUsersOrgUnitPath, ldapInfoProvider.ServerBindLogin, ldapInfoProvider.ServerBindPassword, AuthenticationTypes.ServerBind))
            using (DirectorySearcher searcher = new DirectorySearcher(entry, string.Format("(uid={0})(objectClass=organizationalPerson)", ExpectedUid)))
            {
                var searchResult = searcher.FindOne();
                Assert.NotNull(searchResult);

                var foundEntry = searchResult.GetDirectoryEntry();
                Assert.NotNull(foundEntry);

                string actualUid = Convert.ToString(foundEntry.Properties["uid"].Value);
                Assert.AreEqual(ExpectedUid, actualUid);
            }
        }

        [Test]
        public void GroupSearchTest()
        {
            ILdapInfoProvider ldapInfoProvider = TypeFactory.Get<ILdapInfoProvider>();

            using (DirectoryEntry entry = new DirectoryEntry(ldapInfoProvider.PathUrl + "/" + ldapInfoProvider.RootUsersOrgUnitPath, ldapInfoProvider.ServerBindLogin, ldapInfoProvider.ServerBindPassword, AuthenticationTypes.ServerBind))
            using (DirectorySearcher searcher = new DirectorySearcher(entry, string.Format("(objectClass=groupOfNames)(cn={0})", ExpectedGroupName)))
            {
                var searchResult = searcher.FindOne();
                Assert.NotNull(searchResult);

                var foundEntry = searchResult.GetDirectoryEntry();
                Assert.NotNull(foundEntry);

                string actualCn = Convert.ToString(foundEntry.Properties["cn"].Value);
                Assert.AreEqual(ExpectedGroupName, actualCn);
            }
        }
    }
}
