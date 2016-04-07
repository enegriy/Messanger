using System;
using System.Linq;
using Messanger.Core.Models;

namespace Messanger.Core
{
	/// <summary>
	/// Управление сообщениями
	/// </summary>
	public class MessageManager
	{
		/// <summary>
		/// Код для всех пользователей, для отправки сообщений
		/// </summary>
		public static int AllUserCode { get; } = -1;

		/// <summary>
		/// Получить все входящие сообщения
		/// </summary>
		public Message[] GetIncomingMessages(int userId)
		{
			// Выбираем все сообщения для пользователя отсортированные по дате отправки
			Message[] messages = null;
			using (var dbContext = new MessangerEntities())
			{
				messages = dbContext.Messages.Include("User1")
					.Where(x => x.UserIdRecipient == userId || x.UserIdRecipient == null)
					.OrderByDescending(x=>x.SendDate)
					.ToArray();
			}
			return messages;
		}

		/// <summary>
		/// Отправить сообщение конкретному пользователю
		/// </summary>
		public void SendMessage(int senderId, int? recipientId, string text)
		{
			// Создаем новое сообщение
			var message = new Message();
			message.UserIdSender = senderId;
			if (recipientId.HasValue)
				message.UserIdRecipient = recipientId.Value;
			message.Text = text;
			message.SendDate = DateTime.Now;

			// Сохраняем сообщение
			using (var dbContext = new MessangerEntities())
			{
				dbContext.Messages.Add(message);
				dbContext.SaveChanges();
			}
		}

		/// <summary>
		/// Отправить сообщение всем
		/// </summary>
		public void SendMessageAllUsers(int senderId, string text)
		{
			// Отправить сообщение
			SendMessage(senderId, null, text);
		}
	}
}
