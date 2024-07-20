using TurnupPortalSpecFlow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurnupPortal_SpecFlow.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //By Locators
        IWebElement AdminButton => driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
        IWebElement TimeandMat => driver.FindElement(By.XPath("/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a"));
        IWebElement Emp => driver.FindElement(By.XPath("//a[text()='Employees']"));
        IWebElement Lastbtn => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        //Function that allow users to Navigate to TM/EMP Page
        public void NavigateToTMPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            AdminButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a", 10);
            TimeandMat.Click();

        }
        public void NavigateToEmpPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AdminButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Employees']", 10);
            Emp.Click();
        }
        public void NavigateToEditOrDeleteTMPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            AdminButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a", 10);
            TimeandMat.Click();
            Thread.Sleep(2000);
            Lastbtn.Click();

            
        }

    }
}
