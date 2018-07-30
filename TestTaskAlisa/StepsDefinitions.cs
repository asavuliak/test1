using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestTaskAlisa.PageObject;
using OpenQA.Selenium.Support.UI;


namespace TestTaskAlisa
{
    [Binding]
    public class StepsDefinitions
    {
        private IWebDriver driver;

        [Before]
        public void before()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        #region Given

        [Given(@"end user navigates to '(.*)' website")]
        public void GivenEndUserNavigatesToWebsite(string website)
        {
           MainPage main = new MainPage(driver);
           main.goToPage(website);
        }

        #endregion Given

        #region When
        [When(@"end user enters credentials for login")]
        public void WhenEndUserEntersCredentialsForLogin(Table table)
        {
            var login = table.Rows[0]["login"];
            var password = table.Rows[0]["password"];

            MainPage main = new MainPage(driver);
            main.GoLoginPage();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.GoToAccountPage(login, password);
        }

        [When(@"end user complete review form for hotel '(.*)'")]
        public void WhenEndUserCompleteReviewForm(string hotelName, Table table)
        {
            var clean = table.Rows[0]["clean"];
            var staff = table.Rows[0]["staff"];
            var reviews = table.Rows[0]["reviews"];

            AccountPage accountPage = new AccountPage(driver);

            accountPage.WriteReviewPopUp();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            Thread.Sleep(5000);

            accountPage.SelectCleanOption(hotelName, clean).Click();
            accountPage.SelectStaffOption(hotelName, staff).Click();
            accountPage.TextArea(hotelName).SendKeys(reviews);

            Thread.Sleep(5000);

            accountPage.SubmitButton(hotelName).Click();
            Thread.Sleep(5000);

        }

        [When(@"end user navigates to invoice page for hotel '(.*)'")]
        public void WhenEndUserNavigatesToInvoicePage(string hotelName)
        {
            AccountPage accountPage = new AccountPage(driver);
            accountPage.InvoiceButton(hotelName).Click();
            accountPage.GoInvoicePage();
            
        }


        #endregion

        #region Then
        [Then(@"hotel is displayed")]
        public void ThenHotelIsDisplayed()
        {
            AccountPage accountPage = new AccountPage(driver);

            Thread.Sleep(3500);

            accountPage.scrollToelement();
            accountPage.elementIsDisplayed();
        }

        [Then(@"invoice page with correct data is displayed")]
        public void ThenInvoicePageWithCorrectDataIsDisplayed(Table table)
        {
            InvoicePage invoicePage = new InvoicePage(driver);

            var depositNow = table.Rows[0]["DepositNow"];
            var taxAndVat = table.Rows[0]["Tax&VAT"];
            var TotalAmount = table.Rows[0]["TotalAmount"];
            var depositActual = invoicePage.InvoiceData("Deposit Now", depositNow).Text;
            var taxAndVatActual = invoicePage.InvoiceData("Tax & VAT", taxAndVat).Text;
            var TotalAmountActual = invoicePage.InvoiceData("Total Amount", TotalAmount).Text;

           Assert.IsTrue(depositActual.Contains(depositNow), "Incorrect value is displayed. It should be {0} instead of {1}", depositNow, depositActual);
           Assert.IsTrue(taxAndVatActual.Contains(taxAndVat), "Incorrect value is displayed. It should be {0} instead of {1}", taxAndVat, taxAndVatActual);
           Assert.IsTrue(TotalAmountActual.Contains(TotalAmount), "Incorrect value is displayed. It should be {0} instead of {1}", TotalAmount, TotalAmountActual);
        }


        #endregion

        [After]
        public void after()
        {
            driver.Quit();
        }
    }
}
