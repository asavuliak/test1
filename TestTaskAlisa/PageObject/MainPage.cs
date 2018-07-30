using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace TestTaskAlisa.PageObject
{
    class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//nav//li[@id='li_myaccount']")]
        private IWebElement MyAccount;

        [FindsBy(How = How.XPath, Using = "//li[@id='li_myaccount' and @class='open']//ul//a[contains(text(), 'Login')]")]
        private IWebElement Login;

        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public LoginPage GoLoginPage()
        {
            MyAccount.Click();
            Login.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return new LoginPage(driver);
        }
    }
}
