using System;
using System.ComponentModel.DataAnnotations;

namespace KeenanBuff.Entites.SteamAPI.APIModels
{
    public class DotaPlayer
    {
        [Key]
        public int ID { get; set; }
        public Int64 account_id { get; set; }
        public int player_slot { get; set; }
        public int hero_id { get; set; }
        public string steam_name { get; set; }

        public string personaname { get; set; }
        public string profilestate { get; set; }

        public int item_0 { get; set; }
        public int item_1 { get; set; }
        public int item_2 { get; set; }
        public int item_3 { get; set; }
        public int item_4 { get; set; }
        public int item_5 { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int leaver_status { get; set; }
        public int last_hits { get; set; }
        public int denies { get; set; }
        public int gold_per_min { get; set; }
        public int xp_per_min { get; set; }
        public int level { get; set; }
        public int gold { get; set; }
        public int gold_spent { get; set; }
        public int hero_damage { get; set; }
        public int tower_damage { get; set; }
        public int hero_healing { get; set; }
    }
}