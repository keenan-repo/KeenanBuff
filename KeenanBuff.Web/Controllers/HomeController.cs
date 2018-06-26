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
            return View();
        }

        public ActionResult Arcade()
        {


            return View();
        }

    }
}