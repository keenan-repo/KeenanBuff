using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KeenanBuff.Entites.SteamAPI.APIModels
{
    public class MatchDetailsResult
    {
        public List<DotaPlayer> players { get; set; }
        public Boolean radiant_win { get; set; }
        public int duration { get; set; }
        public int pre_game_duration { get; set; }
        public Int64 start_time { get; set; }
        public Int64 match_seq_num { get; set; }
        public int lobby_type { get; set; }
        public int game_mode { get; set; }
        public int tower_status_radiant { get; set; }
        public int tower_status_dire { get; set; }
        public int barracks_status_radiant { get; set; }
        public int barracks_status_dire { get; set; }
        public int first_blood_time { get; set; }
        public int radiant_score { get; set; }
        public int dire_score { get; set; }
    }
}