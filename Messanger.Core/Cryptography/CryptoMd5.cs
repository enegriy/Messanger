using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
