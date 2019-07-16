using AutomationFramework.WebElementParser;
using BLL.Browser;
using BLL.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class SampleTestingStepDefsAR : Steps
    {
        private readonly ParsersManager _parser = new ParsersManager("SampleTestingPageObject.json");
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SampleTestingStepDefsAR(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"Jawwytv site opens successfully")]
        [Scope(Tag = "AR")]
        public void GivenJawwytvSiteOpensSuccessfully()
        {
            //difne an array that contains all sections in the page
            string[] ArTitles = { "أفلام ومسلسلات", "البث المباشر", "الميزات", "الأسئلة المتكررة" };

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

            sectionTitles.Should().BeEquivalentTo(ArTitles);
        }

        [When(@"User changes language in welcome screen")]
        [Scope(Tag = "AR")]
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

        [Then(@"User should see back button displayed on payment screen")]
        [Scope(Tag = "AR")]
        public void ThenUserShouldSeeBackButtonDisplayedOnPaymentScreen()
        {

            Then(@"I should see ""قم بإعداد طريقة الدفع الخاصة بك"" on ""StepName""");
            Then(@"I should see ""رجوع"" on ""BackButton""");
        }

        [Then(@"User should selects ""(.*)"" from country dropdown menu")]
        [Scope(Tag = "AR")]
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
            SEActions.SelectFromDropDown(dropwdown, countries[selection]);

        }

        [Then(@"User should see that only ""(.*)"" payment method is displayed")]
        [Scope(Tag = "AR")]
        public void ThenUserShouldSeeThatOnlyCreditCardPaymentMethodIsDisplayed(string provider)
        {
            //put the providers in dectionary to carry the name of them in English and Arabic
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

            //Comparing 2 arrays after read the valye from the dectionary
            providers.Should().BeEquivalentTo(new[] { pay[provider] });
        }

        [Then(@"User should navigate to Create your account section")]
        [Scope(Tag = "AR")]
        public void ThenUserShouldNavigateToCreateYourAccountSection()
        {
            //Calling nested step defention            
            Then(@"I should see ""أنشئ حسابك"" on ""StepName""");
        }


        [Then(@"User should see that Terms & Conditions section is displayed")]
        [Scope(Tag="AR")]
        public void ThenUserShouldSeeThatTermsConditionsSectionIsDisplayed()
        {
            //Calling nested step defention 
            Then(@"I should see ""الشروط والأحكام"" on ""FormName""");
            }
        }

    }
}
