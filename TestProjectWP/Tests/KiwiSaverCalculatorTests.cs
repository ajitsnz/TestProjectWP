using System.Collections;
using NUnit.Framework;
using TestProjectWP.Dictionaries;
using TestProjectWP.Models;
using TestProjectWP.Pages;

namespace TestProjectWP.Tests
{
	public class KiwiSaverCalculatorTests : BaseTest
	{
		public KiwiSaverCalculatorTests(Browser browser, string version) : base(browser, version) {}

		[SetUp]
		public void SetUp() {
		  		
		}

		[TestCaseSource("TestCaseData")]
		public void KiwiSaverTest(User userDetails)
		{
		    var kiwisaverCalculator = new KiwisaverCalculatorPage(Driver);
            kiwisaverCalculator.FillKiwisaverRetirementCalculator(userDetails);
            kiwisaverCalculator.Submit();
			kiwisaverCalculator.IsValidProjection(userDetails.projection);
		}

		[Test]
		public void VerifyCurrentAgeHelpText() {
	        var kiwiSaverCalculator = new KiwisaverCalculatorPage(Driver);
            kiwiSaverCalculator.ClickCurrentAgeInfo();
			kiwiSaverCalculator.IsValidCurrentAgeHelpTextDisplayed();
		}

		/*I want that the KiwiSaver Retirement Calculator 
		 * users are able to calculate what their KiwiSaver projected balance would be at retirement */

		public static IEnumerable TestCaseData
		{
			get
			{
				/*
				 * User whose Current age is 30 is Employed @ a Salary 82000 p/a, 
				 * contributes to KiwiSaver @ 4% and 
				 * chooses a Defensive risk profile 
				 * can calculate his projected balances at retirement.
				 * 
				 * Added Projeced value for validaion - 436365  Todo : (Question) ?
				 * */

				yield return new TestCaseData(new User() { 
					CurrentAge = 30, 
					EmploymentStatus= EmploymentStatus.Employed, 
					Salary = 82000, 
					KiwiMemberContribution = KiwiMemberContribution.FourPercent, 
					RiskProfile = RiskProfile.Defensive,
					projection = 436365
				}).SetName("Kiwisaver projected balance for Employed user at age 30");


				/*
				 * User whose current aged 45 is Self-employed, 
				 * current KiwiSaver balance is $100000, 
				 * voluntary contributes $90 fortnightly and 
				 * chooses Conservative risk profile 
				 * with saving goals requirement of $290000 
				 * can calculate his projected balances at retirement.
				 * 
				 * Added Projeced value for validaion - 259581  Todo : (Question) ?
				 */

				yield return new TestCaseData(new User()
				{
					CurrentAge = 45,
					EmploymentStatus = EmploymentStatus.SelfEmployed,
					voluntaryContributions = 90,
					VoluntaryContributionsFrequency = Frequency.Fortnightly,
					CurrentKiwiBalance = 100000,
					RiskProfile = RiskProfile.Conservative,
					SavingsGoalAtRetirement = 290000,
					projection = 259581
				}).SetName("Kiwisaver projected balance for Self Employed user at age 45");


				/*
				 * User whose current aged 55 is not employed, 
				 * current KiwiSaver balance is $140000, 
				 * voluntary contributes $10 annually 
				 * and chooses Balanced risk profile 
				 * with saving goals requirement of $200000 
				 * is able to calculate his projected balances at retirement.
				 * 
				 * Added Projeced value for validaion - 197679  Todo : (Question) ?
				 * */


				yield return new TestCaseData(new User()
				{
					CurrentAge = 55,
					EmploymentStatus = EmploymentStatus.NotEmployed,
					voluntaryContributions = 10,
					VoluntaryContributionsFrequency = Frequency.Annually,
					CurrentKiwiBalance = 140000,
					RiskProfile = RiskProfile.Balanced,
					SavingsGoalAtRetirement = 200000,
					projection = 197679
				}).SetName("Kiwisaver projected balance for unemployeed user at age 55");

			}
		}

		/* Extra test : 
		 * Example of Test with Random Data*/
		[TestCase]		
		[Repeat(2)] //Every time it will generate new data...
		public void RandomDataTest()
		{
			//Creating random data 
			User randomIndividualData = new User();

			var kiwisaverCalculator = new KiwisaverCalculatorPage(Driver);
			randomIndividualData.CreateRandomIndividual();
            kiwisaverCalculator.FillKiwisaverRetirementCalculator(randomIndividualData);
			kiwisaverCalculator.Submit();
		}
	}
}
