using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
			// Создаю нового пользователя
			var newUser = userManager.CreateNew();
			// Проверяю что он создан
			Assert.IsNotNull(newUser);
		}

		/// <summary>
		/// Сохранить пользователя
		/// </summary>
		[TestMethod]
		public void SaveUser_Test()
		{
			// Очищаю базу
			ClearBase();

			var crypto = Messanger.Core.Cryptography.GetCryptographyByDefault();
			var userManager = new Messanger.Core.UserManager();
			// Создаю пользователя 
			var newUser = userManager.CreateNew();
			newUser.Login = "TestLogin";
			newUser.Password = crypto.CryptoText("Password");
			newUser.NickName = "Ник";
			userManager.SaveUser(newUser);

			// Делаю его активным
			userManager.SetActiveUser(newUser.UserId);

			var user = userManager.GetUserById(newUser.UserId);
			// Проверяю что пользователь создан и он активен
			Assert.IsNotNull(user);
			Assert.IsTrue(user.UserId == newUser.UserId);
			Assert.IsTrue(user.IsActive.Value);

			// Создаю пользователя и проверяю запрет 
			// повторяющихся NickName
			var newUser1 = userManager.CreateNew();
			newUser1.Login = "TestLogin";
			newUser1.Password = crypto.CryptoText("Password");
			newUser1.NickName = "Ник1";
			try
			{
				userManager.SaveUser(newUser1);
			}
			catch (DbUpdateException exc)
			{
				// Если исключение SqlException то получаем его иначе null
				var sqlException = ExceptionHelper.GetSqlException(exc);
				if (sqlException != null)
				{
					Assert.AreEqual<int>(sqlException.Number, 2601);
				}
			}
		}
	}
}
