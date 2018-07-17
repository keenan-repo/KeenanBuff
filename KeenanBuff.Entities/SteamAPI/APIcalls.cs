using System;
using System.Collections.Generic;
using RestSharp;
using System.Configuration;

namespace KeenanBuff.Entites.SteamAPI
{
    public class APIcalls
    {
        public static string API_KEY = ConfigurationManager.AppSettings["APIKey"];
        public static string BASE_URL = ConfigurationManager.AppSettings["BaseUrl"];
        public static RestClient CLIENT = new RestClient(BASE_URL);

        public static APIModels.Result GetMatchHistory(long ID, long start_match_id)
        {
            int num_matches = 2; //we need the start match then the next match
            string URL_history = "/IDOTA2Match_570/GetMatchHistory/V001" + "?key=" + API_KEY
                + "&account_id=" + ID + "&matches_requested=" + num_matches + "&start_at_match_id=" + start_match_id;

            var request = new RestRequest(URL_history, Method.GET);

            var response = CLIENT.Execute<APIModels.RootObject>(request);
            return response.Data.result;
        }

        public static List<APIModels.Hero> GetHeroes()
        {
            string URL_Heroes = "/IEconDOTA2_570/GetHeroes/v1" + "?key=" + API_KEY + "&language=english";

            var request = new RestRequest(URL_Heroes, Method.GET);

            var response = CLIENT.Execute<APIModels.RootObject>(request);
            return response.Data.result.heroes;
        }

        public static List<APIModels.Item> GetItems()
        {
            string URL_Heroes = "/IEconDOTA2_570/GetGameItems/v1" + "?key=" + API_KEY + "&language=english";

            var request = new RestRequest(URL_Heroes, Method.GET);

            var response = CLIENT.Execute<APIModels.RootObject>(request);
            return response.Data.result.items;
        }

        public static APIModels.MatchDetails GetMatchDetails(long id)
        {
            string URL_Details = "/IDOTA2Match_570/GetMatchDetails/V001/?key=" + SteamAPI.APIcalls.API_KEY + "&match_id=" + id;

            var request = new RestRequest(URL_Details, Method.GET);

            var response = CLIENT.Execute<APIModels.MatchDetails>(request);

            foreach (var player in response.Data.result.players)
            {
                player.steam_name = APIcalls.GetSteamName(player.account_id);
            }

            return response.Data;
        }


        public static string GetSteamName(Int64 account_id)
        {
            string steam_name = "Anonymous";
            Int64 SteamID = account_id + 76561197960265728;

            if (SteamID == 76561202255233023) //a little arbitrary but this defines an anon account.
            {
                return steam_name;
            }
            else
            {
                string URL_Resource = "/ISteamUser/GetPlayerSummaries/v0002/?key=FECFA52826DCE092D6752CA087B111F8&steamids=" + SteamID; 

                var request = new RestRequest(URL_Resource, Method.GET);

                var response = CLIENT.Execute<APIModels.RootObject>(request);
                //For some reason players is an array so we just grab the "first" one
                steam_name = response.Data.response.players[0].personaname;
                return steam_name;
            };
        }


    }

}