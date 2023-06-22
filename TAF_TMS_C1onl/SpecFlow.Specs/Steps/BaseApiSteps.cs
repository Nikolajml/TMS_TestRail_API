using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Services;

namespace SpecFlow.Specs.Steps
{
    public class BaseApiSteps
    {
        protected ApiClient apiClient;
        protected CaseService caseService;
        protected ProjectService projectService;
        protected MilestoneService milestoneService;

        public BaseApiSteps()
        {
            apiClient = new ApiClient();
            caseService = new CaseService(apiClient);
            projectService = new ProjectService(apiClient);
            milestoneService = new MilestoneService(apiClient);
        }
    }
}
