using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{    
    [Binding]
    public class MilestoneSteps : BaseApiSteps
    {
        private Project actualProject;
        private Project expectedProject;
        private Milestone actualMilestone;
        private Milestone expectedMilestone;
        private Milestone receivedMilestone;
        private Milestone updatedMilestone;
        private Milestone deletedMilestone;

        [Given(@"API client for milestone is initialized")]
        public void GivenAPIClientIsInitialized()
        {

        }

        [When(@"added new project: name ""(.*)"" announcement ""(.*)"" suite mode ""(.*)""")]
        [Given(@"added new project: name ""(.*)"" announcement ""(.*)"" suite mode ""(.*)""")]
        public void AddProgectTest(string name, string description, int suitemode)
        {
            Project newProject = new Project();
            newProject.Name = name;
            newProject.Announcement = description;
            newProject.SuiteMode = suitemode;

            actualProject = projectService.AddProjectBDD(newProject);

            expectedProject = newProject;            
        }

        [Then("added project should match the expected project")]
        public void CpmpareActualAndExpectedProject()
        {
            Assert.AreEqual(actualProject.Name, expectedProject.Name);
            Assert.AreEqual(actualProject.Announcement, expectedProject.Announcement);
            Assert.AreEqual(actualProject.SuiteMode, expectedProject.SuiteMode);
        }

        [When(@"added new milestone: name ""(.*)"" description ""(.*)""")]
        [Given(@"added new milestone: name ""(.*)"" description ""(.*)""")]
        public void AddMilestoneTest(string name, string description)
        {
            Milestone newMilestone = new Milestone();
            newMilestone.Name = name;
            newMilestone.Description = description;

            actualMilestone = milestoneService.AddMilestoneBDD(newMilestone, actualProject.Id);

            expectedMilestone = newMilestone;
        }

        [Then("added milestone should match the expected milestone")]
        public void CpmpareActualAndExpectedMilestone()
        {
            Assert.AreEqual(actualMilestone.Name, expectedMilestone.Name);
            Assert.AreEqual(actualMilestone.Description, actualMilestone.Description);
        }

        [When("received an existing milestone")]
        public void GetMilestoneTest()
        {
            receivedMilestone = milestoneService.GetMilestoneBDD(actualMilestone.Id);
        }

        [Then("actual milestone should match the received milestone")]
        public void CpmpareActualAndReceivedCase()
        {
            Assert.AreEqual(actualMilestone.Id, receivedMilestone.Id);
            Assert.AreEqual(actualMilestone.Name, receivedMilestone.Name);
            Assert.AreEqual(actualMilestone.Description, receivedMilestone.Description);
        }

        [When(@"details of added case was update: name ""(.*)"" description ""(.*)""")]
        [When(@"details of added milestone was update: name ""(.*)"" description ""(.*)""")]
        public void UpdateMilestoneTest(string name, string description)
        {
            Milestone newMilestone = new Milestone();
            newMilestone.Name = name;
            newMilestone.Description = description;

            //Console.WriteLine($"Update Case Id: {actualCase.Id}");
            updatedMilestone = milestoneService.UpdateMilestoneeBDD(newMilestone, actualMilestone.Id);

            actualMilestone = newMilestone;
        }

        [Then("the updated milestone should match the expected information")]
        public void CheckUpdatedMilestoneDetails()
        {
            Assert.AreEqual(actualMilestone.Name, updatedMilestone.Name);
            Assert.AreEqual(actualMilestone.Description, updatedMilestone.Description);
        }

        [When("added milestone is deleted")]
        public void DeleteMilestoneTest()
        {
            deletedMilestone = milestoneService.DeleteMilestoneBDD(actualMilestone.Id);
        }

        [Then("the added milestone must be deleted")]
        public void CheckThatMilestoneDeleted()
        {
            Assert.IsNull(deletedMilestone);
        }
    }
}

	