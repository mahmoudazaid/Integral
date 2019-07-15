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
            //difne an array that contains all sections in the page
            string [] ArTitles = { "أفلام ومسلسلات", "البث المباشر", "الميزات", "الأسئلة المتكررة" };
            string [] EnTitles = { "Movies and TV Shows", "Live TV", "Features", "FREQUENTLY ASKED QUESTIONS" };
            //read the element locator
            var _element = _parser.GetElementByName("SectionTitle");
            //Sccroll to the element
            Driver.WebDriver.ScrollToElement(_element, 10);
            //Inspect the element
            IList<IWebElement> sections = Driver.WebDriver.FindElements(_element);
            // Difin an Array to carr all section tiltes in the paage
            String[] sectionTitles = new String[sections.Count];

            var i = 0;
            //read the titles and put innto the array
            foreach (var title in sections)
                sectionTitles[i++] = title.Text;

            //read the current URL
            var CurrentUrl = Driver.WebDriver.Url;
            
            //check if the page opened in English or Arabic
            if (CurrentUrl.Substring("http://www.jawwy.tv".Length) == "en/home")
            {
                sectionTitles.Should().BeEquivalentTo(EnTitles);
            }
            else
            {
                sectionTitles.Should().BeEquivalentTo(ArTitles);
            }            
        }

        [When(@"User changes language in welcome screen")]
        public void WhenUserChangesLanguageInWelcomeScreen()
        {
            //Read the elemnet locator from JSON File
            var changeLanguage = _parser.GetElementByName("ChangeLanguage");
            // Reaad Scienario Tag           
            var CurrentUrl = Driver.WebDriver.Url;

            if (tag.Where(x => x == "EN").ToString() == "EN" & CurrentUrl.Substring("http://www.jawwy.tv".Length) != "en/home")
            {
                
                SEActions.ClickButton(changeLanguage);
            }
            else if(tag.Where(x => x == "AR").ToString() == "AR" & CurrentUrl.Substring("http://www.jawwy.tv".Length) == "en/home")
            {
                SEActions.ClickButton(changeLanguage);
            }

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
        public void ThenUserShouldSeeBackButtonDisplayedOnPaymentScreen()
        {
            //Calling nested step defention 
            if(tag.Where(x => x == "EN").ToString() == "EN")
            {
                Then(@"I should see ""Set up your payment method"" on ""StepName""");
                Then(@"I should see ""BACK"" on ""BackButton""");
            }            
            else if(tag.Where(x => x == "AR").ToString() == "AR" )
            {
                Then(@"I should see ""قم بإعداد طريقة الدفع الخاصة بك"" on ""StepName""");
                Then(@"I should see ""رجوع"" on ""BackButton""");
            }
        }

        [Then(@"User should selects ""(.*)"" from country dropdown menu")]
        public void ThenUserShouldSelectsLebanonFromCountryDropdownMenu(string selection)
        {
            //Get the element locator
            var dropwdown = _parser.GetElementByName("Countries");

            //Put the countries in Dictionary
            Dictionary<string, string> countries = new Dictionary<string, string>()
            {

            { "Lebanon", "لبنان"},
            { "Bahrain", "البحرين"}
            };

            if (tag.Where(x => x == "EN").ToString() == "EN" )
            {
                SEActions.SelectFromDropDown(dropwdown, selection);
            }
            else if (tag.Where(x => x == "AR").ToString() == "AR" )
            {
                SEActions.SelectFromDropDown(dropwdown, countries[selection]);


            }
        }

        [Then(@"User should see that only ""(.*)"" payment method is displayed")]
        public void ThenUserShouldSeeThatOnlyCreditCardPaymentMethodIsDisplayed(string provider)
        {
            Dictionary<string, string> pay = new Dictionary<string, string>()
            {

            { "Credit Card", "بطاقة الائتمان"}
            };

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
            if(tag.Where(x => x == "EN").ToString() == "EN" )
            {
                //Comparing 2 arrays
                providers.Should().BeEquivalentTo(new[] { provider });
            }            
            else if(tag.Where(x => x == "AR").ToString() == "AR" )
            {
                //Comparing 2 arrays after read the valye from the dectionary
                providers.Should().BeEquivalentTo(new[] { pay[provider] });

            }
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
        public void ThenUserShouldNavigateToCreateYourAccountSection()
        {
            if (tag.Where(x => x == "EN").ToString() == "EN" )
            {
                //Calling nested step defention            
                Then(@"I should see ""Create your account"" on ""StepName""");
            }
            else if (tag.Where(x => x == "AR").ToString() == "AR" )
            {
                Then(@"I should see ""أنشئ حسابك"" on ""StepName""");
            }
        }

        [Then(@"User clicks on Terms and Conditions link in create your account section")]
        public void ThenUserClicksOnTermsAndConditionsLinkInCreateYourAccountSection()
        {
            var link = _parser.GetElementByName("TermsConditions");
            SEActions.ClickLink(link);
        }

        [Then(@"User should see that Terms & Conditions section is displayed")]
        public void ThenUserShouldSeeThatTermsConditionsSectionIsDisplayed()
        {
            if(tag.Where(x => x == "EN").ToString() == "EN" )
            {
                //Calling nested step defention 
                Then(@"I should see ""TERMS & CONDITIONS"" on ""FormName""");
            }
            else if(tag.Where(x => x == "AR").ToString() == "AR" )
            {
                //Calling nested step defention 
                Then(@"I should see ""الشروط والأحكام"" on ""FormName""");
            }
        }



    }
}
