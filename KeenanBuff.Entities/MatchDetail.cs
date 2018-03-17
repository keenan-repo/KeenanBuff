using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace KeenanBuff.Entities

{
    public class MatchDetail
    {
        public MatchDetail()
        {
            MatchDetailId = Guid.NewGuid();
            PlayerItems = new Collection<PlayerItem>();
        }

        public Guid MatchDetailId { get; set; }

        public Int64 PlayerID { get; set; }
        public Int64 MatchID { get; set; }
        public string SteamName { get; set; }

        public int PlayerSlot { get; set; }
        public int HeroId { get; set; }

        public virtual ICollection<PlayerItem> PlayerItems { get; set; } = new Collection<PlayerItem>();
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int LeaverStatus { get; set; }
        public int LastHits { get; set; }
        public int Denies { get; set; }
        public int GoldPerMin { get; set; }
        public int XpPerMin { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int GoldSpent { get; set; }
        public int HeroDamage { get; set; }
        public int TowerDamage { get; set; }
        public int HeroHealing { get; set; }

        public virtual Match Match { get; set; } 
        public virtual Hero Hero { get; set; }
    }
}