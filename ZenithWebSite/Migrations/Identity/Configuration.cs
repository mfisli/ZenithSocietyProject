namespace ZenithWebSite.Migrations.Identity
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        {
            setRoles(context);
            context.SaveChanges();
            setUsers(context);
            context.SaveChanges(); context.Activities.AddOrUpdate(a => a.ActivityId, getActivities());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.EventId, getEvents(context));
            context.SaveChanges();
        }
        private void setRoles(ZenithWebSite.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }
        }

        private void setUsers(ZenithWebSite.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
        }



        private Activity[] getActivities()
        {
            var activities = new List<Activity>
            {
                new Activity()
                {
                    Description = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Youth craft lessons",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Youth choir practice",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Lunch",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Pancake Breakfast",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Bingo Tournament",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "BBQ Lunch",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Garage Sale",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Intro to ASP.NET",
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                },
                new Activity()
                {
                    Description = "Dancing with Mani",
                    CreationDate = new DateTime(2017,1,1,3,00,00),
                }
            };
            return activities.ToArray();
        }
        private Event[] getEvents(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,1,8,30,0),
                    End = new DateTime(2017,2,1,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Senior's Golf Tournament").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,2,8,30,0),
                    End = new DateTime(2017,2,2,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Leadership General Assembly Meeting").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,3,17,30,0),
                    End = new DateTime(2017,2,3,19,15,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Youth Bowling Tournament").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,3,19,00,0),
                    End = new DateTime(2017,2,3,20,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Young ladies cooking lessons").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,4,8,30,0),
                    End = new DateTime(2017,2,4,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Youth craft lessons").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,4,10,30,0),
                    End = new DateTime(2017,2,4,12,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Youth choir practice").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = false
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,4,12,00,0),
                    End = new DateTime(2017,2,4,13,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,7,30,0),
                    End = new DateTime(2017,2,5,8,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Pancake Breakfast").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,8,30,0),
                    End = new DateTime(2017,2,5,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Swimming Lessons for the youth").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,8,30,0),
                    End = new DateTime(2017,2,5,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Swimming Exercise for parents").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = false
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,10,30,0),
                    End = new DateTime(2017,2,5,12,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Bingo Tournament").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,12,00,0),
                    End = new DateTime(2017,2,5,13,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="BBQ Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,5,13,00,0),
                    End = new DateTime(2017,2,5,18,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Garage Sale").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,6,12,00,0),
                    End = new DateTime(2017,2,6,13,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = false
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,6,8,30,0),
                    End = new DateTime(2017,2,6,9,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Pancake Breakfast").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,7,14,30,0),
                    End = new DateTime(2017,2,7,16,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Swimming Lessons for the youth").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,8,12,30,0),
                    End = new DateTime(2017,2,8,14,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Youth craft lessons").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,8,16,30,0),
                    End = new DateTime(2017,2,8,18,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Youth choir practice").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,9,12,00,0),
                    End = new DateTime(2017,2,9,13,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,10,8,30,0),
                    End = new DateTime(2017,2,10,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Pancake Breakfast").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,10,15,30,0),
                    End = new DateTime(2017,2,10,17,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Leadership General Assembly Meeting").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,11,12,00,0),
                    End = new DateTime(2017,2,11,1,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,11,17,00,0),
                    End = new DateTime(2017,2,13,12,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Bingo Tournament").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,12,12,00,0),
                    End = new DateTime(2017,2,12,14,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Young ladies cooking lessons").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,13,12,00,0),
                    End = new DateTime(2017,2,13,14,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="BBQ Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,14,12,00,0),
                    End = new DateTime(2017,2,14,13,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = false
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,14,12,00,0),
                    End = new DateTime(2017,2,14,13,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Swimming Lessons for the youth").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,15,8,30,0),
                    End = new DateTime(2017,2,15,9,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Pancake Breakfast").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,16,12,00,0),
                    End = new DateTime(2017,2,16,1,30,0),
                    CreatedBy = "a",


                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="BBQ Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,16,14,00,0),
                    End = new DateTime(2017,2,16,15,00,0),
                    CreatedBy = "a",


                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Swimming Exercise for parents").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,17,12,00,0),
                    End = new DateTime(2017,2,17,1,30,0),
                    CreatedBy = "a",


                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Lunch").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,17,8,30,0),
                    End = new DateTime(2017,2,17,10,30,0),
                    CreatedBy = "a",


                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Pancake Breakfast").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,1,30,8,30,0),
                    End = new DateTime(2017,1,30,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Intro to ASP.NET").ActivityId,
                    CreationDate = new DateTime(2017,1,1,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,3,8,30,0),
                    End = new DateTime(2017,2,3,10,30,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Intro to ASP.NET").ActivityId,
                    CreationDate = new DateTime(2017,1,2,12,00,00),
                    IsActive = true
                },
                new ZenithDataLib.Models.Event()
                {
                    Start = new DateTime(2017,2,3,11,00,0),
                    End = new DateTime(2017,2,3,12,00,0),
                    CreatedBy = "a",

                    ActivityId = context.Activities.FirstOrDefault(a => a.Description=="Dancing with Mani").ActivityId,
                    CreationDate = new DateTime(2017,1,2,12,00,00),
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
