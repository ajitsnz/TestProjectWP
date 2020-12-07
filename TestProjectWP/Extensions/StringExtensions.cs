using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestProjectWP.Extensions
{
	public static class StringExtensions
	{
		public static string FirstCharToUpper(this string input)
		{
			switch (input)
			{
				case null: throw new ArgumentNullException(nameof(input));
				case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
				default: return input.First().ToString().ToUpper() + input.Substring(1);
			}
		}

		public static string StringToInteger(this String input) {
			if(input != null) 
			return Regex.Replace(input, "[^0-9]+", string.Empty); 
			return input;
		}
	}

}
