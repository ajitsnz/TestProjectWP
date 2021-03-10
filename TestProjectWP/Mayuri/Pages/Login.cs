using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectWP.Mayuri.Pages
{
    class Login
         
    {
        public IWebDriver driver;
        public void LoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qaauto.co.nz/billing-order-form/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("wpforms-locked-16-field_form_locker_password")).SendKeys("Testing");
            driver.FindElement(By.Id("wpforms-submit-locked-16")).Click();

        }
    }
}
