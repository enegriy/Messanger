using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core
{
	/// <summary>
	/// Класс работы с шифрованием
	/// </summary>
	public static class Cryptography
	{
		/// <summary>
		/// Получить алгоритм шифрования по умолчанию
		/// </summary>
		public static ICryptography GetCryptographyByDefault()
		{
			return new CryptoMd5();
		}

		/// <summary>
		/// Получить алгортим шифрования
		/// </summary>
		public static ICryptography GetCryptography(CryptoAlg cryptoAlg)
		{
			switch (cryptoAlg)
			{
				case CryptoAlg.Md5:
					return new CryptoMd5();
				case CryptoAlg.Sh1:
					return new CryptoSh1();
				default:
					return GetCryptographyByDefault();
			}
		}
	}
}
