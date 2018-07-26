using System;
using System.Collections.Generic;
using System.Configuration;
using KeenanBuff.Common.SteamAPI.Interfaces;
using KeenanBuff.Common.SteamAPI.APIModels;

namespace KeenanBuff.Common.SteamAPI
{
    public class ApiCalls : IApiCalls
    {
        public string API_KEY = ConfigurationManager.AppSettings["APIKey"];
        private readonly IKeenanBuffRestClient _restClient;

        public ApiCalls(IKeenanBuffRestClient restClient)
        {
            _restClient = restClient;
        }

        public Result GetMatchHistory(long ID, string start_match_id = null, string NumOfMatches = "2")
        {
            //we need the start match then the next match
            var URL_history = "/IDOTA2Match_570/GetMatchHistory/V001" + "?key=" + API_KEY
                + "&account_id=" + ID + "&matches_requested=" + NumOfMatches + "&start_at_match_id=" + start_match_id;

            var response = _restClient.Get<RootObject>(URL_history);
            return response.Data.result;
        }

        public List<Hero> GetHeroes()
        {
            var URL_Heroes = "/IEconDOTA2_570/GetHeroes/v1" + "?key=" + API_KEY + "&language=english";

            var response = _restClient.Get<RootObject>(URL_Heroes);
            return response.Data.result.heroes;
        }

        public List<Item> GetItems()
        {
            var URL_Items = "/IEconDOTA2_570/GetGameItems/v1" + "?key=" + API_KEY + "&language=english";

            var response = _restClient.Get<RootObject>(URL_Items);
            return response.Data.result.items;
        }

        public MatchDetails GetMatchDetails(long id)
        {
            var URL_Details = "/IDOTA2Match_570/GetMatchDetails/V001/?key=" + API_KEY + "&match_id=" + id;

            var response = _restClient.Get<MatchDetails>(URL_Details);

            foreach (var player in response.Data.result.players)
            {
                player.steam_name = GetSteamName(player.account_id);
            }

            return response.Data;
        }

        public string GetSteamName(Int64 account_id)
        {
            var steam_name = "Anonymous";
            var SteamID = account_id + 76561197960265728;

            if (SteamID == 76561202255233023) //a little arbitrary but this defines an anon account.
            {
                return steam_name;
            }
            else
            {
                string URL_Resource = "/ISteamUser/GetPlayerSummaries/v0002/?key=FECFA52826DCE092D6752CA087B111F8&steamids=" + SteamID; 

                var response = _restClient.Get<RootObject>(URL_Resource);
                //For some reason players is an array so we just grab the zeroth one
                steam_name = response.Data.response.players[0].personaname;
                return steam_name;
            };
        }
    }
}





