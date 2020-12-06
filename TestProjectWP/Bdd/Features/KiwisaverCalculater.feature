Feature: KiwisaverCalculater
Given User Clicks information icon besides Current age the message 
“This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.” is displayed below the current age
field.


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
    When I entered all given values <Age>, <EmploymentStatus>,<Salary>, <KiwiMemberContribution>, <RiskProfile>
	And I click on View your KiwiSaver retirement projections
	Then It should display estimated kiwisaver balance <Balance> at age 65
	Examples: 
	| Age | EmploymentStatus | Salary | KiwiMemberContribution | RiskProfile | Balance |
	| 30  | Employed        | 82000  | FourPercent            | Defensive   | 436365     |
