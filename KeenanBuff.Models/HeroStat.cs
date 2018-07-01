using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeenanBuff.Entities;

namespace KeenanBuff.Models
{
    public class HeroStat
    {
        public Hero Hero { get; set; }
        public Match LastMatch { get; set; }
        public string Matches { get; set; }
        public string WinRate { get; set; }
        public string Kda { get; set; }
        public string AverageKills { get; set; }
        public string AverageAssists { get; set; }
        public string AverageDeaths{ get; set; }
    }
}