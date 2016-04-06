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
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var messageManager = new Messanger.Core.MessageManager();

			var newUser1 = userManager.CreateNew();
			newUser1.Login = "TestLogin1";
			newUser1.Password = crypto.CryptoText("Password1");
			newUser1.NickName = "Ник1";
			userManager.SaveUser(newUser1);

			var newUser2 = userManager.CreateNew();
			newUser2.Login = "TestLogin2";
			newUser2.Password = crypto.CryptoText("Password2");
			newUser2.NickName = "Ник2";
			userManager.SaveUser(newUser2);

			string textMessage = "Test text message";

			messageManager.SendMessage(newUser1.UserId, newUser2.UserId, textMessage);
			var listMessage = messageManager.GetIncomingMessages(newUser2.UserId);
			Assert.IsTrue(listMessage.Any());
			Assert.AreEqual<string>(listMessage.First().Text, textMessage);

			ClearBase();
		}

		/// <summary>
		/// Тестируем отправку сообщений
		/// </summary>
		[TestMethod]
		public void SendMessageAllUsers_Test()
		{
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var messageManager = new Messanger.Core.MessageManager();

			var newUser1 = userManager.CreateNew();
			newUser1.Login = "TestLogin1";
			newUser1.Password = crypto.CryptoText("Password1");
			newUser1.NickName = "Ник1";
			userManager.SaveUser(newUser1);

			var newUser2 = userManager.CreateNew();
			newUser2.Login = "TestLogin2";
			newUser2.Password = crypto.CryptoText("Password2");
			newUser2.NickName = "Ник2";
			userManager.SaveUser(newUser2);

			string textMessage = "Test text message";

			messageManager.SendMessageAllUsers(newUser2.UserId, textMessage);
			var listMessage = messageManager.GetIncomingMessages(newUser1.UserId);
			Assert.IsTrue(listMessage.Any());
			Assert.AreEqual<string>(listMessage.First().Text, textMessage);
		}
	}
}
