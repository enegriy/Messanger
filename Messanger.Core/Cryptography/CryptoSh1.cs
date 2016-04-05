﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Messanger.Core
{
	/// <summary>
	/// Шифрование по алоритму Sh1
	/// </summary>
	public class CryptoSh1 : ICryptography
	{
		/// <summary>
		/// Зашифровать текст
		/// </summary>
		public string CryptoText(string text)
		{
			SHA1 sha = new SHA1CryptoServiceProvider();
			var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
			return hashBytes.ToStringExt();
			
		}
	}
}
