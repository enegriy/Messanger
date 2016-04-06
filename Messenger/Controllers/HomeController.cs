using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Messanger.Core;
using Messanger.Core.Models;

namespace Messenger.Controllers
{
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
		/// Авторизация
		/// </summary>
		[HttpPost]
		public ActionResult LogIn(string login, string password)
		{
			// Ищу пользвателя в базе
			var userId = Messanger.Core.Authorization.SignIn(login, password);

			// Если отсутствует перехожу на главную
			if(!userId.HasValue)
			{
				return RedirectToAction("Index", "Home");
			}

			// Если пользователь найден переходим на страницу отправки сообщений
			SetSessionUser(userId);
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

			// Сохраняю пользователя
			var userManager = new UserManager();
			userManager.SaveUser(user);

			// Перехожу на главную страницу
			return RedirectToAction("Index", "Home");
		}
	}
}