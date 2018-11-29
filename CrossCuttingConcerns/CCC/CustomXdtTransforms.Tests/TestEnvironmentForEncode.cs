using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using FluentAssertions;
using Microsoft.Web.XmlTransform;
using NUnit.Framework;
using Utilities.Cryptography;

namespace CustomXdtTransforms.Tests
{
	[TestFixture]
	public class TestEnvironmentForEncode
	{

		/// <summary>
		/// Project file contains custom action that ensures nuget packages are allways up to date
		/// </summary>
		[Ignore ("under construction"),Test]
		public void OkEncodeDecodeReplace()
		{
			// arrange
			var encryptorDecryptor = new EncryptorDecryptor();
			var inputFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "CustomXdtTransforms.Tests", "TestAppConfigs", "TestApp.config");
			var transformFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "CustomXdtTransforms.Tests", "TestAppConfigs", "TestApp.Debug.config");
			string result;

			// act
			using (var input = new XmlTransformableDocument())
			using (var transformer = new XmlTransformation(transformFilePath))
			{
				input.Load(inputFilePath);
				transformer.Apply(input);

				using (var stringWriter = new StringWriter())
				using (var xmlWriter = XmlWriter.Create(stringWriter))
				{
					input.WriteContentTo(xmlWriter);
					xmlWriter.Flush();
					result = stringWriter.ToString();

					var xmlDoc = XDocument.Parse(result);

					var root = xmlDoc.Root;

					// assert
					var ecnrypteNode2 = root.Descendants("setting").Single(x => x.Attribute("name").Value == "ExpectedEncrypted2");
					var ecnrypteNode2Attrubute = ecnrypteNode2.Attribute("serializeAs").Value;
					encryptorDecryptor.Decrypt(ecnrypteNode2Attrubute).Should().Be("String");
					var encryptedNode2Value = ecnrypteNode2.Value;
					encryptorDecryptor.Decrypt(encryptedNode2Value).Should().Be("SomeNewEncryptedValue2");
				}
			}
		}
	}
}