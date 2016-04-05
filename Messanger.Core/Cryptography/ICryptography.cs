using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core
{
	/// <summary>
	/// Интерфейс шифрования
	/// </summary>
	interface ICryptography
	{
		/// <summary>
		/// Зашифровать текст
		/// </summary>
		string CryptoText(string text);
	}
}
