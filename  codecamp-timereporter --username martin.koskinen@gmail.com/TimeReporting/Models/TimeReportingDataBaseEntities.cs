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
        public DbSet<Chat> Chats { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeRecord>()
                .HasRequired(e => e.Activity)
                .WithMany()
                .HasForeignKey(e => e.activityID)
                .WillCascadeOnDelete(false);
        }
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
            
            Activity activity = new Activity() {projectID = projects.projectID, title = "Hämta kaffe"};
                       

            foreach (var i in names)
            {
                var projectMember = new ProjectMember() { userName = i, projectID = projects.projectID };
                context.ProjectMembers.Add(projectMember);

                context.TimeRecords.Add(new TimeRecord() { userId = i, date = DateTime.UtcNow, minutes = 50, comment = "Testar", projectID = projects.projectID, activityID = activity.activityID });
                context.Activities.Add(activity);
            }

            context.SaveChanges();
        }
    }
}