using OpenQA.Selenium;
using TestProjectWP.Extensions;
using TestProjectWP.Models;
using TestProjectWP.Dictionaries;
using FluentAssertions;

namespace TestProjectWP.Pages
{
	class KiwisaverCalculatorPage : BasePage
	{
		public KiwisaverCalculatorPage(IWebDriver driver) : base(driver)
		{
			driver.Navigate().GoToUrl($"{BaseUrl}/kiwisaver/calculators/kiwisaver-calculator/");
			this.SwitchTo();
		}

		protected IWebElement _currentAge => Driver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.CurrentAge')]//input[contains(@type,'text')]"));
		protected IWebElement _employmentStatus => Driver.FindElement(By.XPath("//div[contains(@ng-model,'ctrl.data.EmploymentStatus')]//div[contains(@class,'well-value ng-binding')]"));
		protected IWebElement _salary => Driver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.AnnualIncome')]//input[@type='text']"));
		protected IWebElement _currentKiwisaverBalance => Driver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.KiwiSaverBalance')]//input[contains(@placeholder,'Optional')]"));
		protected IWebElement _voluntaryContributions => Driver.FindElement(By.XPath("//div[contains(@class,'control-with-period control-with-prefix currency-control')]//input[contains(@placeholder,'Optional')]"));
		protected IWebElement _voluntaryContributionsFrequency => Driver.FindElement(By.XPath("//div[@class='wpnib-field-voluntary-contributions field-group ng-isolate-scope']//div[@class='ng-scope ng-isolate-scope ng-pristine ng-valid wpnib-drop-down']//div[1]//div[1]//div[1]"));
		protected IWebElement _savingsGoalAtRetirement => Driver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.SavingsGoal')]//input[contains(@placeholder,'Optional')]"));
		protected IWebElement _Submit => Driver.FindElement(By.XPath("//span[normalize-space()='View your KiwiSaver retirement projections']"));
		protected IWebElement _currentAgeInfo => Driver.FindElement(By.XPath("//div[contains(@help-id,'CurrentAge')]//i[contains(@class,'icon')]"));
		public void ClickCurrentAgeInfo() => _currentAgeInfo.Click();
		public IWebElement _currentAgeInfoHelp => Driver.FindElement(By.XPath("//*[@id='widget']/div/div[1]/div/div[1]/div/div[1]/div/div/div/div[2]/div[1]/div[2]/div/p"));
		public string _currentAgeInfoHelpText = "This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.";
		// "This calculator has an age limit of 18 to 64 years old."; 

		public void IsValidCurrentAgeHelpTextDisplayed(string message = "")
		{
			CustomTestContext.WriteLine("Check CurrentAgeHelpText message");
			if (!message.Equals("")) _currentAgeInfoHelpText = message;
			_currentAgeInfoHelp.Text.Should().Be(_currentAgeInfoHelpText);
		}


		public void IsValidProjection(uint expectedValue)
		{
			CustomTestContext.WriteLine("Check Balance Projection value");
			var actualValue = _projection.Text.StringToInteger();
			actualValue.Should().Be(expectedValue.ToString());
		}

		protected IWebElement _projection => Driver.FindElement(By.XPath("//span[@class='result-value result-currency ng-binding']"));

		public void SetFrequency(Frequency value)
		{
			if (value != Frequency.None) _voluntaryContributionsFrequency.Click();

			switch (value)
			{
				case Frequency.Weekly:
					Driver.FindElement(By.XPath($"//li[contains(@value,'week')]//div[contains(@class,'label')]")).Click();
					break;
				case Frequency.Fortnightly:
					Driver.FindElement(By.XPath($"//span[normalize-space()='Fortnightly']")).Click();
					break;
				case Frequency.Monthly:
					Driver.FindElement(By.XPath($"//span[normalize-space()='Monthly']")).Click();
					break;
				case Frequency.Annually:
					Driver.FindElement(By.XPath($"//span[normalize-space()='Annually']")).Click();
					break;
			}
		}
		public void SetEmploymentStatus(EmploymentStatus value)
		{
			if (value != EmploymentStatus.None) _employmentStatus.Click();
			var path = "//span[normalize-space()=";
			switch (value)
			{
				case EmploymentStatus.Employed:
					Driver.FindElement(By.XPath($"{path}'Employed']")).Click();
					break;
				case EmploymentStatus.SelfEmployed:
					Driver.FindElement(By.XPath($"{path}'Self-employed']")).Click();
					break;
				case EmploymentStatus.NotEmployed:
					Driver.FindElement(By.XPath($"{path}'Not employed']")).Click();
					break;
			}
		}

		public void SetKiwimemberContribution(KiwiMemberContribution value)
		{
			var path = "radio-option-04";
			switch (value)
			{
				case KiwiMemberContribution.ThreePercent:
					Driver.FindElement(By.Id($"{path}C")).Click();
					break;
				case KiwiMemberContribution.FourPercent:
					Driver.FindElement(By.Id($"{path}F")).Click();
					break;
				case KiwiMemberContribution.SixPercent:
					Driver.FindElement(By.Id($"{path}I")).Click();
					break;
				case KiwiMemberContribution.EightPercent:
					Driver.FindElement(By.Id($"{path}L")).Click();
					break;
				case KiwiMemberContribution.TenPercent:
					Driver.FindElement(By.Id($"{path}O")).Click();
					break;

			}
		}

		public void SetRiskProfile(RiskProfile value)
		{
			var path = "//*[@id='radio-option";
			switch (value)
			{
				case RiskProfile.Defensive:
					Driver.FindElement(By.XPath($"{path}-013']")).Click();
					break;
				case RiskProfile.Conservative:
					Driver.FindElement(By.XPath($"{path}-016']")).Click();
					break;
				case RiskProfile.Balanced:
					Driver.FindElement(By.XPath($"{path}-019']")).Click();
					break;
				case RiskProfile.Growth:
					Driver.FindElement(By.XPath($"{path}-01C']")).Click();
					break;
			}
		}


		public KiwisaverCalculatorPage FillCurrentAge(uint age)
		{
			CustomTestContext.WriteLine($"Fill Current age - '{age}'");
			_currentAge.SendKeys(age.ToString());
			return this;
		}


		public KiwisaverCalculatorPage Fill_KiwisaverRetirementCalculator(User user)
		{
			_currentAge.SendText(user.CurrentAge.ToString());
			SetEmploymentStatus(user.EmploymentStatus);
			if (user.EmploymentStatus.Equals(EmploymentStatus.Employed)) _salary.SendText(user.Salary.ToString());
			SetKiwimemberContribution(user.KiwiMemberContribution);
			_currentKiwisaverBalance.SendText(user.CurrentKiwiBalance.ToString());
			_voluntaryContributions.SendText(user.VoluntaryContributions.ToString());
			SetRiskProfile(user.RiskProfile);
			_savingsGoalAtRetirement.SendText(user.SavingsGoalAtRetirement.ToString());
			SetFrequency(user.VCFrequency);
			return this;
		}

		public void Click_ViewProjection() => _Submit.Click();

		//todo cleanup 
		private void SwitchTo()
		{
			Driver.SwitchTo().DefaultContent();
			Driver.SwitchTo().Frame(0);
		}

	}
}
