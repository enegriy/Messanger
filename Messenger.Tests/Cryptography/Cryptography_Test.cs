using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messanger.Core;

namespace Messenger.Tests
{
	/// <summary>
	/// Тест Шифрования
	/// </summary>
	[TestClass]
	public class Cryptography_Test
	{
		/// <summary>
		/// Тестирование метода шифруешего текст по MD5
		/// </summary>
		[TestMethod]
		public void CryptoMD5_Test()
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

		/// <summary>
		/// Тестирование метода шифруешего текст по SH1
		/// </summary>
		[TestMethod]
		public void CryptoSH1_Test()
		{
			// Исходный текст
			const string sourceText = "TestPassword";
			// Результат хэш вычисления
			const string hashText = "988098913410924640112174351751416317279621521136";

			CryptoSh1 sh1 = new CryptoSh1();
			// Вычисляем значение хэш для sourceText
			var hashValue = sh1.CryptoText(sourceText);
			// Проверяем что есть результат
			Assert.IsNotNull(hashValue);
			// И он равен ожидаемому результату
			Assert.AreEqual<string>(hashValue, hashText);
		}

		/// <summary>
		/// Тестирование метода шифруешего текст по SH1
		/// </summary>
		[TestMethod]
		public void GetCryptography_Test()
		{
			// Проверяю тип криптоалгоритма по умолчанию
			var cryptoByDefault = Messanger.Core.Cryptography.GetCryptographyByDefault();
			Assert.IsTrue(cryptoByDefault is CryptoMd5);

			// Проверяю тип криптоалгоритма Sh1
			var cryptoSh1 = Messanger.Core.Cryptography.GetCryptography(CryptoAlg.Sh1);
			Assert.IsTrue(cryptoSh1 is CryptoSh1);

			// Проверяю тип криптоалгоритма md5
			var cryptoMd5 = Messanger.Core.Cryptography.GetCryptography(CryptoAlg.Md5);
			Assert.IsTrue(cryptoMd5 is CryptoMd5);
		}
	}
}
