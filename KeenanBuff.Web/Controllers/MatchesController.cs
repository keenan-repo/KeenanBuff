using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using KeenanBuff.Entities.Context.Interfaces;
using KeenanBuff.Common.Logger.Interfaces;

namespace KeenanBuff.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IKeenanBuffContext _context;
        private readonly IFileLogger _fileLogger;

        public MatchesController(IKeenanBuffContext context, IFileLogger fileLogger)
        {
            _context = context;
            _fileLogger = fileLogger;
        }


        //[OutputCache(Duration = 7200, VaryByParam = "none")]
        public ActionResult Index(int? page, int? heroId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var results = _context.Matches.OrderByDescending(m => m.StartTime).Take(50).ToPagedList(pageNumber, pageSize);

            try
            {
                if (heroId.HasValue)
                {
                    results = results.Where(m => m.MatchDetails.Where(md => md.HeroId == heroId && md.PlayerID == 90935174).Any())
                        ?.OrderByDescending(m => m.StartTime).ToPagedList(pageNumber, pageSize);
                }
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.ToString());
            }
 

            return View(results);
        }

        // GET: Matches/Details/5
        public ActionResult Details(long id)
        {
            return View(_context.Matches.Single(m => m.MatchID == id));
            
        }

        public ActionResult _MatchesTable(int? page, int? heroId)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var results = _context.Matches.OrderByDescending(m => m.StartTime).Take(50).ToPagedList(pageNumber, pageSize);

            return PartialView("_MatchesTable", results);
        }

    }
}
