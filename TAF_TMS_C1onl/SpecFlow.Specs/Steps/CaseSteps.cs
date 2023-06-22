using AngleSharp.Css;
using Newtonsoft.Json.Linq;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SpecFlow.Internal.Json;
using SpecFlow.Specs.Steps;
using System;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs
{
    [Binding]
    public class CaseSteps : BaseApiSteps
    {
        private Case expectedCase;
        private Case actualCase;
        private Case receivedCase;
        private Case updatedCase;
        private Case actualUpdateCase;
        private Case deletedCase;

        [Given(@"API client is initialized")]
        public void GivenAPIClientIsInitialized()
        {
            
        }

        [When(@"added new case: sectionId ""(.*)"" title ""(.*)"" typeId ""(.*)"" priorityId ""(.*)""")]
        [Given(@"new case is added: sectionId ""(.*)"" title ""(.*)"" typeId ""(.*)"" priorityId ""(.*)""")]
        public void AddCaseTest(int sectionId, string title, int typeId, int priorityId)
        {
            Case newCase = new Case();
            newCase.SectionID = sectionId;
            newCase.Title = title;
            newCase.TypeId = typeId;
            newCase.PriorityId = priorityId;
                  
            actualCase = caseService.AddCaseBDD(newCase, newCase.SectionID);

            expectedCase = newCase;            
        }

        [Then("added case should match the expected case")]
        public void CpmpareActualAndAddedCase()
        {                        
            Assert.AreEqual(actualCase.Title, expectedCase.Title);
            Assert.AreEqual(actualCase.SectionID, expectedCase.SectionID);
            Assert.AreEqual(actualCase.TypeId, expectedCase.TypeId);
            Assert.AreEqual(actualCase.PriorityId, expectedCase.PriorityId);
        }

        [When("received an existing case")]
        public void GetCaseTest()
        {                                   
            receivedCase = caseService.GetCaseBDD(actualCase.Id);
        }

        [Then("actual case should match the received case")]
        public void CpmpareActualAndReceivedCase()
        {
            Assert.AreEqual(actualCase.Title, receivedCase.Title);
            Assert.AreEqual(actualCase.SectionID, receivedCase.SectionID);
            Assert.AreEqual(actualCase.TypeId, receivedCase.TypeId);
            Assert.AreEqual(actualCase.PriorityId, receivedCase.PriorityId);
        }

        [When(@"details of added case was update: sectionId ""(.*)"" title ""(.*)""")]
        public void UpdateCaseTest(int sectionId, string title)
        {
            Case newCase = new Case();
            newCase.SectionID = sectionId;
            newCase.Title = title;

            Console.WriteLine($"Update Case Id: {actualCase.Id}");
            updatedCase = caseService.UpdateCaseBDD(newCase, actualCase.Id);

            actualUpdateCase = newCase;
        }

        [Then("the updated case should match the expected information")]
        public void CheckUpdatedDetails()
        {            
            Assert.AreEqual(actualCase.Title, updatedCase.Title);
            Assert.AreEqual(actualCase.SectionID, updatedCase.SectionID);            
        }

        [When("added case is deleted")]
        public void DeleteCaseTest()
        {
            deletedCase = caseService.DeleteCaseBDD(actualCase.Id);
        }

        [Then("the added case must be deleted")]
        public void CheckThatCaseDeleted()
        {            
            Assert.IsNull(deletedCase);
        }        
    }
}
