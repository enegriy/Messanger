using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Controllers
{
	public class MessageController : BaseController
	{
		/// <summary>
		/// Главное действие отправки сообщений
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			var userId = GetSessionUser();
			if (!userId.HasValue) return RedirectToAction("Index", "Home");

			return View();
		}
	}
}