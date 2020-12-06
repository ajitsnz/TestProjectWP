using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestProjectWP.Bdd.Framework
{
    [Binding]
    public sealed class Hooks1
    {
        public IWebDriver Driver;


        private readonly ScenarioContext _scenarioContext;

        public Hooks1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            _scenarioContext["Driver"] = Driver;
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

    }
}
