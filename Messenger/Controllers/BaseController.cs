using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Messenger.Controllers
{
	/// <summary>
	/// Базовый для контроллеров
	/// </summary>
	public class BaseController : Controller
	{
		/// <summary>
		/// Получить идент.пользователя
		/// </summary>
		/// <returns></returns>
		public int? GetSessionUser()
		{
			return Session["UserId"] as int?;
		}

		/// <summary>
		/// Установить идент.пользователя
		/// </summary>
		/// <param name="userId"></param>
		public void SetSessionUser(int? userId)
		{
			Session["UserId"] = userId;
		}

		/// <summary>
		/// Сброс сессии
		/// </summary>
		public void ResetSession()
		{
			Session["UserId"] = null;
		}
	}
}