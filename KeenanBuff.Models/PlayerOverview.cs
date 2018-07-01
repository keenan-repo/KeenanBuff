using KeenanBuff.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeenanBuff.Models
{
    public class PlayerOverview
    {
        public List<HeroStat> HeroStats { get; set; }
        public List<WinRatePoint> WinRate { get; set; }
        public string OverallWinrate { get; set; }
        public string OverallWonMatches { get; set; }
        public string OverallLostMatches { get; set; }
    }
}