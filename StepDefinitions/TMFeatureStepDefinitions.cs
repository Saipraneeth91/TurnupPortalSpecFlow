using TurnupPortal_SpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using TurnupPortalSpecFlow.Utilities;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace TurnupPortal_SpecFlow.StepDefinitions 
{
    [Binding]
    public class TMFeatureStepDefinitions { 
        private IWebDriver driver;
        public TMFeatureStepDefinitions(IWebDriver driver)
    {
        this.driver=driver;
    }
        [Given(@"I login into Turnup portal succesfully")]
        public void GivenILoginIntoTurnupPortalSuccesfully()
        {

            //LoginPageobject Initialization and Definition
            LoginPage loginpageobj = new LoginPage(driver);
            loginpageobj.LoginActions();
        }

        [When(@"I Navigate to Time and Material Page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
 
            //HomePageobject Initialization and Definition
            HomePage homepageobj = new HomePage(driver);
             homepageobj.NavigateToTMPage();
           
           
        }

        [When(@"I Create a Record")]
        public void WhenICreateARecord()
        {
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.CreateTMRecord();
        }

        [Then(@"record should be created succesfully")]
        public void ThenRecordShouldBeCreatedSuccesfully()
        {
            TMPage tmpageobj = new TMPage(driver);
            string ActualCode = tmpageobj.Getlastrowcode();
            string Actualtypecode=tmpageobj.GetlastrowTypecode();
            string ActualDescription = tmpageobj.GetlastrowDescription();
            string ActualPrice = tmpageobj.GettablelastrowPrice();

            Assert.That(ActualCode == "TA Prog sai", "Actual Code and expected Code do not match.");
            Assert.That(Actualtypecode == "T", "Actual Description and expected Description do not match.");
            Assert.That(ActualPrice == "$22.00", "Actual Price and expected Price do not match.");
        }

        [When(@"I Login and Navigate to Edit Time record page")]
        public void WhenILoginAndNavigateToEditTimeRecordPage()
        {
            //LoginPageobject Initialization and Definition
            LoginPage loginpageobj = new LoginPage(driver);
            loginpageobj.LoginActions();

        }
        [When(@"I update the '([^']*)' and '([^']*)'  on  existing Time record")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecord(string code, string description)
        {
            HomePage homepageobj = new HomePage(driver);
            homepageobj.NavigateToEditOrDeleteTMPage();
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.EditTMRecord(code,description);   

        }

        [Then(@"the record should have the updated '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedvalues(string code, string description)
        {
            TMPage tmpageobj = new TMPage(driver);
            string ActualCode = tmpageobj.Getlastrowcode();
            string Actualtypecode = tmpageobj.GetlastrowTypecode();
            string ActualDescription = tmpageobj.GetlastrowDescription();
            string ActualPrice = tmpageobj.GettablelastrowPrice();

            Assert.That(ActualCode == code, "Actual Code and expected Code do not match.");
            Assert.That(ActualDescription == description, "Actual Description and expected Description do not match.");
            
        }


        [When(@"I Login and Navigate to Delete Time record Page")]
        public void WhenILoginAndNavigateToDeleteTimeRecordPage()
        {
            LoginPage loginpageobj = new LoginPage(driver);
            loginpageobj.LoginActions();
            HomePage homepageobj = new HomePage(driver);
            homepageobj.NavigateToEditOrDeleteTMPage();

        }

        [When(@"I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            
            TMPage tmpageobj = new TMPage(driver);
            tmpageobj.DeleteTMRecord();
        }

        [Then(@"the record should not be present on the table")]
        public void ThenTheRecordShouldNotBePresentOnTheTable()
        {
            Console.WriteLine("Record is Deleted");
        }

    }
}
