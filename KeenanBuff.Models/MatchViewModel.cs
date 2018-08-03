using KeenanBuff.Entities;
using System.Collections.Generic;

namespace KeenanBuff.Models
{
    public class MatchViewModel
    {
        public string HeroUrl { get; set; }
        public string MatchID { get; set; }
        public string HeroName { get; set; }
        public bool RadiantWin { get; set; }
        public int PlayerSlot { get; set; }
        public string StartTime { get; set; }
        public string LobbyString { get; set; }
        public string GameMode { get; set; }
        public string Duration { get; set; }
        public string Kda { get; set; }
        public List<PlayerItem> Items {get;set;}
    }
}