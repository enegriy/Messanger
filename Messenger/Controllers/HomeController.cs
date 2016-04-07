using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Messanger.Core;
using Messanger.Core.Models;

namespace Messenger.Controllers
{
	/// <summary>
	/// Контроллер Home
	/// </summary>
	public class HomeController : BaseController
	{
		/// <summary>
		/// Главная страница
		/// </summary>
		public ActionResult Index()
		{
			// Проверяю есть ли авторизованный пользователь
			// если есть переходим к сообщениям
			var userId = GetSessionUser();
			if (userId.HasValue)
			{
				return RedirectToAction("Index", "Message");
			}
			return View();
		}

		/// <summary>
		/// Ошибка авторизации
		/// </summary>
		public ActionResult AuthError()
		{
			// Показать сообщение об ошибки
			ViewBag.IsShowError = true;
			// Показать главную страницу 
			return View("Index");
		}

		/// <summary>
		/// Авторизация
		/// </summary>
		[HttpPost]
		public ActionResult LogIn(string login, string password)
		{
			// Ищу пользвателя в базе
			var userId = Messanger.Core.Authorization.SignIn(login, password);
			// Если отсутствует перехожу на главную с показом ошибка об авторизации
			if(!userId.HasValue)
			{
				return RedirectToAction("AuthError", "Home");
			}

			// Если пользователь найден переходим на страницу отправки сообщений
			SetSessionUser(userId);
			// Переходим к действию Index
			return RedirectToAction("Index", "Message");
		}

		/// <summary>
		/// Выйти из системы
		/// </summary>
		[HttpGet]
		public ActionResult LogOut()
		{
			var userId = GetSessionUser();
			// Если авторизации и не было то уходим на страницу авторизации
			if (!userId.HasValue)
			{
				return RedirectToAction("Index", "Home");
			}

			// Выход из системы
			Messanger.Core.Authorization.SignOut(userId.Value);
			ResetSession();

			// Переходим в сообщениям
			return RedirectToAction("Index", "Message");
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		[HttpGet]
		public ActionResult Registration()
		{
			// Создаю модель пользователя
			var userManager = new UserManager();
			var newUser = userManager.CreateNew();

			// Перехожу к заполнению формы регистрации
			return View(newUser);
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		[HttpPost]
		public ActionResult Registration(User user)
		{
			// Получаю хэш пароля
			var crypto = Cryptography.GetCryptographyByDefault();
			user.Password = crypto.CryptoText(user.Password);

			try
			{
				// Сохраняю пользователя
				var userManager = new UserManager();
				userManager.SaveUser(user);
			}
			catch (DbUpdateException exc)
			{
				// Если исключение SqlException то получаем его  иначе null
				var sqlException = ExceptionHelper.GetSqlException(exc);

				// Если ошибка регистрации Duplicated key row error 
				// то сообщаем и возвращаемся опять к форме регистрации
				if (sqlException != null && sqlException.Number == 2601)// Duplicated key row error
				{
					// Оперделяем какое поле повторяется
					var fieldDuplicate = "";
					if (sqlException.Message.IndexOf("IX_User_Login", StringComparison.Ordinal) != -1)
					{
						fieldDuplicate = "Логин";
					}
					else if (sqlException.Message.IndexOf("IX_User_NickName", StringComparison.Ordinal) != -1)
					{
						fieldDuplicate = "Ник";
					}
					ViewBag.Erorr = $"Ошибка регистрации! Такой {fieldDuplicate} уже существует!";
					return View();
				}

				// Если ошибку обработать не смогли пробрасываем выше
				throw;
			}

			// Перехожу на главную страницу
			return RedirectToAction("Index", "Home");
		}
	}
}