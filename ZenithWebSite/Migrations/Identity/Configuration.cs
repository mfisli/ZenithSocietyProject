namespace ZenithWebSite.Migrations.Identity
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        {
            context.Activities.AddOrUpdate(a => a.ActivityId, getActivities());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.EventId, getEvents(context));
            context.SaveChanges();
        }

        private Activity[] getActivities()
        {
            var activities = new List<Activity>
            {
                new Activity()
                {
                    Description = "Intro to ASP.NET",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                }
            };
            return activities.ToArray(); 
        }
        private Event[] getEvents(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event()
                {
                    Start = new DateTime(2017,1,30,8,30,0),
                    End = new DateTime(2017,1,30,10,30,0),
                    CreatedBy = "UserName1",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Intro to ASP.NET").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                }
            };
            return events.ToArray();
        }
        /*    
         *    // new DateTime( year, month, day, hour, min, sec) 
   
        // events 
        public int EventId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string CreatedBy { get; set; }

    public Activity Activity { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }

        // activities 
    public int ActivityId { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }

    public List<Event> Events { get; set; }
         */
    }
}
