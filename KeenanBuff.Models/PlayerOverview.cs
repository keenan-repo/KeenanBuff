using KeenanBuff.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeenanBuff.Models
{
    public class PlayerOverview
    {
        public string Hero { get; set; }
        public string LastMatch { get; set; }
        public int Matches { get; set; }
        public double WinRate { get; set; }
        public double Kda { get; set; }
    }
}