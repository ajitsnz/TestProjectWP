using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using TestProjectWP.Ajit.Models;
using TestProjectWP.Ajit.pages;

namespace TestProjectWP.Ajit.Tests
{
    public class TestBlankForm : BaseTest
    {

        [Test]
        public void TestForm()
        {
            BlankPage blankForm = new BlankPage(browser);
            blankForm.firstName.SendKeys("TestFirstname");
            blankForm.lastName.SendKeys("LastName");
            blankForm.email.SendKeys("test@test.com");
            blankForm.message.SendKeys("sadf sadf sad fsad fsad");

            blankForm.SubmitButton.Click();

        }


        [TestCase("fir", "asdfsa", "adf@adsfa.com", "asdf")]
        [TestCase("fir", "asdfsa", "adf@adsfa.com", "asdf1")]
        [TestCase("fir1", "asdfsa", "adf@adsfa.com", "asdf1")]
        public void TestFormFillForm(string fname, string lname, string em, string msg)
        {
            BlankPage blankForm = new BlankPage(browser);
            blankForm.FillAndSubmitForm(fname, lname, em, msg);

        }


        //Best practice
        [Test]
        public void TestFillFormFromModel()
        {
            Blank data = new Blank("firstname", "test", "sad@com.com", "ad");

            BlankPage blankForm = new BlankPage(browser);

            blankForm.FillAndSubmitForm(data);

        }




        public static IEnumerable TestDataNunit1
        {
            get
            {
                for (int i = 0; i < 500; i++)
                {
                    yield return new TestCaseData(new Blank("firstname" + i, "test", "sad@com.com", "ad")).SetName("Test Case count " + i);

                }

            }
        }


        [TestCaseSource("TestDataCSV")]
        public void TestMultipleWithCSV(Blank data)
        {
            BlankPage blankForm = new BlankPage(browser);
            blankForm.FillAndSubmitForm(data);

        }


        public static IEnumerable TestDataCSV()
        {
            string filePath = "\\ajit\\data\\blankForm.csv";
            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData(new Blank(csv["firstname"], csv["lastname"], csv[2], csv[3])).SetName(csv["testcasename"]);
                }
            }
        }
    }
}
