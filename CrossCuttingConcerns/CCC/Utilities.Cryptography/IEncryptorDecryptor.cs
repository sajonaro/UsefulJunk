namespace Utilities.Cryptography
{
	/// <summary>
	/// Encrypts and decrypts plain text  values
	/// </summary>
	public interface IEncryptorDecryptor
	{
		/// <summary>
		/// returns encrypted value
		/// </summary>
		string Encrypt(string plainText);

		/// <summary>
		/// returns plain text 
		/// </summary>
		string Decrypt(string encryptedText);

	}
}