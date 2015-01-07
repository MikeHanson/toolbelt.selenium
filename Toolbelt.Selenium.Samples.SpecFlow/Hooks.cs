using System;
using TechTalk.SpecFlow;
using Toolbelt.Selenium.Samples.PageModel;

namespace Toolbelt.Selenium.Samples.SpecFlow
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Sut.Current.Connect();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Sut.Current.Disconnect();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Sut.Current.Start();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Sut.Current.Stop();
        }
    }
}