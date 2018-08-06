using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using KeenanBuff.Entities.Context.Interfaces;
using KeenanBuff.Common.Logger.Interfaces;
using KeenanBuff.Models;
using KeenanBuff.Entities;
using System.Collections.Generic;

namespace KeenanBuff.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IKeenanBuffContext _context;
        private readonly IFileLogger _fileLogger;
        private readonly long playerID = 90935174;

        public MatchesController(IKeenanBuffContext context, IFileLogger fileLogger)
        {
            _context = context;
            _fileLogger = fileLogger;
        }

        [OutputCache(Duration = 7200, VaryByParam = "heroId;page")]
        public ActionResult Index(int? page, int? heroId)
        {
            return View();
        }

        // GET: Matches/Details/
        public ActionResult Details(long id)
        {
            var viewmodel = _context.MatchDetails.Where(md => md.MatchID == id).Select(m => new
            {
                m.MatchID,
                m.Match.LobbyString,
                m.Match.StartTime,
                m.Match.RadiantWin,
                m.Match.RadiantScore,
                m.Match.DireScore,
                m.PlayerSlot,
                m.Hero.HeroUrl,
                m.SteamName,
                m.Level,
                m.Kills,
                m.Assists,
                m.Deaths,
                m.Gold,
                m.LastHits,
                m.Denies,
                m.GoldPerMin,
                m.XpPerMin,
                Items = m.PlayerItems,
                m.Match.Duration
            }).ToList()
            .Select(s => new MatchDetailViewModel {
                MatchID = s.MatchID.ToString(),
                LobbyString = s.LobbyString,
                StartTime = s.StartTime.ToString("MM/dd/yyyy"),
                RadiantWin = s.RadiantWin,
                RadiantScore = s.RadiantScore.ToString(),
                DireScore = s.DireScore.ToString(),
                PlayerSlot = s.PlayerSlot,
                HeroUrl = s.HeroUrl,
                SteamName = s.SteamName,
                Level = s.Level.ToString(),
                Kda = s.Kills.ToString() + "/" + s.Deaths.ToString() + "/" + s.Assists.ToString(),
                Networth = CalculateNetworth(s.Gold, s.Items.ToList()),
                LastHits = s.LastHits.ToString(),
                Denies = s.Denies.ToString(),
                GoldPerMin = s.GoldPerMin.ToString(),
                XpPerMin = s.XpPerMin.ToString(),
                Items = s.Items.ToList(),
                Duration = (s.Duration / 60).ToString("##") + ":" + (s.Duration % 60).ToString("##")
            }).ToList();

            //return View(_context.Matches.Single(m => m.MatchID == id));
            return View(viewmodel);
        }

        public ActionResult _MatchesTable(int? page, int? heroId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            try
            {
                var FilteredMatches = _context.MatchDetails.Where(md => !heroId.HasValue || (md.HeroId == heroId && md.PlayerID == playerID))
                    .Select(x => x.Match).Distinct();

                var viewModel = FilteredMatches
                    .Select(x => new {
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).Hero.HeroUrl, //only ever one
                        x.MatchID,
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).Hero.HeroName,
                        x.RadiantWin,
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).PlayerSlot,
                        x.StartTime,
                        x.LobbyString,
                        GameMode = x.GameModeString,
                        x.Duration,
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).Kills,
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).Deaths,
                        x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).Assists,
                        Items = x.MatchDetails.FirstOrDefault(md => md.PlayerID == playerID).PlayerItems
                    }).ToList().Select(m => new MatchViewModel
                    {
                        HeroUrl = m.HeroUrl,
                        MatchID = m.MatchID.ToString(),
                        HeroName = m.HeroName,
                        RadiantWin = m.RadiantWin,
                        PlayerSlot = m.PlayerSlot,
                        StartTime = m.StartTime.ToString("MM/dd/yyyy"),
                        LobbyString = m.LobbyString,
                        GameMode = m.GameMode,
                        Duration = (m.Duration / 60).ToString("##") + ":" + (m.Duration % 60).ToString("##"),
                        Kda = m.Kills.ToString() + "/" + m.Deaths.ToString() + "/" + m.Assists.ToString(),
                        Items = m.Items.ToList()
                    }).ToList().Distinct().OrderByDescending(m => m.StartTime).ToPagedList(pageNumber, pageSize);

                return PartialView("_MatchesTable", viewModel);
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.ToString());
                return PartialView("_MatchesTable");
            }      
        }

        //since valves networth/total gold is sometimes randomly empty, i'll do it myself
        private string CalculateNetworth(long gold, List<PlayerItem> items)
        {
            var total = gold;
            foreach(var item in items)
            {
                total += item.Item.Cost;
            }

            return total.ToString();
        }

    }
}
