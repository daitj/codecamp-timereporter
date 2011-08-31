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
        public DbSet<ProjectActivity> ProjectActivities { get; set; }
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
            
            Activity activity = new Activity() {title = "Hämta kaffe"};
            context.Activities.Add(activity);
            ProjectActivity pActivity = new ProjectActivity() { activityID = activity.activityID, projectId = projects.projectID };

            foreach (var i in names)
            {
                var projectMember = new ProjectMember() { userName = i, projectID = projects.projectID };
                context.ProjectMembers.Add(projectMember);

                context.TimeRecords.Add(new TimeRecord() { userId = i, date = DateTime.UtcNow, minutes = 50, comment = "Testar", projectID = projects.projectID, activityID = activity.activityID });
            }

            context.SaveChanges();
        }
    }
}