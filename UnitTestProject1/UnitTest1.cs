//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;
        PractiseFormElement check;
        string driverPath = "C:\\Automation\\Driver\\Chrome";
        //It is better approach to same input paramter in config file
        string firstName = "Hassan";
        string lastName = "Imam";
        // string gender = "Male";
        string mobileNumber = "3413547197";

        [SetUp]
        public void InitializePage()
        {
            driver = new ChromeDriver(driverPath);
            check = new PractiseFormElement(driver);
            string url = "https://demoqa.com/";
            check.goToUrl(url);
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void CaseOne()
        {
            
            try
            {
                check.clickOnForm();
                check.clickOnPractiseForm();
                check.enterFormFields(firstName, lastName, mobileNumber);
                check.clickSubmitButton();
                //Assertion Form
                Assert.IsTrue(true, "form is not submitted scuessfully",check.verifyForm("Thanks for submitting the form"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void CaseTwo()
        {
            int errorCount = 0;
            try
            {
                check.clickOnForm();
                check.enterFormFields(firstName, lastName, mobileNumber);
                check.clickSubmitButton();
                //Assertion Form
                Assert.IsTrue(true, "form is not submitted scuessfully", check.verifyForm("Thanks for submitting the form"));
                errorCount += check.verifyInputsParameter(firstName + " " + lastName);
                errorCount += check.verifyInputsParameter(mobileNumber, 3);

                if (errorCount > 0)
                    Console.WriteLine("multiple assertion are failed checked output of console window...");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
