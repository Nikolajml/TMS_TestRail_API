using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
    public class ApiClientHook
    {
        private readonly ApiClient apiClient;

        public ApiClientHook(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        [BeforeScenario("API")]
        public void BeforeScenario()
        {
            Console.Out.WriteLine("API");
        }
    }
}
