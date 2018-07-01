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
using KeenanBuff.Entities;

namespace KeenanBuff.Controllers
{
    public class MatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matches
        public ActionResult Index(int? page, int? heroId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var results = db.Matches
                    .OrderByDescending(m => m.StartTime).ToPagedList(pageNumber, pageSize);


            if (heroId.HasValue)
            {
                results = db.Matches.Where(m => m.MatchDetails.Where(md => md.HeroId == heroId && md.PlayerID == 90935174).Any())
                    ?.OrderByDescending(m => m.StartTime).ToPagedList(pageNumber, pageSize);
            }

            return View(results);
        }

        // GET: Matches/Details/5
        public ActionResult Details(long id)
        {
            return View(db.Matches.Single(m => m.MatchID == id));
            
        }

    }
}
