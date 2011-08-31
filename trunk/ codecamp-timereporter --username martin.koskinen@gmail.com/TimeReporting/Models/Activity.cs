using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class Activity
    {   
        public int activityID { get; private set; }
        public int projectId { get; set; }
        public string title { get; set; }
        public virtual Project Project { get; set; }
    }
}