using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Tests
{
	/// <summary>
	/// Базовый для тестирования
	/// </summary>
	public class TestBase
	{
		/// <summary>
		/// Очистить базу
		/// </summary>
		public void ClearBase()
		{
			using (var dbContext = new Messanger.Core.Models.MessangerEntities())
			{
				dbContext.sp_ClearDataBase();
			}
		}
	}
}
