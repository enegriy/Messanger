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
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			var userId = Messanger.Core.Authorization.SignIn("TestLogin", "Password");
			Assert.IsTrue(userId == newUser.UserId);

			ClearBase();
		}

		/// <summary>
		/// Выход из системы
		/// </summary>
		[TestMethod]
		public void SignOut_Test()
		{
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			var userId = Messanger.Core.Authorization.SignIn("TestLogin", "Password");
			Messanger.Core.Authorization.SignOut(userId.Value);

			var user = userManager.GetUserById(userId.Value);
			Assert.IsTrue(!user.IsActive.Value);

			ClearBase();
		}
	}
}
