using OpenQA.Selenium;
using TestProjectWP.Ajit.Models;

namespace TestProjectWP.Ajit.pages
{
    public class BlankPage
    {
        IWebDriver driver;

        public BlankPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement firstName => driver.FindElement(By.Id("wpforms-16-field_0"));

        /*
        public IWebElement firstName() 
        {
            return driver.FindElement(By.Id("wpforms-16-field_0"));
        }
        */

        public IWebElement lastName => driver.FindElement(By.Id("wpforms-16-field_0-last"));
        public IWebElement email => driver.FindElement(By.Id("wpforms-16-field_1"));
        public IWebElement message => driver.FindElement(By.Id("wpforms-16-field_2"));

        public IWebElement SubmitButton => driver.FindElement(By.Id("wpforms-submit-16"));

        public void FillAndSubmitForm(string fname, string lname, string em, string msg)
        {
            firstName.SendKeys(fname);
            lastName.SendKeys(lname);
            email.SendKeys(em);
            message.SendKeys(msg);
            SubmitButton.Click();
        }

        public void FillAndSubmitForm(Blank data)
        {
            firstName.SendKeys(data.FirstName);
            lastName.SendKeys(data.LastName);
            email.SendKeys(data.Email);
            message.SendKeys(data.Message);
            SubmitButton.Click();
        }
    }
}
