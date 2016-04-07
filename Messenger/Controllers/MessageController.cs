using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messanger.Core;
using Was.JsonNetResult;

namespace Messenger.Controllers
{
	public class MessageController : BaseController
	{
		/// <summary>
		/// Главное действие отправки сообщений
		/// </summary>
		public ActionResult Index()
		{
			// Если авторизации нет то переходим к страницы авторизации
			var userId = GetSessionUser();
			if (!userId.HasValue) return RedirectToAction("Index", "Home");

			// Получить все входящие сообщения
			var messageManager = new MessageManager();
			var messages = messageManager.GetIncomingMessages(userId.Value);

			return View(messages);
		}

		/// <summary>
		/// Сохранить сощбщение
		/// </summary>
		[HttpPost]
		public ActionResult SaveMessage(string message, int recipientId)
		{
			var messageManager = new MessageManager();
			var userId = GetSessionUser();

			// Если авторизации нет то переходим к страницы авторизации
			if (!userId.HasValue) return RedirectToAction("Index", "Home");
			
			// Отправляем сообщение
			if(recipientId == MessageManager.AllUserCode)
				messageManager.SendMessageAllUsers(userId.Value, message);
			else
				messageManager.SendMessage(userId.Value, recipientId, message);

			// Возврат на главную страницу сообщений
			return RedirectToAction("Index", "Message");
		}

		/// <summary>
		/// Получить активных пользователей
		/// </summary>
		[HttpGet]
		public JsonNetResult GetActiveUser()
		{
			// Шаблон ответа JSON
			var json = new JsonNetResult
			{
				JsonRequestBehavior = JsonRequestBehavior.AllowGet,
				Data = Enumerable.Empty<string>()
			};

			// Ид авторизованного пользователя
			var userId = GetSessionUser();

			// Получить активных пользователей
			UserManager userManager = new UserManager();
			var users = userManager.GetActiveUsers();

			// Формирую словарь пользователей
			IDictionary<int?, string> dictUser = new Dictionary<int?, string>();
			dictUser[MessageManager.AllUserCode] = "Всем пользователям";
			foreach (var user in users)
			{
				// Если активный пользователь я, то пропускаем, 
				// себе отправлять сообщение не буду:)
				if (user.UserId == userId)
					continue;

				dictUser[user.UserId] = user.NickName;
			}

			// Возврат активных пользователей в Json типе
			json.Data = dictUser;
			return json;
		}
	}
}