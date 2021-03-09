using NUnit.Framework;
using System.Collections;
using TestProjectWP.Ajit.Models;
using TestProjectWP.Ajit.pages;

namespace TestProjectWP.Ajit.Tests
{
    class NunitDataTestExample : BaseTest
    {

        [TestCaseSource("TestDataNunit")]
        public void TestMultipleForms(Blank data)
        {
            BlankPage blankForm = new BlankPage(browser);
            blankForm.FillAndSubmitForm(data);

        }

        public static IEnumerable TestDataNunit
        {
            get
            {

                yield return new TestCaseData(new Blank("firstname", "test", "sad@com.com", "ad")).SetName("Test case for testing form");
                yield return new TestCaseData(new Blank("firstname1", "test", "sad@com.com", "ad")).SetName("TC2"); ;
                yield return new TestCaseData(new Blank("firstnam2e", "test", "sad@com.com", "ad")).SetName("TC3"); ;
                yield return new TestCaseData(new Blank("firstna3me", "test", "sad@com.com", "ad")).SetName("TC4"); ;
                yield return new TestCaseData(new Blank("firstna4me", "test", "sad@com.com", "ad")).SetName("TC5"); ;
                yield return new TestCaseData(new Blank("firstn4ame", "test", "sad@com.com", "ad")).SetName("TC6"); ;

            }
        }
    }
}
