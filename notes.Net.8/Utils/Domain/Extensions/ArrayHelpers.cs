using System;
namespace notes.Net8.Utils.Domain.Extensions
{
	public static class ArrayHelpers
	{
		public static void _<T>(this IEnumerable<T> collection )
		{
			foreach (var item in collection)
				Debug.WriteLine(item);
		}
	}
}

