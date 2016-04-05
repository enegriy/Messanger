using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		public ActionResult Registration()
		{
			return View();
		}
	}
}