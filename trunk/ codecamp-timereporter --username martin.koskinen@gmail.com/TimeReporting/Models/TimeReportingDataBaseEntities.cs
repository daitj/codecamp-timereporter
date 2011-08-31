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
        public DbSet<TimeRecord> TimeRecords { get; set; }
    }

    public class TimeDataBaseInitializer : DropCreateDatabaseAlways<TimeReportingDataBaseEntities>
    {
        protected override void Seed(TimeReportingDataBaseEntities context)
        {
            List<string> names = new List<string>();
            names.Add("Oka");
            names.Add("Martin");


            var projects = new Project() {title = "Dricka kaffe", client = "Åbo Akademi", managerName = "Backa"};
            context.Projects.Add(projects);

            foreach (var i in names)
            {
                var projectMember = new ProjectMember() { userName = i, projectID = projects.projectID };
                context.ProjectMembers.Add(projectMember);
            }

            Activity activity = new Activity() {projectID = projects.projectID, title = "Koka kaffe"};
            context.Activities.Add(activity);
            context.TimeRecords.Add(new TimeRecord() { date = DateTime.UtcNow, minutes = 50, comment = "Testar", projectID = projects.projectID, activityID = activity.activityID });

            context.SaveChanges();
        }
    }
}