
namespace Messanger.Core
{
	/// <summary>
	/// Интерфейс шифрования
	/// </summary>
	public interface ICryptography
	{
		/// <summary>
		/// Зашифровать текст
		/// </summary>
		string CryptoText(string text);
	}
}
