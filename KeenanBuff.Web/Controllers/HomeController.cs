using KeenanBuff.Common.Logger.Interfaces;
using System.Web.Mvc;


namespace KeenanBuff.Controllers
{

    public class HomeController : Controller
    {
        private readonly IFileLogger _fileLogger;

        public HomeController(IFileLogger fileLogger)
        {
            _fileLogger = fileLogger;
        }

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