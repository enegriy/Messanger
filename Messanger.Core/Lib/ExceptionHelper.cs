using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core
{
	/// <summary>
	/// Помощь в обработке исключений
	/// </summary>
	public static class ExceptionHelper
	{
		/// <summary>
		/// Проверить вролженные исключения и вернуть с типом SqlException
		/// </summary>
		public static SqlException GetSqlException(Exception exc)
		{
			// Если исключение SqlException то берем его
			var sqlException = exc as SqlException;
			if (sqlException != null)
			{
				return sqlException;
			}

			// Проверяем есть ли вложенные исключения
			if (exc.InnerException != null)
			{
				return GetSqlException(exc.InnerException);
			}

			// Если ничего не удалось определить вернем null
			return null;
		}
	}
}
