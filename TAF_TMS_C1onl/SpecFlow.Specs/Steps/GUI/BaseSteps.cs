using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps.GUI
{
    public class BaseSteps
    {
        protected IWebDriver Driver;
        protected NavigationSteps navigationSteps;
        protected ProjectSteps projectSteps;
        protected DashboardPage dashboardPage;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            Driver = scenarioContext.Get<IWebDriver>("Driver");
            navigationSteps = new NavigationSteps(Driver);
            projectSteps = new ProjectSteps(Driver);
            dashboardPage = new DashboardPage(Driver);
        }
    }
}
