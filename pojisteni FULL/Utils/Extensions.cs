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
	}
}
