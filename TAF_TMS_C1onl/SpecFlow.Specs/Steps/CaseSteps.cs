using Newtonsoft.Json.Linq;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
        private Case addedCase;
        //private Case actualCase;



        [Given(@"API client is initialized")]
        public void GivenAPIClientIsInitialized()
        {
            
        }

        [When(@"added new case: sectionId ""(.*)"" title ""(.*)"" typeId ""(.*)"" priorityId ""(.*)""")]
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
        public void CpmpareActualAndExpectedResults()
        {                        
            Assert.AreEqual(actualCase.Title, expectedCase.Title);
            Assert.AreEqual(actualCase.SectionID, expectedCase.SectionID);
            Assert.AreEqual(actualCase.TypeId, expectedCase.TypeId);
            Assert.AreEqual(actualCase.PriorityId, expectedCase.PriorityId);
        }
    }
}
