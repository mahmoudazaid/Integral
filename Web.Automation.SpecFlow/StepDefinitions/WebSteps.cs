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
        private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private readonly ParsersManager _parser = new ParsersManager("SampleTestingPageObject.json");


        [When(@"[Cc]lick on ""(.*)"" Link")]
        public void WhenClickOnLink(string link)
        {
            try
            {
                var _link = _parser.GetElementByName(link);
                SEActions.ClickLink(_link);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        }

        [When(@"[Cc]hoose ""(.*)"" file to upload")]
        public void WhenChooseFileToUpload(string _file)
        {
            var _uploadButton = _parser.GetElementByName("Choose file");
            SEActions.UploadFile(_uploadButton, _file);
        }

        [When(@"[Cc]lick on ""(.*)"" button")]
        public void WhenClickOnButton(string _button)
        {
            var _uploadButton = _parser.GetElementByName(_button);
            SEActions.ClickButton(_uploadButton);
        }

        [Then(@"I should see ""(.*)"" on ""(.*)""")]
        public void ThenIShouldSee(string _text,string el)
        {
            var _element = _parser.GetElementByName(el);
            Driver.WebDriver.ScrollToElement(_element, 10);
            IWebElement element = Driver.WebDriver.InspectElement(_element);
            string elementText = element.Text;
            elementText.Should().Be(_text);
        }     

        [Then(@"[Dd]elete ""(.*)"" file")]
        public void ThenDeleteFile(string _filename)
        {
            FilesManager.DeleteFile(_filename);
        }
        [When(@"([Cc]heck|[Uu]n[Cc]heck) on ""(.*)"" checkbox")]
        public void WhenSelectCheckbox(string _checkbox)
        {
            var checkbox = _parser.GetElementByName(_checkbox);
            SEActions.SelectCheckBox(checkbox);
        }
    }
}
