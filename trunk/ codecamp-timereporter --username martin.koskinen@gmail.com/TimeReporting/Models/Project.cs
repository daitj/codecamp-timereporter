using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class Project
    {
        public int id { get; private set; }
        public string title { get; set; }
        public string client { get; set; }
        public string managerName { get; set; }
        public List<string> userNames { get; set; }
        public List<Activity> projectActivities { get; set; }
    }
}