using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
    public class BrowserHook
    {
        private readonly Browser browser;

        public BrowserHook(Browser browser)
        {
            this.browser = browser;
        }

        [BeforeScenario("GUI")]
        public void BeforeScenario()
        {
            Console.Out.WriteLine("GUI");
        }                

        [AfterScenario("GUI")]
        public void AfterScenario()
        {
            browser.Driver.Quit();
        }
    }
}
