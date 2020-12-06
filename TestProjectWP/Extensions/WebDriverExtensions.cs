using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestProjectWP.Extensions
{
	public static class WebDriverExtensions
	{
		public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
		public static readonly TimeSpan ImplicitWait = TimeSpan.FromSeconds(3);
		public static readonly TimeSpan NoWait = TimeSpan.Zero;

		public static bool WaitUntilElementIsDisplay(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				return wait.Until(d => d.FindElement(by).Displayed);
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
			catch (StaleElementReferenceException)
			{
				return wait.Until(d => d.FindElement(by).Displayed);
			}
		}

		public static void TakeScreenshot(this IWebDriver driver, string path)
		{
			Directory.CreateDirectory(path);

			var testName = TestContext.CurrentContext.Test.Name;
			var correctTestName = string.Join("", testName.Split(Path.GetInvalidFileNameChars()));
			var fileName = $"{Path.Combine(path, correctTestName)}_{DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss")}.png";
			var screenShot = ((ITakesScreenshot)driver).GetScreenshot();

			screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

			//AllureLifecycle cycle = AllureLifecycle.Instance;
			//cycle.AddAttachment(fileName, $"{correctTestName}");
		}

		public static object ExecuteScript(this IWebDriver driver, string script, params object[] args)
		{
			return ((IJavaScriptExecutor) driver).ExecuteScript(script, args);
		}

		public static bool WaitUntilElementIsEnabled(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				return wait.Until(d => ((IWebDriver)d).FindElement(by).Enabled);
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
		}

		public static IAlert WaitUntilAlertIsDisplay(this IWebDriver driver, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				return wait.Until(ExpectedConditions.AlertIsPresent());
			}
			catch (WebDriverTimeoutException)
			{
				throw new NoAlertPresentException();
			}
		}

		public static bool WaitUntilElementIsAppear(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				wait.Until(d => d.FindElement(by));
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return true;
			}
			catch (WebDriverTimeoutException)
			{
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return false;
			}
		}

		public static bool WaitUntilElementIsDisappeared(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			driver.Manage().Timeouts().ImplicitWait = NoWait;
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				var result = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return result;
			}
			catch (WebDriverTimeoutException)
			{
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return false;
			}
		}

		public static IWebElement WaitUntilElementIsClickable(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				return wait.Until(ExpectedConditions.ElementToBeClickable(by));
			}
			catch (WebDriverTimeoutException)
			{
				return null;
			}
			catch (StaleElementReferenceException)
			{
				return wait.Until(ExpectedConditions.ElementToBeClickable(by));
			}
		}

		public static bool IsTextPresentInElementLocated(this IWebDriver driver, By by, string text)
		{
			var wait = new WebDriverWait(driver, ImplicitWait);

			try
			{
				return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
		}

		public static bool IsElementExist(this IWebDriver driver, By by)
		{
			driver.Manage().Timeouts().ImplicitWait = NoWait;

			try
			{
				driver.FindElement(by);
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return true;
			}
			catch (NoSuchElementException)
			{
				driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
				return false;
			}
		}

		public static void CloseAlertIfExist(this IWebDriver driver)
		{
			var alert = driver.SwitchTo().Alert();

			CustomTestContext.WriteLine("Alert text: {0}.", alert.Text);
			CustomTestContext.WriteLine("Click Cancel");
			alert.Dismiss();
		}

		public static void SendHotKeys(this IWebDriver driver, string key, bool control = false, bool shift = false, bool alt = false)
		{
			var keysCombinationDescriptor = new StringBuilder();
			if (control)
			{
				keysCombinationDescriptor.Append("Ctrl+");
			}
			if (alt)
			{
				keysCombinationDescriptor.Append("Alt+");
			}
			if (shift)
			{
				keysCombinationDescriptor.Append("Shift+");
			}
			keysCombinationDescriptor.Append(key);

			CustomTestContext.WriteLine($"Press {keysCombinationDescriptor}");
			var actions = new Actions(driver);

			if (control)
			{
				actions.KeyDown(Keys.Control);
			}
			if (shift)
			{
				actions.KeyDown(Keys.Shift);
			}
			if (alt)
			{
				actions.KeyDown(Keys.Alt);
			}

			Thread.Sleep(500);
			actions.SendKeys(key);

			if (control)
			{
				actions.KeyUp(Keys.Control);
			}
			if (shift)
			{
				actions.KeyUp(Keys.Shift);
			}
			if (alt)
			{
				actions.KeyUp(Keys.Alt);
			}

			actions.Build().Perform();
		}

		public static void ClickOnElementsWithHoldDownCtrl(this IWebDriver driver, IEnumerable<IWebElement> webElements)
		{
			var actions = new Actions(driver);
			actions.KeyDown(Keys.Control);

			foreach (var webElement in webElements)
			{
				actions.MoveToElement(webElement);
				actions.Click(webElement);
			}

			actions.KeyUp(Keys.Control);

			actions.Build().Perform();
		}

		public static void ClickOnElementWithHoldDownShift(this IWebDriver driver, IWebElement webElement)
		{
			var actions = new Actions(driver);

			actions
				.KeyDown(Keys.Shift)
				.MoveToElement(webElement)
				.Click(webElement)
				.KeyUp(Keys.Shift)
				.Build()
				.Perform();
		}
	}
}
