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
			if (cryptoAlg == CryptoAlg.md5)
				return new CryptoMd5();

			if (cryptoAlg == CryptoAlg.sh1)
				return new CryptoSh1();

			return GetCryptographyByDefault();
		}
	}
}
