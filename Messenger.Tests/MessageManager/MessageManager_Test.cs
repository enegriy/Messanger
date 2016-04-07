using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messenger.Tests
{
	/// <summary>
	/// Тестирование мэнеджера сообщений
	/// </summary>
	[TestClass]
	public class MessageManager_Test : TestBase
	{
		/// <summary>
		/// Тестируем отправку сообщений
		/// </summary>
		[TestMethod]
		public void SendMessage_Test()
		{
			// Очищаю базу
			ClearBase();

			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var messageManager = new Messanger.Core.MessageManager();

			// Создаю пользователя 1
			var newUser1 = userManager.CreateNew();
			newUser1.Login = "TestLogin1";
			newUser1.Password = crypto.CryptoText("Password1");
			newUser1.NickName = "Ник1";
			userManager.SaveUser(newUser1);

			// Создаю пользователя 2
			var newUser2 = userManager.CreateNew();
			newUser2.Login = "TestLogin2";
			newUser2.Password = crypto.CryptoText("Password2");
			newUser2.NickName = "Ник2";
			userManager.SaveUser(newUser2);

			// Текст сообщения
			var textMessage = "Test text message";

			// Первый пользователь отправляет второму сообщение
			messageManager.SendMessage(newUser1.UserId, newUser2.UserId, textMessage);
			// Получаю все входящие сообщения для пользователя 2
			var listMessage = messageManager.GetIncomingMessages(newUser2.UserId);
			// Проверяю что у него есть сообщения и текст сообщения
			Assert.IsTrue(listMessage.Any());
			Assert.AreEqual<string>(listMessage.First().Text, textMessage);
		}

		/// <summary>
		/// Тестируем отправку сообщений
		/// </summary>
		[TestMethod]
		public void SendMessageAllUsers_Test()
		{
			// Очищаю базу
			ClearBase();

			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var messageManager = new Messanger.Core.MessageManager();

			// Создаю пользователя 1
			var newUser1 = userManager.CreateNew();
			newUser1.Login = "TestLogin1";
			newUser1.Password = crypto.CryptoText("Password1");
			newUser1.NickName = "Ник1";
			userManager.SaveUser(newUser1);

			// Создаю пользователя 2
			var newUser2 = userManager.CreateNew();
			newUser2.Login = "TestLogin2";
			newUser2.Password = crypto.CryptoText("Password2");
			newUser2.NickName = "Ник2";
			userManager.SaveUser(newUser2);

			// Текст сообщения
			var textMessage = "Test text message";

			// Отправляю сообщение всем пользователям от пользователя 2
			messageManager.SendMessageAllUsers(newUser2.UserId, textMessage);
			// Получаю все входящие сообщения для пользователя 1
			var listMessage = messageManager.GetIncomingMessages(newUser1.UserId);
			// Проверяю что у него есть сообщения и текст сообщения
			Assert.IsTrue(listMessage.Any());
			Assert.AreEqual<string>(listMessage.First().Text, textMessage);
		}
	}
}
