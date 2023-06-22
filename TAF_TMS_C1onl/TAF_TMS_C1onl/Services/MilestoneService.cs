using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services
{
    public class MilestoneService : BaseService
    {
        public static readonly string ADD_MILESTONE = "index.php?/api/v2/add_milestone/{project_id}";
        public static readonly string GET_MILESTONE = "index.php?/api/v2/get_milestone/{milestone_id}";
        public static readonly string UPDATE_MILESTONE = "index.php?/api/v2/update_milestone/{milestone_id}";
        public static readonly string DELETE_MILESTONE = "index.php?/api/v2/delete_milestone/{milestone_id}";

        public MilestoneService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse AddMilestone(Milestone someMilestone, int projectId)
        {
            var request = new RestRequest(ADD_MILESTONE, Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(someMilestone);

            return _apiClient.Execute(request);
        }

        public Milestone AddMilestoneBDD(Milestone someMilestone, int projectId)
        {
            var request = new RestRequest(ADD_MILESTONE, Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(someMilestone);

            return _apiClient.Execute<Milestone>(request);
        }

        public RestResponse GetMilestone(int milestone_id)
        {
            var request = new RestRequest(GET_MILESTONE)
                .AddUrlSegment("milestone_id", milestone_id);

            return _apiClient.Execute(request);
        }

        public Milestone GetMilestoneBDD(int milestone_id)
        {
            var request = new RestRequest(GET_MILESTONE)
                .AddUrlSegment("milestone_id", milestone_id);

            return _apiClient.Execute<Milestone>(request);
        }

        public RestResponse UpdateMilestonee(Milestone someMilestone, int milestone_id)
        {
            var request = new RestRequest(UPDATE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestone_id)
                .AddHeader("Content-Type", "application/json")
                .AddBody(someMilestone);

            return _apiClient.Execute(request);
        }

        public Milestone UpdateMilestoneeBDD(Milestone someMilestone, int milestone_id)
        {
            var request = new RestRequest(UPDATE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestone_id)
                .AddHeader("Content-Type", "application/json")
                .AddBody(someMilestone);

            return _apiClient.Execute<Milestone>(request);
        }

        public RestResponse DeleteMilestone(int milestone_id)
        {
            var request = new RestRequest(DELETE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestone_id)
                .AddHeader("Content-Type", "application/json");

            return _apiClient.Execute(request);
        }

        public Milestone DeleteMilestoneBDD(int milestone_id)
        {
            var request = new RestRequest(DELETE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestone_id)
                .AddHeader("Content-Type", "application/json");

            return _apiClient.Execute<Milestone>(request);
        }
    }
}
