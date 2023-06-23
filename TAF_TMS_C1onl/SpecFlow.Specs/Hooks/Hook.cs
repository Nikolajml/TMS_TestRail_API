using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly ScenarioContext scenarioContext;
        private Browser browser;

        public Hook(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario("GUI")]
        public void BeforeScenario()
        {
            browser = new Browser();
            scenarioContext.Add("Driver", browser.Driver);

            Console.Out.WriteLine("GUI");
        }              

        [AfterScenario("GUI")]
        public void AfterScenario()
        {
            browser.Driver.Quit();
        }
    }
}
