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
        // Data base connection 
        private ApplicationDbContext db = new ApplicationDbContext();

        // TODO order by date time before sending to view 
        // Activity has a list of events
        // public List<Event> Events { get; set; }
        public ActionResult Index()
        {
            // used to limit the range of events in current week
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            // Wrong logic
            // Valid: in this week (range) and IsActive 
            // ANY might be the wrong thing to use 
            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events
                                             .Any(e => e.Start >= startOfWeek && 
                                                  e.End <= endOfWeek &&
                                                  e.IsActive == true))
                                .Select(a => a).ToList();

            var WeekInfo = new List<DayInfo>();

            foreach(var a in activities)
            {
                foreach(var e in a.Events)
                {
                    var valid =  e.Start >= startOfWeek && e.End <= endOfWeek && e.IsActive == true;
                    if (!valid)
                        continue;
                    var day = e.Start.Date;
                    var dayInfo = WeekInfo.FirstOrDefault(d => d.Day == day);

                    if (dayInfo == null)
                    {
                        dayInfo = new DayInfo { Day = day, Events = new List<EventInfo>() };

                        WeekInfo.Add(dayInfo);
                    }
                    dayInfo.Events.Add(new EventInfo { Start = e.Start, End = e.End, Description = a.Description });
                }
            }
            WeekInfo = WeekInfo.OrderBy(w => w.Day).ToList();

            foreach( var day in WeekInfo)
            {
                day.Events = day.Events.OrderBy( e => e.Start).ToList();
            }


            // order by datetime 
            //activities = activities.OrderBy(e => e.Events.Start).ToList();

            return View(WeekInfo); // view is expecting a list of activities 
        }

        public class DayInfo
        {
            public DateTime Day { get; set; }
            public List<EventInfo> Events { get; set; }
        }

        public class EventInfo
        {
            
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public String Description { get; set; }
        }


        public ActionResult About()
        {
            ViewBag.Message = "The Zenith Society is a place to live and grow - together.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Say hi to Zenith.";

            return View();
        }
    }
}


//var today = new DateTime(today.Year, today.Month, today.Day);
//var today = new DateTime(2017, 04, 03);
//var last = new DateTime(2017, 07, 07);

//var activities = db.Activities.Include(a => a.Events)
//                           .Where(a => a.Events
//                                        .Any(e => e.Start >= startOfWeek &&
//                                             e.End <= endOfWeek &&
//                                             e.IsActive == true))
//                           .Select(a => a);

//var activities = db.Activities.Include(a => a.Events)
//                           .Where(a => a.Events
//                                        .Any(e => e.Start >= startOfWeek &&
//                                             e.End <= endOfWeek &&
//                                             e.IsActive == true))
//                           .Select(a => a).ToList();

//var temp = activities
//    .SelectMany(a => a.Events)
//    .Where(e => e.Start >= startOfWeek &&
//                e.End <= endOfWeek &&
//                e.IsActive == true)
//    .Select(e => new { Day = e.Start.Date, StartTime = e.Start, SndTime = e.End, Description = e.Activity.Description });

//var temp2 = temp.GroupBy(eventInfo => eventInfo.Day).ToDictionary(a => a.Key, a => a.ToList());