using System;
using NUnit.Framework;

namespace Utilities.Cryptography.Tests
{
	[TestFixture]
	public class EncryptorTests {

		private IEncryptorDecryptor _encryptorDecryptor;

		[SetUp]
		public void TestSetup()
		{
			_encryptorDecryptor = new EncryptorDecryptor();
		}

		[Test, TestCaseSource("TestPlainTexts")]
		public void EncryptDecryptTests(string plainText)
		{
			var encryptedResult = _encryptorDecryptor.Encrypt(plainText);
			var decryptedResult = _encryptorDecryptor.Decrypt(encryptedResult);
			Assert.AreEqual(plainText,decryptedResult);

		}

		private static readonly string[] TestPlainTexts =
		{
			"cucumber;tomato;apple;",
			"Hello world",
			"ClearFinancials_AS",
			"https://dev-ssas.clearmomentum.com",
			"CMFSROC1.clearmomentum.com",
			"ClearFinancials50_Prod",
			"https://dev-data.clearmomentum.com",
			@"\&//:232_((*&$%",
			Guid.NewGuid().ToString(),
			Guid.NewGuid().ToString()
		};

	}
}