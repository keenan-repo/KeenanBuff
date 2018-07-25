using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KeenanBuff.Common.Logger.Interfaces;
using KeenanBuff.Common.Queries.Interfaces;
using KeenanBuff.Entities.Context.Interfaces;
using KeenanBuff.Models;

namespace KeenanBuff.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IKeenanBuffContext _context;
        private readonly IQueries _queries;
        private readonly IFileLogger _fileLogger;

        public PlayerController(IKeenanBuffContext context, IFileLogger fileLogger, IQueries queries)
        {
            _context = context;
            _fileLogger = fileLogger;
            _queries = queries;
        }

        [OutputCache(Duration = 7200, VaryByParam = "none")]
        public ActionResult Index()
        {
            var playerOverview = new PlayerOverview();

            BuildPlayerOverview(playerOverview);

            return View(playerOverview);
        }

        private void BuildPlayerOverview(PlayerOverview playerOverview)
        {
            try
            {
                var matches = _queries.GetMyMatcheDetails();

                var HeroStats = _context.MatchDetails
                    .Where(p => p.PlayerID == 90935174)
                    .GroupBy(hero => hero.Hero)
                    .Select(group => new { Hero = group.Key, Count = group.Count() }).ToList().Where(x => x.Count > 1)
                    .Select(x => new
                    {
                        Hero = x.Hero,
                        WinRate = (_queries.GetWonMatches().Count(h => h.Hero.HeroId == x.Hero.HeroId) * 100.0 / x.Count),
                        Matches = x.Count,
                        LastMatch = matches.Where(h => h.Hero.HeroId == x.Hero.HeroId).Select(m => m.Match).OrderBy(d => d.StartTime).First(),
                        Kda = matches.Where(h => h.Hero.HeroId == x.Hero.HeroId).Average(a => a.Kills / (a.Deaths == 0 ? 1 : a.Deaths)),
                        AverageAssists = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Assists) * 10),
                        AverageKills = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Kills) * 10),
                        AverageDeaths = (matches.SelectMany(m => m.Match.MatchDetails).Where(p => p.PlayerID == 90935174 && p.Hero.HeroId == x.Hero.HeroId).Average(a => a.Deaths) * 10)
                    }).OrderByDescending(h => h.Matches).ThenByDescending(h => h.WinRate).Select(h => new HeroStat
                    {
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
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.ToString());
            }

        }

        private List<WinRatePoint> CalculateWinRatePlot()
        {
            var matches = _context.Matches.ToList();
            var startdate = matches.Min(x => x.StartTime);
            var enddate = DateTime.Now;

            var days = Enumerable.Range(0, 1 + enddate.Subtract(startdate).Days)
                .Select(offset => startdate.AddDays(offset)).ToList();
            var WinRate = new List<WinRatePoint>();

            try
            {
                foreach (var day in days)
                {
                    var totalGames = _context.Matches.Count(x => x.StartTime < day);
                    var wins = _context.MatchDetails.Count(x => x.Match.StartTime < day && x.PlayerID == 90935174 && ((x.PlayerSlot < 6 && x.Match.RadiantWin) || (x.PlayerSlot > 5 && !x.Match.RadiantWin)));

                    if (totalGames > 0)
                    {
                        var winratepoint = new WinRatePoint { Date = day.ToString("yyyy/MM/dd"), WinRate = wins * 100.0 / totalGames };
                        WinRate.Add(winratepoint);
                    }
                }
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.ToString());
            }

            return WinRate;
        }
    }
}