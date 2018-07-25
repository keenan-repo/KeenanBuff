using RestSharp;
using System.Configuration;

namespace KeenanBuff.Common.SteamAPI.Interfaces
{
    public class KeenanBuffRestClient : IKeenanBuffRestClient
    {
        private string BASE_URL = ConfigurationManager.AppSettings["BaseUrl"];
        private RestClient CLIENT => new RestClient(BASE_URL);

        public IRestResponse<T> Get<T>(string resource) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);

            return CLIENT.Execute<T>(request);
        }
    }
}