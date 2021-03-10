using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectWP.Ajit.Tests
{
    public class BaseTest
    {
        public IWebDriver browser;

        [SetUp]
        public void Setup()
        {
            browser = new ChromeDriver();
            browser.Url = "http://qaauto.co.nz/test-blank-form/";
            browser.FindElement(By.Id("wpforms-locked-16-field_form_locker_password")).SendKeys("Testing");
            browser.FindElement(By.Id("wpforms-submit-locked-16")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            browser.Quit();

        }

    }
}
