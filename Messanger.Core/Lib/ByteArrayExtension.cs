using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core
{
	/// <summary>
	/// Расширение для массива байт
	/// </summary>
	public static class ByteArrayExtension
	{
		/// <summary>
		/// Массив байт собрать в строку
		/// </summary>
		public static string ToStringExt(this byte[] bytes)
		{
			var sb = new StringBuilder();
			foreach (var b in bytes)
			{
				sb.Append(b);
			}
			return sb.ToString();
		}
	}
}
