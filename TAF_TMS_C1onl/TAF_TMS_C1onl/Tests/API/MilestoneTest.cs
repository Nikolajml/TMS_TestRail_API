using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class MilestoneTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public int projectId { get; set; }
        public int milestoneId { get; set; }

        [Test, Order(1)]
        public void AddProgertTest()
        {
            var expectedProject = new Project();
            expectedProject.Name = "Project test for Melistone test";
            expectedProject.Announcement = "Description for Melistone";
            expectedProject.SuiteMode = 2;

            var actualProject = _projectService.AddProjectForMileson(expectedProject);
            _logger.Info("Actual Project: " + actualProject.ToString());

            //Выполним десериализацию JSON - строки в объект JObject
            var jsonObject = JObject.Parse(actualProject.Content);

            //Использование JsonPath для извлечения занчения из объекта
            string actualName = jsonObject.SelectToken("$.name").Value<string>();

            //Получение Id для UpdateTestCase
            var jsonObjectId = JObject.Parse(actualProject.Content);
            projectId = jsonObjectId.SelectToken("$.id").Value<int>();
            Console.WriteLine("Test: " + projectId);

            Assert.AreEqual(expectedProject.Name, actualName);
        }

        [Test, Order(2)]
        public void AddMilesoneTest()
        {
            var expectedMilestone = new Milestone();
            expectedMilestone.Name = "Project test for Melistone test";
            expectedMilestone.Description = "Description for Melistone";

            Console.WriteLine("Test: " + projectId);
            var actualMilestone = _milestoneService.AddMilestone(expectedMilestone, projectId);
            _logger.Info("Actual Project: " + actualMilestone.ToString());

            //Выполним десериализацию JSON - строки в объект JObject
            var jsonObject = JObject.Parse(actualMilestone.Content);

            //Использование JsonPath для извлечения занчения из объекта
            string actualMilestoneName = jsonObject.SelectToken("$.name").Value<string>();
            milestoneId = jsonObject.SelectToken("$.id").Value<int>();
            Console.WriteLine($"milestoneId: {milestoneId}");

            Assert.AreEqual(expectedMilestone.Name, actualMilestoneName);
        }

        [Test, Order(3)]
        public void GetMilesoneTest()
        {            
            var actualMilestone = _milestoneService.GetMilestone(milestoneId);
            _logger.Info(actualMilestone.Content);

            int actualMilestoneId = JObject.Parse(actualMilestone.Content).SelectToken("$.id").Value<int>();

            Assert.AreEqual(milestoneId, actualMilestoneId);
        }

        [Test, Order(4)]
        public void UpdateMilestoneTest()
        {
            var expectedMilestone = new Milestone();
            expectedMilestone.Name = "New Milestone";
            expectedMilestone.Description = "The Milestone after update";
                 
            var actualMilestone = _milestoneService.UpdateMilestonee(expectedMilestone, milestoneId);
            _logger.Info("jsonObject: " + actualMilestone.ToString());

            //Выполним десериализацию JSON - строки в объект JObject
            var jsonObject = JObject.Parse(actualMilestone.Content);

            //Использование JsonPath для извлечения занчения из объекта
            string actualMilestoneName = jsonObject.SelectToken("$.name").Value<string>();

            Assert.AreEqual(expectedMilestone.Name, actualMilestoneName);
        }

        [Test, Order(5)]
        public void DeleteMilestoneTest()
        {
            var actualMilestone = _milestoneService.DeleteMilestone(milestoneId);
            _logger.Info(actualMilestone.StatusCode.ToString);
                        
            Assert.IsEmpty(actualMilestone.Content);
        }
    }
}
