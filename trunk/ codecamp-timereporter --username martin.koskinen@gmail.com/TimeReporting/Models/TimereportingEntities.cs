using System.Data.Entity;
namespace TimeReporting.Models
{
    public class TimereportingEntities : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Activity> Activity { get; set; }
    }
}
