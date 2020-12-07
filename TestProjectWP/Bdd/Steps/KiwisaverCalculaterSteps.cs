using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestProjectWP.Bdd.Framework;
using TestProjectWP.Dictionaries;
using TestProjectWP.Models;
using TestProjectWP.Pages;

namespace TestProjectWP.Bdd.Steps
{
    [Binding]
    public class KiwisaverCalculaterSteps 
    {

        IWebDriver driver;
        KiwisaverCalculatorPage kiwiSaverCalculator;
        private readonly ScenarioContext _scenarioContext;

        public KiwisaverCalculaterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"I am on retirement calculator page")]
        public void GivenIAmOnRetirementCalculatorPage()
        {
            driver = (IWebDriver)_scenarioContext["Driver"];
            kiwiSaverCalculator = new KiwisaverCalculatorPage(driver);

        }
        
        [When(@"I click on (.*) help icon")]
        public void WhenIClickOnHelpIcon(string icon)
        {
            if(icon.Equals("CurrentAge")) kiwiSaverCalculator.ClickCurrentAgeInfo();
        }
        
        [Then(@"It should display (.*) message")]
        public void ThenItShouldDisplayMessage(string message)
        {
            kiwiSaverCalculator.IsValidCurrentAgeHelpTextDisplayed(message);
        }

        [When(@"I entered all given values (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIEnteredAllGivenUser(String currentAge, String employmentStatus, String salary, String kiwiMemberContribution, String currentKiwiBalance, String voluntaryContributions, String voluntaryContributionsFrequency, String riskProfile, String savingsGoalAtRetirement)
        {

            //Todo : Clean up required move to commons... 
            var userDetails = new User()
            {
            CurrentAge = uint.Parse(currentAge),
			EmploymentStatus = (EmploymentStatus)Enum.Parse(typeof(EmploymentStatus), employmentStatus),//EmploymentStatus.NotEmployed,
			Salary = salary == "" ? 0 : uint.Parse(salary),
			VoluntaryContributions = voluntaryContributions == "" ? 0 : uint.Parse(voluntaryContributions),
			VCFrequency = voluntaryContributionsFrequency == "" ? Frequency.None : (Frequency)Enum.Parse(typeof(Frequency), voluntaryContributionsFrequency),
			CurrentKiwiBalance = currentKiwiBalance == "" ? 0 : uint.Parse(currentKiwiBalance),
			RiskProfile = riskProfile == "" ? RiskProfile.None : (RiskProfile)Enum.Parse(typeof(RiskProfile), riskProfile),
			SavingsGoalAtRetirement = savingsGoalAtRetirement == "" ? 0 : uint.Parse(savingsGoalAtRetirement),
			KiwiMemberContribution = kiwiMemberContribution == "" ? KiwiMemberContribution.None : (KiwiMemberContribution)Enum.Parse(typeof(KiwiMemberContribution), kiwiMemberContribution),
            };

            kiwiSaverCalculator.Fill_KiwisaverRetirementCalculator(userDetails);

        }

        [When(@"I click on View your KiwiSaver retirement projections")]
        public void WhenIClickOnViewYourKiwisaverRetirementProjections()
        {
            kiwiSaverCalculator.Click_ViewProjection();
        }

        [Then(@"It should display estimated kiwisaver balance (.*) at age 65")]
        public void ThenItShouldDisplayUserPojectionForKiwisaver(string balance)
        {
            kiwiSaverCalculator.IsValidProjection(uint.Parse(balance));
        }



    }
}
