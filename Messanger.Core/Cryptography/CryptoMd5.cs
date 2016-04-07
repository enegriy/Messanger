using System.Security.Cryptography;
using System.Text;

namespace Messanger.Core
{
	/// <summary>
	/// Шифрование по алоритму MD5
	/// </summary>
	public class CryptoMd5 : ICryptography
	{
		/// <summary>
		/// Зашифровать текст
		/// </summary>
		public string CryptoText(string text)
		{
			//Шифрование по алгоритму md5
			var md5 = MD5.Create();
			var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
			return hashBytes.ToStringExt();
		}
	}
}
