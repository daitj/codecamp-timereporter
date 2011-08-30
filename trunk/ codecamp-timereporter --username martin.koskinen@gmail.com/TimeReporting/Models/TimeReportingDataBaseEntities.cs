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
        public DbSet<ProjectMember> ProjectMembers { get; set; }
    }

    public class TimeDataBaseInitializer : DropCreateDatabaseAlways<TimeReportingDataBaseEntities>
    {
        protected override void Seed(TimeReportingDataBaseEntities context)
        {
            List<string> names = new List<string>();
            names.Add("Oka");
            names.Add("Martin");
            foreach (var i in names)
            {
                var projectMember = new ProjectMember() {userName = i};
                context.ProjectMembers.Add(projectMember);
            }

            var projects = new Project() { title = "Dricka kaffe", id = 1};
            context.Projects.Add(projects);
            context.SaveChanges();
        }
    }
}