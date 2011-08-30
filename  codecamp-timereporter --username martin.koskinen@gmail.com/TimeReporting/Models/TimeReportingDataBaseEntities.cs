using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class TimeReportingDataBaseEntities : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

    public class TimeDataBaseInitializer : DropCreateDatabaseIfModelChanges<TimeReportingDataBaseEntities>
    {
        protected override void Seed(TimeReportingDataBaseEntities context)
        {
            List<string> names = new List<string>();
            names.Add("Oka");
            names.Add("Martin");
            var projects = new Project() { title = "Dricka kaffe", userNames = names };
            context.Projects.Add(projects);
            context.SaveChanges();
        }
    }
}