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
		/// <returns></returns>
		public ActionResult Index()
		{
			var userId = GetSessionUser();
			if (!userId.HasValue) return RedirectToAction("Index", "Home");

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
			var userId = GetSessionUser();
			var messageManager = new MessageManager();

			if(recipientId == -1)
				messageManager.SendMessageAllUsers(userId.Value, message);
			else
				messageManager.SendMessage(userId.Value, recipientId, message);

			return RedirectToAction("Index", "Message");
		}

		[HttpGet]
		public JsonNetResult GetActiveUser()
		{
			// Шаблон ответа JSON
			var json = new JsonNetResult
			{
				JsonRequestBehavior = JsonRequestBehavior.AllowGet,
				Data = Enumerable.Empty<string>()
			};

			var userId = GetSessionUser();

			UserManager userManager = new UserManager();
			var users = userManager.GetActiveUsers();

			IDictionary<int?, string> dictUser = new Dictionary<int?, string>();
			dictUser[-1] = "Всем пользователям";
			foreach (var user in users)
			{
				if (user.UserId == userId)
					continue;

				dictUser[user.UserId] = user.NickName;
			}

			json.Data = dictUser;
			return json;
		}
	}
}