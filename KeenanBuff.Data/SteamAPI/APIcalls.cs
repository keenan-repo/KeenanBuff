using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using KeenanBuff.Models;
using RestSharp;

namespace KeenanBuff.Data.SteamAPI
{
    public class APIcalls
    {
        public static string API_KEY = "FECFA52826DCE092D6752CA087B111F8";


        public static APIModels.Result getMatchHistory(long ID)
        {
            int num_matches = 20;
            string URL_Domain_MatchHistory = "https://api.steampowered.com";
            string URL_history = "/IDOTA2Match_570/GetMatchHistory/V001" + "?key=" + SteamAPI.APIcalls.API_KEY + "&account_id=" + ID + "&matches_requested=" + num_matches;

            var client = new RestClient(URL_Domain_MatchHistory);
            var request = new RestRequest(URL_history, Method.GET);

            IRestResponse<APIModels.RootObject> response = client.Execute<APIModels.RootObject>(request);
            return response.Data.result;
        }

        public static List<APIModels.Hero> getHeroes()
        {
            string URL_Domain = "http://api.steampowered.com";
            string URL_Heroes = "/IEconDOTA2_570/GetHeroes/v1" + "?key=" + SteamAPI.APIcalls.API_KEY + "&language=english";

            var client = new RestClient(URL_Domain);
            var request = new RestRequest(URL_Heroes, Method.GET);

            IRestResponse<APIModels.RootObject> response = client.Execute<APIModels.RootObject>(request);
            return response.Data.result.heroes;
        }

        public static List<APIModels.Item> getItems()
        {
            string URL_Domain = "http://api.steampowered.com";
            string URL_Heroes = "/IEconDOTA2_570/GetGameItems/v1" + "?key=" + SteamAPI.APIcalls.API_KEY + "&language=english";

            var client = new RestClient(URL_Domain);
            var request = new RestRequest(URL_Heroes, Method.GET);

            IRestResponse<APIModels.RootObject> response = client.Execute<APIModels.RootObject>(request);
            return response.Data.result.items;
        }

        public static APIModels.MatchDetails getMatchDetails(long id)
        {
            string URL_Domain = "https://api.steampowered.com";
            string URL_Details = "/IDOTA2Match_570/GetMatchDetails/V001/?key=" + SteamAPI.APIcalls.API_KEY + "&match_id=" + id;

            var client = new RestClient(URL_Domain);
            var request = new RestRequest(URL_Details, Method.GET);

            IRestResponse<Data.SteamAPI.APIModels.MatchDetails> response = client.Execute<APIModels.MatchDetails>(request);

            foreach (APIModels.DotaPlayer player in response.Data.result.players)
            {
                player.steam_name = APIcalls.getSteamName(player.account_id);
            }

            return response.Data;
        }


        public static string getSteamName(Int64 account_id)
        {
            string steam_name = "Anonymous";
            Int64 SteamID = account_id + 76561197960265728;

            if (SteamID == 76561202255233023) //a little arbitrary but this defines an anon account. TODO: Improve this
            {
                return steam_name;
            }
            else
            {
                string URL_Domain = "http://api.steampowered.com";
                string URL_Resource = "/ISteamUser/GetPlayerSummaries/v0002/?key=FECFA52826DCE092D6752CA087B111F8&steamids=" + SteamID; 

                var client = new RestClient(URL_Domain);
                var request = new RestRequest(URL_Resource, Method.GET);

                IRestResponse<APIModels.RootObject> response = client.Execute<APIModels.RootObject>(request);
                //For some reason players is an array so we just grab the "first" one
                steam_name = response.Data.response.players[0].personaname;
                return steam_name;
            };
        }


    }

}