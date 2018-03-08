using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeenanBuff.Models;
using Hangfire;
using KeenanBuff.Data.Context;

namespace KeenanBuff.Controllers
{



    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           var thing =  db.Matches.First().MatchDetails.FirstOrDefault().PlayerItems;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //BackgroundJob.Enqueue(() => Migrations.Configuration.);


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}