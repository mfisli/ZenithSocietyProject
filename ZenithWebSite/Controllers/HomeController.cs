using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithWebSite.Models;
using System.Data.Entity;
//using System.Net;


namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        // default connection to database
        // ability to query / linq 
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //using System.Data.Entity; must be including for (a=>a) to work 
            var activities = db.Activities.Include(a => a.Events);
            return View(activities.ToList());
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}