using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeenanBuff.Models;
using KeenanBuff.Data.Context;
using PagedList;
namespace KeenanBuff.Controllers
{
    public class MatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matches
        public ActionResult Index(int? page)
        {

            var heroes = db.MatchDetails.Where(x => x.PlayerID == 90935174).Select(h => h.Hero).Distinct().ToList();

            var matches = db.MatchDetails.Where(x => x.PlayerID == 90935174).GroupBy(hero => hero.Hero)
                .Select(group => new { Hero = group.Key, Count = group.Count() }).ToList();

            var wonMatches = db.MatchDetails.Where(x => x.PlayerID == 90935174 && (x.PlayerSlot < 6 && x.Match.RadiantWin) || (x.PlayerSlot > 5 && !x.Match.RadiantWin))
                .GroupBy(hero => hero.Hero)
                .Select(group => new { Hero = group.Key, Count = group.Count() }).ToList();
            /* Hero
             * last match
             * Matches
             * Win %
             * kda
             */


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.Matches.OrderByDescending(m => m.StartTime).ToPagedList(pageNumber, pageSize));
        }

        // GET: Matches/Details/5
        public ActionResult Details(long? id)
        {
            return View(db.Matches.Single(m => m.MatchID == id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
