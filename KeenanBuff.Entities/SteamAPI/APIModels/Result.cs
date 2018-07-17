using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeenanBuff.Entites.SteamAPI.APIModels
{
    public class Result
    {
        public string status { get; set; }
        public string num_results { get; set; }
        public string total_results { get; set; }
        public string results_remaining { get; set; }
        public List<Item> items { get; set; }
        public List<Hero> heroes { get; set; }
        public List<Match> matches { get; set; }
    }

    public class Hero
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public string localized_name { get; set; }
    }

    public class Match
    {
        public Int64 match_id { get; set; }

        public Int64 match_seq_num { get; set; }
        public Int64 start_time { get; set; }
        public int lobby_type { get; set; }
        public int game_mode { get; set; }
        public int radiant_team_id { get; set; }
        public int dire_team_id { get; set; }

        public List<DotaPlayer> players { get; set; }
    }
}