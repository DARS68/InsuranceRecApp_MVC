using System.ComponentModel.DataAnnotations;

namespace pojisteni_FULL.Utils
{
	public static class Extensions
	{
		// TODO (DELETE COMMENT)
		// Used like this: 
		// ExampleClass instance = new ExampleClass();
		// if (instance.IsNull())
		// {
		// ...
		// }
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
			// proměnná "type" nese informaci o datovém typu

			// Přistupuju k datovému typu "type" (př.: typeof(InsuranceItem))
			string displayName = type
				// Na datovém typu "type" (př.: typeof(InsuranceItem)) hledám vlastnost podle jména: "propertyName"
				.GetProperty(propertyName)
				// Z nalezené vlastnosti "propertyName" si vytahuji její metadata
				// KOnkrétně mě zajímají custom attributy (př.: [Display(Name = "Pojistná částka")])
				?.GetCustomAttributes(typeof(DisplayAttribute), true)
				// GetCustomAttributes mi vrtí kolekci "object[]" kterou musím přetypovat na kolekci "DisplayAttribute[]" 
				// což dělá příkaz .OfType<DisplayAttribute>()
				?.OfType<DisplayAttribute>()
				// Obvykle mám nad vlastnotí definovaný pouze jeden custom attribut Display, proto je
				// bezpečné se zajímat pouze o první a pokud je definovaná, získám si název tohoto custom atributu
				.FirstOrDefault()?.Name;

			if (displayName.IsNullOrEmpty())
			{
				displayName = propertyName;
			}

			return displayName;
		}
	}
}
