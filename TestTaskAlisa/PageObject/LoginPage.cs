using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestTaskAlisa.PageObject
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']/input[@type='email']")]
        private IWebElement EmailInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']/input[@type='password']")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'loginbtn')]")]
        private IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//h3[@class='RTL']")]
        private IWebElement UserName;

        public AccountPage GoToAccountPage(string login, string pass)
        {
            EmailInput.SendKeys(login);
            PasswordInput.SendKeys(pass);
            Thread.Sleep(5000);
            LoginButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

           Thread.Sleep(5000);

            return new AccountPage(driver);
        }
    }
}
