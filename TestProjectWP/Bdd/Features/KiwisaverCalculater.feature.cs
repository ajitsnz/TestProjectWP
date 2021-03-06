﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.5.0.0
//      SpecFlow Generator Version:3.5.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestProjectWP.Bdd.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("KiwiSaver Retirement Calculator")]
    public partial class KiwiSaverRetirementCalculatorFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "KiwisaverCalculater.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bdd/Features", "KiwiSaver Retirement Calculator", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Help messsage displayed on retirement calculator")]
        [NUnit.Framework.CategoryAttribute("Story")]
        [NUnit.Framework.CategoryAttribute("1")]
        [NUnit.Framework.TestCaseAttribute("CurrentAge", "This calculator has an age limit of 64 years old as you need to be under the age " +
            "of 65 to join KiwiSaver", null)]
        public virtual void HelpMesssageDisplayedOnRetirementCalculator(string icon, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Story",
                    "1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Icon", icon);
            argumentsOfScenario.Add("Message", message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Help messsage displayed on retirement calculator", null, tagsOfScenario, argumentsOfScenario);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
    testRunner.Given("I am on retirement calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.When(string.Format("I click on {0} help icon", icon), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.Then(string.Format("It should display {0} message", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Kiwisaver retirement projected balance")]
        [NUnit.Framework.CategoryAttribute("Story")]
        [NUnit.Framework.CategoryAttribute("2")]
        [NUnit.Framework.TestCaseAttribute("30", "Employed", "82000", "FourPercent", "", "", "", "Defensive", "", "436365", null)]
        [NUnit.Framework.TestCaseAttribute("45", "SelfEmployed", "", "", "100000", "90", "Fortnightly", "Conservative", "290000", "259581", null)]
        [NUnit.Framework.TestCaseAttribute("55", "NotEmployed", "", "", "140000", "10", "Annually", "Balanced", "200000", "197679", null)]
        public virtual void KiwisaverRetirementProjectedBalance(string age, string employmentStatus, string salary, string kiwiMemberContribution, string currentKiwiBalance, string voluntaryContributions, string voluntaryContributionsFrequency, string riskProfile, string savingsGoalAtRetirement, string balance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Story",
                    "2"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Age", age);
            argumentsOfScenario.Add("EmploymentStatus", employmentStatus);
            argumentsOfScenario.Add("Salary", salary);
            argumentsOfScenario.Add("KiwiMemberContribution", kiwiMemberContribution);
            argumentsOfScenario.Add("CurrentKiwiBalance", currentKiwiBalance);
            argumentsOfScenario.Add("VoluntaryContributions", voluntaryContributions);
            argumentsOfScenario.Add("VoluntaryContributionsFrequency", voluntaryContributionsFrequency);
            argumentsOfScenario.Add("RiskProfile", riskProfile);
            argumentsOfScenario.Add("SavingsGoalAtRetirement", savingsGoalAtRetirement);
            argumentsOfScenario.Add("Balance", balance);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Kiwisaver retirement projected balance", null, tagsOfScenario, argumentsOfScenario);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 14
    testRunner.Given("I am on retirement calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
    testRunner.When(string.Format("I entered all given values {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", age, employmentStatus, salary, kiwiMemberContribution, currentKiwiBalance, voluntaryContributions, voluntaryContributionsFrequency, riskProfile, savingsGoalAtRetirement), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.And("I click on View your KiwiSaver retirement projections", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.Then(string.Format("It should display estimated kiwisaver balance {0} at age 65", balance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
