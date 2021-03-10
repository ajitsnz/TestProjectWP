using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TestProjectWP.Mayuri.Pages;

namespace TestProjectWP.Mayuri.Tests
{
    [TestFixture]
    class SetUp

    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Login()
        {
            driver = new ChromeDriver();
            driver.Url =("http://qaauto.co.nz/billing-order-form/");
            
            driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
            driver.FindElement(By.Id("wpforms-submit-locked-24")).Click();

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
