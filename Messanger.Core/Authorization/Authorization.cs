using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core
{
	/// <summary>
	/// Класс авторизации
	/// </summary>
	public static class Authorization
	{
		/// <summary>
		/// Авторизоваться
		/// </summary>
		public static int? SignIn(string login, string password)
		{
			int? userId = null;
			var userManager = new UserManager();

			// Получаю хэш пароля
			var crypto = Cryptography.GetCryptographyByDefault();
			var hashPassword = crypto.CryptoText(password);

			// Ищу пользователя в бд
			var user = userManager.GetUserByLoginPass(login, hashPassword);

			if (user != null)
			{
				// Активируем пользователя
				userManager.SetActiveUser(user.UserId);
				userId = user.UserId;
			}

			return userId;
		}

		/// <summary>
		/// Выйти из системы
		/// </summary>
		public static void SignOut(int userId)
		{
			var userManager = new UserManager();
			// Деактивируем пользователя
			userManager.SetInActiveUser(userId);
		}
	}
}
