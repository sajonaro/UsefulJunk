using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.Cryptography
{
	public sealed class EncryptorDecryptor : IEncryptorDecryptor
	{
		private const string Key = "Talisker_18_yrs_old single malt";

		private static SymmetricAlgorithm GetAlgorithm()
		{
			var key = new Rfc2898DeriveBytes( Key, Encoding.UTF8.GetBytes(Key)) ;
			var alg = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
			alg.Key = key.GetBytes(alg.KeySize / 8);
			alg.IV = key.GetBytes(alg.BlockSize / 8);
			alg.Padding = PaddingMode.ISO10126;

			return alg;
		}
		
		public  string Encrypt(string plainText)
		{
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			using (var memStream = new MemoryStream())
			using (var cryptoStream = new CryptoStream(memStream, GetAlgorithm().CreateEncryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
				cryptoStream.FlushFinalBlock();
				var encryptedBytes = memStream.ToArray();
				return Convert.ToBase64String(encryptedBytes);
			}
		}

		public string Decrypt(string encryptedText)
		{
			byte[] encryptedTextBytes = Encoding.UTF8.GetBytes( encryptedText );
			using (var memStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
			using (var cryptoStream = new CryptoStream(memStream, GetAlgorithm().CreateDecryptor(), CryptoStreamMode.Read))
			{
				int decryptedByteCount = cryptoStream.Read( encryptedTextBytes, 0, encryptedTextBytes.Length );
				return Encoding.UTF8.GetString( encryptedTextBytes, 0, decryptedByteCount );
			}
		}
    }
}
