using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Steps;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps.GUI
{
    [Binding]
    public class CreateProjectSteps : BaseSteps
    {
        public CreateProjectSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }  

        [When(@"the user went to project page")]
        public void GoToAddProjectPage()
        {
            projectSteps.NavigateToAddProjectPage();
        }

        [When(@"entered the project name ""(.*)""")]
        public void EnteredInTheNameField(string projectName)
        {
            projectSteps.EnterProjectName(projectName);
        }

        [When(@"added new project")]
        public void WhenClickedTheAddProjectButton()
        {
            projectSteps.ClickAddNewProjectButton();
        }

        [Then(@"check that project was added")]
        public void CheckAddedProject()
        {
            Driver.Navigate().GoToUrl("https://aqac02onl.testrail.io/index.php?/admin/projects/overview");

            Assert.True(Driver.FindElement(By.XPath("//a[text()='The project created like GUI BDD test']")).Displayed);
        }
    }
}
