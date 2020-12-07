using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProjectWP.Dictionaries;
using TestProjectWP.Models;
using TestProjectWP.Pages;

namespace TestProjectWP.Tests
{
    public class KiwisaverCalculatorDataDrivenTests : BaseTest
    {
        public KiwisaverCalculatorDataDrivenTests(Browser browser, string version) : base(browser, version) { }

		[SetUp]
		public void Setup() {
			
		}


		[TestCaseSource("CsvTestData")]
		public void KiwisaverCalculator_DataDriven_Test(User userDetails)
		{
			var kiwisaverCalculator = new KiwisaverCalculatorPage(Driver);
			kiwisaverCalculator.Fill_KiwisaverRetirementCalculator(userDetails);
			kiwisaverCalculator.Click_ViewProjection();
			kiwisaverCalculator.IsValidProjection(userDetails.Projection);
		}

		public static IEnumerable CsvTestData()
		{
			using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\testData\\KS_TestData.csv")), true))
			{
				while (csv.ReadNextRecord())
				{
					yield return new TestCaseData(new User()
					{
						CurrentAge = uint.Parse(csv["CurrentAge"]),
						EmploymentStatus = (EmploymentStatus)Enum.Parse(typeof(EmploymentStatus), csv["EmploymentStatus"]),//EmploymentStatus.NotEmployed,
						Salary = csv["Salary"] == "" ? 0 : uint.Parse(csv["Salary"]),
						VoluntaryContributions = csv["voluntaryContributions"] == "" ? 0 : uint.Parse(csv["voluntaryContributions"]),
						VCFrequency = csv["VoluntaryContributionsFrequency"]=="" ?Frequency.None : (Frequency)Enum.Parse(typeof(Frequency), csv["VoluntaryContributionsFrequency"]),
						CurrentKiwiBalance = csv["CurrentKiwiBalance"] == "" ? 0 : uint.Parse(csv["CurrentKiwiBalance"]),
						RiskProfile = csv["RiskProfile"] == "" ? RiskProfile.None :(RiskProfile)Enum.Parse(typeof(RiskProfile), csv["RiskProfile"]),
						SavingsGoalAtRetirement = csv["SavingsGoalAtRetirement"] == "" ? 0 : uint.Parse(csv["SavingsGoalAtRetirement"]),
						KiwiMemberContribution = csv["KiwiMemberContribution"] == "" ? KiwiMemberContribution.None : (KiwiMemberContribution)Enum.Parse(typeof(KiwiMemberContribution), csv["KiwiMemberContribution"]),
						Projection = uint.Parse(csv["Projection"])
					}).SetName(csv["Description"]);
				}
			}
		}
	}
}
