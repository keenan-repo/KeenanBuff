using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace KeenanBuff.Entities
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 MatchID { get; set; }
       /* [Key]
        [Column(Order = 2)]
        public Int64 match_id { get; set; }*/

        public Int64 MatchSeqNum { get; set; }
        public DateTime StartTime { get; set; }
        public int LobbyType { get; set; }
        public string LobbyString { get; set; }

        public int GameMode { get; set; }
        public string GameModeString { get; set; }
        public int RadiantTeamId { get; set; }
        public int DireTeamId { get; set; }

        public Boolean RadiantWin { get; set; }
        public int Duration { get; set; }

        public int TowerStatusRadiant { get; set; }
        public int TowerStatusDire { get; set; }
        public int BarracksStatusRadiant { get; set; }
        public int BarracksStatusDire { get; set; }
        public int FirstBloodTime { get; set; }
        public int RadiantScore { get; set; }
        public int DireScore { get; set; }

        public virtual ICollection<MatchDetail> MatchDetails { get; set; } = new Collection<MatchDetail>();

    }
}