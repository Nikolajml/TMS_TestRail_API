using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Steps;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps.GUI
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        public LoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        [Given(@"the browser is opened")]
        public void BrowserIsOpened()
        {

        }

        [Given(@"the login page is opened")]
        public void LoginPageIsOpened()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }

        [When(@"the user is logged in: user ""(.*)"" password ""(.*)""")]
        public void SuccessfulLogin_WithUserNameAndPsword(string userName, string password)
        {
            navigationSteps.SuccessfulLogin(userName, password);
        }

        [Then(@"the dashboard page is opened")]
        [When(@"the dashboard page is opened")]
        public void IsDashbordPageIs()
        {
            Assert.AreEqual("All Projects - TestRail", Driver.Title);
        }
    }
}
