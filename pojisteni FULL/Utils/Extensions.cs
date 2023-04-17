using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Utils
{
	public static class Extensions
	{

		/// <summary>
		/// This method is used for View as DisplayName for data (
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNull(this object source)
		{
			return source == null;
		}

		public static bool IsNullOrEmpty(this string source)
		{
			return source == null || source.Length <= 0;
		}

		public static string GetDisplayName(Type type, string propertyName)
		{
			string displayName = type.GetProperty(propertyName)?
				.GetCustomAttributes(typeof(DisplayAttribute), true)?
				.OfType<DisplayAttribute>()
				.FirstOrDefault()?.Name;

			if (displayName.IsNullOrEmpty())
			{
				displayName = propertyName;
			}

			return displayName;
		}
	}
}
