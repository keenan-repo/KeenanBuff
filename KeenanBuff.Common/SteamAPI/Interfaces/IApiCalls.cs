using KeenanBuff.Common.SteamAPI.APIModels;
using System;
using System.Collections.Generic;

namespace KeenanBuff.Common.SteamAPI.Interfaces
{
    public interface IApiCalls
    {
        Result GetMatchHistory(long ID, string start_match_id = null, int NumOfMatches = 2);
        List<Hero> GetHeroes();
        List<Item> GetItems();
        MatchDetails GetMatchDetails(long id);
        string GetSteamName(Int64 account_id);
    }
}
