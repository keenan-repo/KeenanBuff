using KeenanBuff.Entities;
using System.Collections.Generic;

namespace KeenanBuff.Models
{
    public class MatchDetailViewModel
    {
        public string MatchID { get; set; }
        public string LobbyString { get; set; }
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public bool RadiantWin { get; set; }
        public string DireScore { get; set; }
        public string RadiantScore { get; set; }
        public string HeroUrl { get; set; }
        public int PlayerSlot { get; set; }
        public string SteamName { get; set; }
        public string Level { get; set; }
        public string Kda { get; set; }
        public string Networth { get; set; }
        public string LastHits { get; set; }
        public string Denies { get; set; }
        public string GoldPerMin { get; set; }
        public string XpPerMin { get; set; }
        public string HeroDamage { get; set; }
        public string HeroHealing { get; set; }
        public List<PlayerItem> Items { get; set; }
    }
}