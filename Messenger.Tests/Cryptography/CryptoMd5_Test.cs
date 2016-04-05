using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messanger.Core;

namespace Messenger.Tests.Cryptography
{
	[TestClass]
	public class CryptoMd5_Test
	{
		/// <summary>
		/// Тестирование метода шифруешего текст по MD5
		/// </summary>
		[TestMethod]
		public void CryptoText()
		{
			// Исходный текст
			const string sourceText = "TestPassword";
			// Результат хэш вычисления
			const string hashText = "35253683412811311514528722093232135179174";

			CryptoMd5 cMd5 = new CryptoMd5();
			// Вычисляем значение хэш для sourceText
			var hashValue = cMd5.CryptoText(sourceText);
			// Проверяем что есть результат
			Assert.IsNotNull(hashValue);
			// И он равен ожидаемому результату
			Assert.AreEqual<string>(hashValue, hashText);
		}
	}
}
