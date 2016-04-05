using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messanger.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messenger.Tests
{
	/// <summary>
	/// Тестирование UserManager
	/// </summary>
	[TestClass]
	public class UserManager_Test : TestBase
	{
		/// <summary>
		/// Новый пустой пользватель
		/// </summary>
		[TestMethod]
		public void CreateNew_Test()
		{
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			Assert.IsNotNull(newUser);
		}

		/// <summary>
		/// Сохранить пользователя
		/// </summary>
		[TestMethod]
		public void SaveUser_Test()
		{
			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			userManager.SetActiveUser(newUser.UserId);

			var user = userManager.GetUserById(newUser.UserId);
			Assert.IsNotNull(user);
			Assert.IsTrue(user.UserId == newUser.UserId);
			Assert.IsTrue(user.IsActive.Value);

			ClearBase();
		}
	}
}
