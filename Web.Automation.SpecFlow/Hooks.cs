﻿using BLL.Browser;
using BLL.Utilities;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class Hooks
    {
        protected static string browserName = ConfigurationManager.AppSettings["browser"];

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            VideoRecorder.StartRecordingVideo(ScenarioContext.Current.ScenarioInfo.Title);
            Driver.OpenBrowser(browserName);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
                ScreenShot.TakeScreenShot();
            VideoRecorder.EndRecording();
            Driver.CloseBrowser();
        }
    }
}
