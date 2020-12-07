using OpenQA.Selenium;
using TestProjectWP.Extensions;

namespace TestProjectWP.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) 
        {
            driver.Navigate().GoToUrl($"{BaseUrl}");
            IsPageDisplayed();
        }

        public void IsPageDisplayed() => Driver.WaitUntilElementIsDisplay(_title);
        protected By _title => By.XPath("//span[normalize-space()='KiwiSaver calculator']");
        protected By _RetirementPage => By.XPath("//h1[normalize-space()='KiwiSaver Retirement Calculator']");
        protected By _KiwiSaverCalculatorBy => By.XPath("//span[normalize-space()='KiwiSaver calculator']");
        protected By _KiwiSaverRetirementCalculatorBy => By.XPath("//span[@class='sw-sidenav-item-link-text last'][normalize-space()='KiwiSaver Retirement Calculator']");
        protected IWebElement _KiwiSaverCalculator => Driver.FindElement(_KiwiSaverCalculatorBy);
        protected IWebElement _KiwiSaverRetirementCalculator => Driver.FindElement(_KiwiSaverRetirementCalculatorBy);
        public void Click_KiwiSaverRetirementCalculator() => Driver.WaitUntilElementIsClickable(_KiwiSaverRetirementCalculatorBy).Click();
        public void Click_KiwiSaverCalculator() => Driver.WaitUntilElementIsClickable(_KiwiSaverCalculatorBy).Click();
    }
}
