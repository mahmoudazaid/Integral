using AutomationFramework.WebElementParser;
using BLL.Browser;
using BLL.Extensions;
using FluentAssertions;
using Gherkin.Ast;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class SampleTestingStepDefs:Steps
    {
        private readonly ParsersManager _parser = new ParsersManager("SampleTestingPageObject.json");
        public static string[] tag = FeatureContext.Current.FeatureInfo.Tags;        

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SampleTestingStepDefs(ScenarioContext injectedContext)
        {
            context = injectedContext;            

        }

        [Given(@"Jawwytv site opens successfully")]
        public void GivenJawwytvSiteOpensSuccessfully()
        {                       
            //read the element locator
            var _element = _parser.GetElementByName("SectionTitle");
            //Sccroll to the element
            Driver.WebDriver.ScrollToElement(_element, 10);
            //Inspect the element
            IList<IWebElement> sections = Driver.WebDriver.FindElements(_element);
            // Difin an Array to carr all section tiltes in the paage
            String[] sectionTitles = new String[sections.Count];

            var changeLanguage = _parser.GetElementByName("ChangeLanguage");
            //Scroll to Element
            Driver.WebDriver.ScrollToElement(changeLanguage, 10);
            //Inspec the element
            IWebElement button = Driver.WebDriver.InspectElement(changeLanguage);
            //Read the element text
            string btn = button.Text;            

                var i = 0;
            //read the titles and put innto the array
            foreach (var title in sections)
                sectionTitles[i++] = title.Text;

            if (btn == "العربية")
            {
                //difne an array that contains all sections in the page
                string[] EnTitles = { "Movies and TV Shows", "Live TV", "Features", "FREQUENTLY ASKED QUESTIONS" };
                sectionTitles.Should().BeEquivalentTo(EnTitles);
            }
            else if (btn == "ENGLISH")
            {
                //difne an array that contains all sections in the page
                string[] ArTitles = { "أفلام ومسلسلات", "البث المباشر", "الميزات", "الأسئلة المتكررة" };
                sectionTitles.Should().BeEquivalentTo(ArTitles);
            }



        }

        [When(@"User changes language in welcome screen")]
        [Scope(Tag = "EN")]
        public void WhenUserChangesLanguageInWelcomeScreen()
        {
            //Read the elemnet locator from JSON File
            var changeLanguage = _parser.GetElementByName("ChangeLanguage");
            //Scroll to Element
            Driver.WebDriver.ScrollToElement(changeLanguage, 10);
            //Inspec the element
            IWebElement button = Driver.WebDriver.InspectElement(changeLanguage);
            //Read the element text
            string btn = button.Text;

            if (btn == "ENGLISH")
                SEActions.ClickButton(changeLanguage);
        }
      

        [When(@"User clicks on seven days free subscribe now button")]
        public void WhenUserClicksOnSevenDaysFreeSubscribeNowButton()
        {
            //Read the elemnet locator from JSON File
            var Trial = _parser.GetElementByName("Trial");            
            SEActions.ClickLink(Trial);
        }

        [Then(@"User enters username as ""(.*)""")]
        public void ThenUserEntersUsernameAs(string name)
        {
            //Read the elemnet locator from JSON File
            var txtbox = _parser.GetElementByName("EmailTextbox");
            SEActions.TypeText(txtbox, name);
        }

        [Then(@"User enters password as ""(.*)""")]
        public void ThenUserEntersPasswordAs(string password)
        {
            //read the elemnt locatores from JSOn file
            var txtbox = _parser.GetElementByName("PasswordTextbox");
            SEActions.TypeText(txtbox, password);
        }

        [Then(@"User clicks on continue button")]
        public void ThenUserClicksOnContinueButton()
        {
            //Read the elemnet locator from JSON File
            var btn = _parser.GetElementByName("ContinueButton");
            SEActions.ClickButton(btn);
        }

        [Then(@"User should see back button displayed on payment screen")]
        [Scope(Tag = "EN")]
        public void ThenUserShouldSeeBackButtonDisplayedOnPaymentScreen()
        {
            //Calling nested step defintion
            Then(@"I should see ""Set up your payment method"" on ""StepName""");
            Then(@"I should see ""BACK"" on ""BackButton""");
        }

        [Then(@"User should selects ""(.*)"" from country dropdown menu")]
        [Scope(Tag = "EN")]
        public void ThenUserShouldSelectsLebanonFromCountryDropdownMenu(string selection)
        {
            //Get the element locator
            var dropwdown = _parser.GetElementByName("Countries");
            SEActions.SelectFromDropDown(dropwdown, selection);            
        }

        [Then(@"User should see that only ""(.*)"" payment method is displayed")]
        [Scope(Tag = "EN")]
        public void ThenUserShouldSeeThatOnlyCreditCardPaymentMethodIsDisplayed(string provider)
        {
            Thread.Sleep(3000);
            //Read the elemnet locator from JSON File
            var _element = _parser.GetElementByName("Providers");
            //Sccroll to the element
            Driver.WebDriver.ScrollToElement(_element, 10);
            //Inspect the element
            IList<IWebElement> providersName = Driver.WebDriver.FindElements(_element);
            // Difin an Array to carr all section tiltes in the paage
            String[] providers = new String[providersName.Count];

            var i = 0;
            //read the titles and put innto the array
            foreach (var title in providersName)
                providers[i++] = title.Text;
         //Comparing 2 arrays
         providers.Should().BeEquivalentTo(new[] { provider });         
        }
      
        [Then(@"User should see that (.*) payment methods are displayed")]
        public void ThenUserShouldSeeThatTwoPaymentMethodsAreDisplayed(int PymentsNumber)
        {
            Thread.Sleep(3000);
            //Read the elemnet locator from JSON File
            var _element = _parser.GetElementByName("Providers");
            //Sccroll to the element
            Driver.WebDriver.ScrollToElement(_element, 10);
            //Inspect the element
            IList<IWebElement> providersName = Driver.WebDriver.FindElements(_element);
            // Check Number of payments
            providersName.Count.Should().Be(PymentsNumber);           
        }

        [Then(@"User clicks on Click here link in create your account section")]
        public void ThenUserClicksOnClickHereLinkInCreateYourAccountSection()
        {
            //Read the elemnet locator from JSON File
            var link = _parser.GetElementByName("ClickHere");
            SEActions.ClickLink(link);
        }

        [Then(@"User clicks on Subscribe link in Existing User section")]
        public void ThenUserClicksOnSubscribeLinkInExistingUserSection()
        {
            //Read the elemnet locator from JSON File
            var link = _parser.GetElementByName("Subscribe");
            SEActions.ClickLink(link);
        }

        [Then(@"User should navigate to Create your account section")]
        [Scope(Tag="EN")]
        public void ThenUserShouldNavigateToCreateYourAccountSection()
        {
          //Calling nested step defention            
          Then(@"I should see ""Create your account"" on ""StepName""");
        }

        [Then(@"User clicks on Terms and Conditions link in create your account section")]
        public void ThenUserClicksOnTermsAndConditionsLinkInCreateYourAccountSection()
        {
            //read the elemnt locatores from JSOn file
            var link = _parser.GetElementByName("TermsConditions");
            SEActions.ClickLink(link);
        }

        [Then(@"[Uu]ser should see that Terms & Conditions section is displayed")]
        [Scope(Tag="EN")]
        public void ThenUserShouldSeeThatTermsConditionsSectionIsDisplayed()
        {
            //Calling nested step defention 
            Then(@"I should see ""TERMS & CONDITIONS"" on ""FormName""");            
        }
    }
}
