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
            //DateTime start = date.Date.AddDays(-(int)date.DayOfWeek), // prev sunday 00:00
            // end = start.AddDays(7); // next sunday 00:00
            /*
            var qry = from record in data
                      where record.Date >= start // include start
                       && record.Date < end // exclude end
                      select record;
            var query = myObjects
                        .Where(ob => startOfWeek <= ob.DateField && ob.DateField < endOfWeek)
            */
            //using System.Data.Entity; must be including for (a=>a) to work 
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            //var today = new DateTime(today.Year, today.Month, today.Day);
            //var today = new DateTime(2017, 04, 03);
            //var last = new DateTime(2017, 07, 07);

            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events.Any(b => b.Start >= startOfWeek && b.End <= endOfWeek && b.IsActive == true))
                                .Select(a => a);
            return View(activities.ToList());
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