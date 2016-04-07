using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messenger.Tests
{
	/// <summary>
	/// Тестирование авторизации
	/// </summary>
	[TestClass]
	public class Authorization_Test : TestBase
	{
		/// <summary>
		/// Вход систему
		/// </summary>
		[TestMethod]
		public void SignIn_Test()
		{
			// Очищаю тестовую базу
			ClearBase();

			// Создаю пользователя
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			// Авторизую его
			var userId = Messanger.Core.Authorization.SignIn("TestLogin", "Password");

			// Проверяю что авторизован был newUser
			Assert.IsTrue(userId == newUser.UserId);
		}

		/// <summary>
		/// Выход из системы
		/// </summary>
		[TestMethod]
		public void SignOut_Test()
		{
			// Очищаю тестовую базу
			ClearBase();

			// Создаю пользователя
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			// Авторизую его
			var userId = Messanger.Core.Authorization.SignIn("TestLogin", "Password");
			// Выход из системы
			Messanger.Core.Authorization.SignOut(userId.Value);

			// Проверяю что мой пользователь неактивный
			var user = userManager.GetUserById(userId.Value);
			Assert.IsTrue(!user.IsActive.Value);
		}
	}
}
