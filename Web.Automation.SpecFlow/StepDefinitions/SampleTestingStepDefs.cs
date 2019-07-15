using AutomationFramework.WebElementParser;
using BLL.Browser;
using BLL.Extensions;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow.StepDefinitions
{
    [Binding]
    public sealed class SampleTestingStepDefs
    {
        private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private readonly ParsersManager _parser = new ParsersManager("SampleTestingPageObject.json");

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public SampleTestingStepDefs(ScenarioContext injectedContext)
        {
            Driver.Visit(baseURL);
        }

        [Given(@"Jawwytv site opens successfully")]
        public void GivenJawwytvSiteOpensSuccessfully()
        {
            var _element = _parser.GetElementByName("SectionTitle");
            Driver.WebDriver.ScrollToElement(_element, 10);
            IWebElement element = Driver.WebDriver.InspectElement(_element);
            string elementText = element.Text;

            var CurrentUrl = Driver.WebDriver.Url;
            if(CurrentUrl.Substring("http://www.jawwy.tv".Length) == "en/home")
            {

            }
            

        }

        [When(@"User changes language in welcome screen")]
        public void WhenUserChangesLanguageInWelcomeScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User clicks on seven days free subscribe now button")]
        public void WhenUserClicksOnSevenDaysFreeSubscribeNowButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User enters username as ""(.*)""")]
        public void ThenUserEntersUsernameAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User enters password as ""(.*)""")]
        public void ThenUserEntersPasswordAs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User clicks on continue button")]
        public void ThenUserClicksOnContinueButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see back button displayed on payment screen")]
        public void ThenUserShouldSeeBackButtonDisplayedOnPaymentScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should selects Lebanon from country dropdown menu")]
        public void ThenUserShouldSelectsLebanonFromCountryDropdownMenu()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see that only credit card payment method is displayed")]
        public void ThenUserShouldSeeThatOnlyCreditCardPaymentMethodIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should selects Bahrain from country dropdown menu")]
        public void ThenUserShouldSelectsBahrainFromCountryDropdownMenu()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see that two payment methods are displayed")]
        public void ThenUserShouldSeeThatTwoPaymentMethodsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User clicks on Click here link in create your account section")]
        public void ThenUserClicksOnClickHereLinkInCreateYourAccountSection()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User clicks on Subscribe link in Existing User section")]
        public void ThenUserClicksOnSubscribeLinkInExistingUserSection()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should navigate to Create your account section")]
        public void ThenUserShouldNavigateToCreateYourAccountSection()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User clicks on Terms and Conditions link in create your account section")]
        public void ThenUserClicksOnTermsAndConditionsLinkInCreateYourAccountSection()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see that Terms & Conditions section is displayed")]
        public void ThenUserShouldSeeThatTermsConditionsSectionIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
