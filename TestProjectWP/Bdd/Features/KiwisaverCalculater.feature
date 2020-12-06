Feature: KiwiSaver Retirement Calculator

@Story 1
Scenario Outline: Help messsage displayed on retirement calculator
    Given I am on retirement calculator page
	When I click on <Icon> help icon
	Then It should display <Message> message 
	Examples: 
	| Icon       | Message                                                                                                  |
	| CurrentAge | This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver |

@Story 2
Scenario Outline: Kiwisaver retirement projected balance
    Given I am on retirement calculator page
    When I entered all given values <Age>, <EmploymentStatus>, <Salary>, <KiwiMemberContribution>, <CurrentKiwiBalance>, <VoluntaryContributions>, <VoluntaryContributionsFrequency>, <RiskProfile>, <SavingsGoalAtRetirement>
	And I click on View your KiwiSaver retirement projections
	Then It should display estimated kiwisaver balance <Balance> at age 65
	Examples: 
	| Age | EmploymentStatus | Salary | KiwiMemberContribution | CurrentKiwiBalance | VoluntaryContributions | VoluntaryContributionsFrequency | RiskProfile  | SavingsGoalAtRetirement | Balance |
	| 30  | Employed         | 82000  | FourPercent            |                    |                        |                                 | Defensive    |                         | 436365     |
	| 45  | SelfEmployed     |        |                        | 100000             | 90                     | Fortnightly                     | Conservative | 290000                  | 259581     |
	| 55  | NotEmployed      |        |                        | 140000             | 10                     | Annually                        | Balanced     | 200000                  | 197679      |