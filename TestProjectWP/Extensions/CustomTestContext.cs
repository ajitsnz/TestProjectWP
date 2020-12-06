using System;
using System.Diagnostics;
using System.Linq;

using NUnit.Framework;

namespace TestProjectWP.Extensions
{
	class CustomTestContext
	{
		public static void WriteLine(string message, params object[] arguments)
		{
			StackTrace stackTrace = new StackTrace();

			var m = arguments.Any() ? string.Format(message, arguments) : message;

			TestContext.WriteLine(string.Format("{0}  {1}: {2}", DateTime.Now, stackTrace.GetFrame(1).GetMethod().ReflectedType.Name, m));
		}
	}

}
