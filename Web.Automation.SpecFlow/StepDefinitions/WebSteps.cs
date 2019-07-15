using AutomationFramework.WebElementParser;
using BLL.Browser;
using BLL.Extensions;
using BLL.Utilities;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class SharedSteps
    {
        private readonly ParsersManager _parser = new ParsersManager("SampleTestingPageObject.json");
                
        [Then(@"I should see ""(.*)"" on ""(.*)""")]
        public void ThenIShouldSee(string _text,string el)
        {
            //read the elemnt locatores from JSOn file
            var _element = _parser.GetElementByName(el);
            //Scroll to the element bu Java script
            Driver.WebDriver.ScrollToElement(_element, 10);
            //Inspec the element
            IWebElement element = Driver.WebDriver.InspectElement(_element);
            //read the element text
            string elementText = element.Text;
            //comparing rhe element
            elementText.Should().Be(_text);
        }             
    }
}
