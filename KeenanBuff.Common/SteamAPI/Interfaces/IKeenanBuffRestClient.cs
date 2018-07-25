using RestSharp;

namespace KeenanBuff.Common.SteamAPI.Interfaces
{
    public interface IKeenanBuffRestClient 
    {
        IRestResponse<T> Get<T>(string resource) where T : new();
    }
}
