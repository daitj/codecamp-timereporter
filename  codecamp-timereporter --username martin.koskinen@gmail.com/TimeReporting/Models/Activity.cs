using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class Activity
    {
        public int id { get; private set; }
        public string projectId { get; set; }
        public string title { get; set; }
    }
    public class ActivityDBContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
    }
}