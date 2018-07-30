using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestTaskAlisa.PageObject
{
    class InvoicePage
    {
        private IWebDriver driver;

        public InvoicePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered']//strong[contains(text(), 'Deposit Now')]//..//..//..//../tbody//td[contains(text(), '30.80')]")]
        //private IWebElement DepositNow;

        //[FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered']//strong[contains(text(), 'Tax & VAT')]//..//..//..//../tbody//td[contains(text(), '28')]")]
        //private IWebElement TaxVat ;

        //[FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered']//strong[contains(text(), 'Total Amount')]//..//..//..//../tbody//td[contains(text(), '308')]")]
        //private IWebElement TotalAmount;

        public IWebElement InvoiceData(string name, string amount)
        {
            return driver.FindElement(By.XPath("//table[@class='table table-bordered']//strong[contains(text(), '"+name+"')]//..//..//..//../tbody//td[contains(text(), '"+amount+"')]"));
        }

    }
}
