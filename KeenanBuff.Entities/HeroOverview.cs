using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenanBuff.Entities
{
    public class HeroOverview
    {
        [Key]
        [Column(Order = 1)]
        public long PlayerID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int hero_id { get; set; }
        public string hero_name { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float WinRate { get; set; }
        public float KDA { get; set; }
    }
}