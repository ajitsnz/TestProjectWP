using OpenQA.Selenium;
using System;

namespace TestProjectWP.Pages
{
	class BasePage
	{
		public IWebDriver Driver { get; }
		public string BaseUrl = "https://www.westpac.co.nz";

		protected BasePage(IWebDriver driver)
		{
			Driver = driver ?? throw new ArgumentNullException(nameof(driver));
		}
	}
}
