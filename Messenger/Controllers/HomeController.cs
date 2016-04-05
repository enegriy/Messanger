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
	public class HomeController : Controller
	{
		/// <summary>
		/// Главная страница
		/// </summary>
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Авторизация
		/// </summary>
		[HttpPost]
		public ActionResult LogIn(string login, string password)
		{
			var userId = Messanger.Core.Authorization.SignIn(login, password);

			if(!userId.HasValue)
			{
				return RedirectToAction("Index", "Home");
			}

			Session["userId"] = userId;
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		[HttpGet]
		public ActionResult Registration()
		{
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

			var userManager = new UserManager();
			userManager.SaveUser(user);

			return RedirectToAction("Index", "Home");
		}
	}
}