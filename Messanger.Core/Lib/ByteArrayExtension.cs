using System.Collections.Generic;
using System.Text;

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
		public static string ToStringExt(this IEnumerable<byte> bytes)
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
