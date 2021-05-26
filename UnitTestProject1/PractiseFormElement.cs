using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public partial class PractiseFormElement
    {
        IWebDriver driver;

        public PractiseFormElement(IWebDriver driver)
        {
            this.driver = driver;
        }

        By form = By.CssSelector("div.category-cards div[class$='top-card']");
        By mainPageVisible = By.ClassName("category-cards");
        By practiseFormVisible = By.ClassName("accordion");
        By practiceForm = By.XPath("//li/span[text()='Practice Form']");
        By firstNameElement = By.CssSelector("input[id='firstName']");
        By secondNameElement = By.CssSelector("input[id='lastName']");
        By genderElement = By.XPath("//div/input[@id='gender-radio-1']");
        By mobileNumberElement = By.CssSelector("input[id='userNumber']");

        public void goToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("category-cards")));
        }

        public void waitForElement(By by, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        //index = 1 is defined thats click on form
        public void clickOnForm(int index = 1)
        {
            IList<IWebElement> clickOnForm = driver.FindElements(form);
            clickOnForm[index].Click();
            waitForElement(practiseFormVisible);
        }

        public void clickOnPractiseForm()
        {
            IWebElement clickPractiseForm = driver.FindElement(practiceForm);
            clickPractiseForm.Click();
        }

        public void enterFormFields(string startName, string secondName, string inputMobileNumber)
        {
            IWebElement firstName = driver.FindElement(firstNameElement);
            firstName.SendKeys(startName);
            Thread.Sleep(2);
            IWebElement lastName = driver.FindElement(secondNameElement);
            lastName.SendKeys(secondName);
            Thread.Sleep(2);
            var gender = driver.FindElement(genderElement);
            gender.Click();
            Thread.Sleep(2);
            IWebElement mobileNumber = driver.FindElement(mobileNumberElement);
            lastName.SendKeys(inputMobileNumber);
            Thread.Sleep(2);
        }

        public void clickSubmitButton()
        {
            IWebElement submitButton = driver.FindElement(By.CssSelector("button[id='submit']"));
            submitButton.Click();
        } 

        public bool verifyForm(string expectedText)
        {
            string text = driver.FindElement(By.CssSelector("div[id='example-modal-sizes-title-lg']")).Text;
            if (text.Contains(expectedText))
                return true;
            return false;
        }

        public int verifyInputsParameter(string text ,int index = 0)
        {
            IList<IWebElement> element = driver.FindElements(By.CssSelector("div.table-responsive table tbody tr"));
            string inputText = element[index].FindElements(By.TagName("td"))[1].Text;
            if (inputText.Equals(text))
                return 0;
            return 1;
        }

        public int verify (string a , string b)
        {
            if (a.Equals(b))
                return 0;
            return 1;
        }
    }

}
