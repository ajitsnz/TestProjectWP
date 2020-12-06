using NUnit.Framework;
using TestProjectWP.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectWP.Models
{
    public class User
    {
		public uint CurrentAge;
		public EmploymentStatus EmploymentStatus;
		public uint CurrentKiwiBalance;
		public uint VoluntaryContributions;
		public Frequency VCFrequency;
		public RiskProfile RiskProfile;
		public uint SavingsGoalAtRetirement;

		public KiwiMemberContribution KiwiMemberContribution;
		public uint Salary;

		public uint Projection;



		public User(
			uint _currentAge = 0,
			EmploymentStatus _employmentStatus = EmploymentStatus.None,
			uint _currentKiwisaverBalance = 0,
			uint _voluntaryContributions = 0,
			Frequency _voluntaryContributionsFrequency = Frequency.None,
			RiskProfile _RiskProfile = RiskProfile.None,
			uint _savingsGoalAtRetirement = 0,
			KiwiMemberContribution _kiwiMemberContribution = KiwiMemberContribution.None,
			uint _salary = 0,
			uint _projection = 0
			)
		{
			CurrentAge = _currentAge;
			EmploymentStatus = _employmentStatus;
			CurrentKiwiBalance = _currentKiwisaverBalance ;
			VoluntaryContributions = _voluntaryContributions ;
			VCFrequency = _voluntaryContributionsFrequency ;
			RiskProfile = _RiskProfile ;
			SavingsGoalAtRetirement = _savingsGoalAtRetirement ;

            if (_employmentStatus == EmploymentStatus.Employed)
            {
                Salary = _salary;
                KiwiMemberContribution = _kiwiMemberContribution;
            }
			Projection = _projection;
		}

		public void CreateRandomIndividual(
			uint _currentAge = 0,
			EmploymentStatus _employmentStatus = EmploymentStatus.None,
			uint _currentKiwisaverBalance = 0,
			uint _voluntaryContributions = 0,
			Frequency _voluntaryContributionsFrequency = Frequency.None,
			RiskProfile _RiskProfile = RiskProfile.None,
			uint _savingsGoalAtRetirement = 0,
			KiwiMemberContribution _kiwiMemberContribution = KiwiMemberContribution.None,
			uint _salary = 0
			)
		{
			CurrentAge = _currentAge != 0 ? _currentAge : TestContext.CurrentContext.Random.NextUInt(18, 64); 
			EmploymentStatus = _employmentStatus != EmploymentStatus.None ? _employmentStatus : EmploymentStatus.Employed;
			CurrentKiwiBalance = _currentKiwisaverBalance != 0 ? _currentKiwisaverBalance : TestContext.CurrentContext.Random.NextUInt();
			VoluntaryContributions = _voluntaryContributions != 0 ? _voluntaryContributions : TestContext.CurrentContext.Random.NextUInt(1000);
			VCFrequency = _voluntaryContributionsFrequency != Frequency.None ? _voluntaryContributionsFrequency : Frequency.Fortnightly;
			RiskProfile = _RiskProfile != RiskProfile.None ? _RiskProfile : RiskProfile.Growth;
            SavingsGoalAtRetirement = _savingsGoalAtRetirement != 0 ? _savingsGoalAtRetirement : TestContext.CurrentContext.Random.NextUInt();

			if (_employmentStatus == EmploymentStatus.Employed)
			{
				Salary = _salary != 0 ? _salary : TestContext.CurrentContext.Random.NextUInt();
				KiwiMemberContribution = _kiwiMemberContribution != KiwiMemberContribution.None ? _kiwiMemberContribution : KiwiMemberContribution.ThreePercent;
			}
		}
	};
}