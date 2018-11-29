using FluentAssertions;
using Microsoft.Web.XmlTransform;
using NUnit.Framework;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Utilities.Cryptography;

namespace CustomXdtTransforms.Tests
{
	/// <summary>
	/// Project file contains custom action that ensures nuget packages are allways up to date
	/// </summary>
	[TestFixture]
	public class EncodeDecodeTests
	{
	
		[Test]
		public void OkEncodeDecodeAppSettings()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();

			// assert
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var appSettings = (AppSettingsSection)config.GetSection("appSettings");

			encryptorDecryptor.Decrypt(appSettings.Settings["KeyToEncrypt1"].Value).Should().Be("PlainValue1");
			encryptorDecryptor.Decrypt(appSettings.Settings["KeyToEncrypt2"].Value).Should().Be("PlainValue2");
			appSettings.Settings["UnTouchedKey1"].Value.Should().Be("UnTouchedValue1");
			appSettings.Settings["UnTouchedKey2"].Value.Should().Be("UnTouchedValue2");
		}

		[Test]
		public void ReplaceAndEncryptTest()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();

			// assert
			Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
			var appSettings = (AppSettingsSection)config.GetSection( "appSettings" );

			encryptorDecryptor.Decrypt( appSettings.Settings["location"].Value ).Should().Be( "Canandaigua" );
		}

		[Test]
		public void OkEncodeDecodeConnectionStrings()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();

			// assert
			encryptorDecryptor.Decrypt(ConfigurationManager.ConnectionStrings["KeyToEncrypt1"].ConnectionString)
				.Should().Be("Data Source=SomeServer;Initial Catalog=EncryptDB1;Integrated Security=True");
			encryptorDecryptor.Decrypt(ConfigurationManager.ConnectionStrings["KeyToEncrypt2"].ConnectionString)
				.Should().Be("Data Source=SomeServer;Initial Catalog=EncryptDB2;Integrated Security=True");
			ConfigurationManager.ConnectionStrings["UnTouchedKey1"].ConnectionString
				.Should().Be("Data Source=SomeServer;Initial Catalog=SomeDB1;Integrated Security=True");
			ConfigurationManager.ConnectionStrings["UnTouchedKey2"].ConnectionString
				.Should().Be("Data Source=SomeServer;Initial Catalog=SomeDB2;Integrated Security=True");
		}

		[Test]
		public void OkEncodeDecodeInnerText()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();

			// assert
			encryptorDecryptor.Decrypt(ConfigurationManager.ConnectionStrings["KeyToEncrypt1"].ConnectionString)
				.Should().Be("Data Source=SomeServer;Initial Catalog=EncryptDB1;Integrated Security=True");
			encryptorDecryptor.Decrypt(ConfigurationManager.ConnectionStrings["KeyToEncrypt2"].ConnectionString)
				.Should().Be("Data Source=SomeServer;Initial Catalog=EncryptDB2;Integrated Security=True");
			ConfigurationManager.ConnectionStrings["UnTouchedKey1"].ConnectionString
				.Should().Be("Data Source=SomeServer;Initial Catalog=SomeDB1;Integrated Security=True");
			ConfigurationManager.ConnectionStrings["UnTouchedKey2"].ConnectionString
				.Should().Be("Data Source=SomeServer;Initial Catalog=SomeDB2;Integrated Security=True");
		}

	    [Test]
		public void OkEncodeDecodeReplaceAttributeAndInnerTextByXPath()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();

			var dllPath = Assembly.GetAssembly(typeof(TestEnvironmentForEncode)).EscapedCodeBase.TrimStart("file:///".ToArray());
			var appConfigPath = string.Format("{0}.config", dllPath);


			using (var input = new XmlTransformableDocument())
			{
				input.Load(appConfigPath);

				using (var stringWriter = new StringWriter())
				using (var xmlWriter = XmlWriter.Create(stringWriter))
				{
					input.WriteContentTo(xmlWriter);
					xmlWriter.Flush();
					var result = stringWriter.ToString();

					var doc = XDocument.Parse(result);

					var root = doc.Root;

					// assert
					var encryptedNode1 = root.Descendants("setting").Single(x => x.Attribute("name").Value == "ExpectedEncrypted1");
					var encryptedNode1Attribute = encryptedNode1.Attribute("serializeAs").Value;
					encryptorDecryptor.Decrypt(encryptedNode1Attribute).Should().Be("String");
					var encryptedNode1Value = encryptedNode1.Value;
					encryptorDecryptor.Decrypt(encryptedNode1Value).Should().Be("SomeNewEncryptedValue1");

					var encryptedNode2 = root.Descendants("setting").Single(x => x.Attribute("name").Value == "ExpectedEncrypted2");
					var encryptedNode2Attribute = encryptedNode2.Attribute("serializeAs").Value;
					encryptorDecryptor.Decrypt(encryptedNode2Attribute).Should().Be("String");
					var encryptedNode2Value = encryptedNode2.Value;
					encryptorDecryptor.Decrypt(encryptedNode2Value).Should().Be("EncryptedValue2");
				}
			}
		}
	}
}