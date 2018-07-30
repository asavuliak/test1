using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestTaskAlisa.PageObject
{
    class AccountPage
    {
        private IWebDriver driver;

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='tab-content']//a[@class='dark']/b[contains(text(), 'Hurghada Sunset Desert Safari')]")]
        private IWebElement HotelTitle;

        [FindsBy(How = How.XPath, Using = "//div//b[contains(text(), 'Hurghada Sunset Desert Safari')]/../../../div//span[contains(@class, 'btn btn-primary btn-block write_review')]")]
        private IWebElement WriteReviewButton;


        public IWebElement SelectCleanOption(string title, string clean)
        {
            return driver.FindElement(By.XPath("//h4[@class='modal-title'][contains(., '" + title + "')]/..//..//select[@id='7' and @name='reviews_clean']/option[@value='" + clean + "']"));
        }

        public IWebElement SelectStaffOption(string title, string staff)
        {
            return driver.FindElement(By.XPath("//h4[@class='modal-title'][contains(., '" + title + "')]/..//..//select[@id='7' and @name='reviews_staff']/option[@value='" + staff + "']"));
        }

        public IWebElement TextArea(string title)
        {
            return driver.FindElement(By.XPath("//h4[@class='modal-title'][contains(., '" + title + "')]/..//..//textarea[@name='reviews_comments']"));
        }

        public IWebElement SubmitButton(string title)
        {
            return driver.FindElement(By.XPath("//h4[@class='modal-title'][contains(., '"+title+"')]/..//..//button[@class='btn btn-primary addreview']"));
        }

        public IWebElement InvoiceButton(string title)
        {
            return driver.FindElement(By.XPath("//div//b[contains(text(), '"+title+"')]/../../../div//a[@class='btn btn-action btn-block']"));
        }
        public void WriteReviewPopUp()
        {
            WriteReviewButton.Click();

        }

        public void scrollToelement()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", HotelTitle);
        }

        public void elementIsDisplayed()
        {
            Assert.IsTrue(HotelTitle.Displayed);
        }

        public InvoicePage GoInvoicePage()
        {

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            return new InvoicePage(driver);
        }
    }
}
