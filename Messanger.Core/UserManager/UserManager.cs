using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messanger.Core.Models;

namespace Messanger.Core
{
	/// <summary>
	/// Управление пользователем
	/// </summary>
	public class UserManager
	{
		/// <summary>
		/// Новый пустой пользватель
		/// </summary>
		public User CreateNew()
		{
			return new User();
		}

		/// <summary>
		/// Сохранить пользователя
		/// </summary>
		public void SaveUser(User user)
		{
			using (var dbContext = new MessangerEntities())
			{
				dbContext.Users.Add(user);
				dbContext.SaveChanges();
			}
		}

		/// <summary>
		/// Получить пользователя по id
		/// </summary>
		public User GetUserById(int userId)
		{
			User user = null;
			using (var dbContext = new MessangerEntities())
			{
				user = dbContext.Users.FirstOrDefault(usr => usr.UserId == userId);
			}
			return user;
		}

		/// <summary>
		/// Получить пользователя по Логину и Паролю
		/// </summary>
		public User GetUserByLoginPass(string login, string password)
		{
			User user = null;
			using (var dbContext = new MessangerEntities())
			{
				user = dbContext.Users.FirstOrDefault(usr =>
					usr.Login.Equals(login) &&
					usr.Password.Equals(password));
			}
			return user;
		}

		/// <summary>
		/// Установить пользователя активным
		/// </summary>
		public void SetActiveUser(int userId)
		{
			SetActive(userId, true);
		}

		/// <summary>
		/// Установить пользователя не активным
		/// </summary>
		public void SetInActiveUser(int userId)
		{
			SetActive(userId, false);
		}

		/// <summary>
		/// Установить значение для поля Active
		/// </summary>
		private void SetActive(int userId, bool isActive)
		{
			using (var dbContext = new MessangerEntities())
			{
				var user = dbContext.Users.FirstOrDefault(usr => usr.UserId == userId);
				user.IsActive = isActive;
				dbContext.SaveChanges();
			}
		}
	}
}
