using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenanBuff.Data.Context;
using KeenanBuff.Models;

namespace KeenanBuff.Controllers
{
    public class PlayerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var playerOverview = new PlayerOverview();

            var heroes = db.MatchDetails.Where(x => x.PlayerID == 90935174).Select(h => h.Hero).Distinct().ToList();

            var matches = db.MatchDetails.Where(x => x.PlayerID == 90935174);

            var wonMatches = db.MatchDetails
                .Where(x => x.PlayerID == 90935174 && ((x.PlayerSlot < 6 && x.Match.RadiantWin) || (x.PlayerSlot > 5 && !x.Match.RadiantWin)));

            var HeroStats = db.MatchDetails
                .Where(p => p.PlayerID == 90935174)
                .GroupBy(hero => hero.Hero)
                .Select(group => new { Hero = group.Key, Count = group.Count() }).ToList().Where(x => x.Count > 1)
                .Select(x => new
                {
                    Hero = x.Hero,
                    WinRate = (wonMatches.Count(h => h.Hero.HeroId == x.Hero.HeroId) * 100.0 / x.Count),
                    Matches = x.Count,
                    LastMatch = matches.Where(h => h.Hero.HeroId == x.Hero.HeroId).Select(m => m.Match).OrderBy(d => d.StartTime).First(),
                    Kda = matches.Where(h => h.Hero.HeroId == x.Hero.HeroId).Average(a => a.Kills / (a.Deaths == 0 ? 1 : a.Deaths)),
                    AverageAssists = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Assists) * 10),
                    AverageKills = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Kills) * 10),
                    AverageDeaths = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Deaths) * 10)
                }).OrderByDescending(h => h.Matches).ThenByDescending(h => h.WinRate).Select(h => new HeroStat {
                    Hero = h.Hero,
                    WinRate = h.WinRate.ToString("##.#"),
                    Matches = h.Matches.ToString("##"),
                    LastMatch = h.LastMatch,
                    Kda = h.Kda.ToString("0.0"),
                    AverageAssists = h.AverageAssists.ToString("0.00"),
                    AverageKills = h.AverageKills.ToString("0.00"),
                    AverageDeaths = h.AverageDeaths.ToString("0.00")
                }).Take(10).ToList();

            playerOverview.HeroStats = HeroStats;
            playerOverview.WinRate = CalculateWinRatePlot();

            return View(playerOverview);
        }

        private List<WinRatePoint> CalculateWinRatePlot()
        {
            var matches = db.Matches.ToList();
            var startdate = matches.Min(x => x.StartTime);
            var enddate = DateTime.Now;

            var days = Enumerable.Range(0, 1 + enddate.Subtract(startdate).Days)
                .Select(offset => startdate.AddDays(offset)).ToList();
            var WinRate = new List<WinRatePoint>();

            foreach (var day in days)
            {
                var totalGames = db.Matches.Count(x => x.StartTime < day);
                var wins = db.MatchDetails.Count(x => x.Match.StartTime < day && x.PlayerID == 90935174 && ((x.PlayerSlot < 6 && x.Match.RadiantWin) || (x.PlayerSlot > 5 && !x.Match.RadiantWin)));

                if (totalGames > 0)
                {
                    var winratepoint = new WinRatePoint { Date = day, WinRate = wins * 100.0 / totalGames };
                    WinRate.Add(winratepoint);
                }
            }


            //find start date
            //define winrate variable
            //winrate at point x = number of wins divided by i
            //count wins where date started less than next date

            return WinRate;
        }
    }
}