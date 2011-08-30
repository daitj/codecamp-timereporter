using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeReporting.Models
{
    public class Project
    {
        public int id { get; private set; }
        public string title { get; set; }
        public string client { get; set; }
        public long managerId { get; set; }
        public int userId { get; set; }
        public List<Activity> projectActivities { get; set; }
    }
}