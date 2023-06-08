using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CaseTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public int id { get; set; }

        [Test, Order(1)]
        public void AddCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.SectionID = 1;
            expectedCase.Title = "API case test PRACTICE_1";
            expectedCase.TypeId = 5;
            expectedCase.PriorityId = 1;

            var actualCase = _caseService.AddCase(expectedCase, 1);
            _logger.Info("jsonObject: " + actualCase.ToString());

            //Выполним десериализацию JSON - строки в объект JObject
            var jsonObject = JObject.Parse(actualCase.Content);

            //Использование JsonPath для извлечения занчения из объекта
            string actualTitle = jsonObject.SelectToken("$.title").Value<string>();

            //Получение Id для UpdateTestCase
            var jsonObjectId = JObject.Parse(actualCase.Content);
            id = jsonObjectId.SelectToken("$.id").Value<int>();
            Console.WriteLine("Test: " + id);

            Assert.AreEqual(expectedCase.Title, actualTitle);
        }

        [Test, Order(2)]
        public void GetTestCaseTest()
        {
            var actualCase = _caseService.GetCase(id);
            _logger.Info(actualCase.Content);

            int actualId = JObject.Parse(actualCase.Content).SelectToken("$.id").Value<int>();

            Assert.AreEqual(id, actualId);
        }

        // I DON'T UNDERTAND WHY DOES THIS TEST FAILED???
        [Test, Order(3)]
        public void UpdateTestCase()
        {
            var expectedCase = new Case();
            expectedCase.SectionID = 2;
            expectedCase.Title = "Updated API case test PRACTICE_33";
            expectedCase.TypeId = 5;
            expectedCase.PriorityId = 2;

            Console.WriteLine($"Update id: {id}");

            var actualCase = _caseService.UpdateCase(expectedCase, id);
            _logger.Info("jsonObject: " + actualCase.ToString());

            //Выполним десериализацию JSON - строки в объект JObject
            var jsonObject = JObject.Parse(actualCase.Content);

            //Использование JsonPath для извлечения занчения из объекта
            string actualTitle = jsonObject.SelectToken("$.title").Value<string>();

            Assert.AreEqual(expectedCase.Title, actualTitle);
        }

        [Test, Order(4)]
        public void DeleteTestCase()
        {
            var actualCase = _caseService.DeleteCase(id);
            _logger.Info(actualCase.StatusCode.ToString);
        }
    }
}
