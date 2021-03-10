using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProjectWP.Mayuri.Pages;

namespace TestProjectWP.Mayuri.Tests
{
    class TestMethod1 : SetUp
    {
        [Test]
        public void DataAsParameter()
        {
            BillingForm billingobj = new BillingForm(driver);
            billingobj.FirstName.SendKeys("Mayuri");
            billingobj.LastName.SendKeys("Gohil");
            billingobj.Email.SendKeys("Test@test.com");
            billingobj.Phone.SendKeys("12312131234");
            billingobj.State.SelectByValue("AL");
            billingobj.AddressLine1.SendKeys("test Address 1");
            billingobj.AddressLine2.SendKeys("test Address 2");
            billingobj.City.SendKeys("Auckland");
            billingobj.Zipcode.SendKeys("678912314");
            billingobj.AvailableItems.Click();
            billingobj.Comment.SendKeys("test comments");
            Thread.Sleep(5000);
            billingobj.Submit.Click();
        }
    }
}
