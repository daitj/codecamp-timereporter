using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class ProjectActivity
    {
        public int ID { get; set; }
        public int projectId { get; set; }
        public int activityID { get; set; }
        public virtual Project Project { get; set; }
        public virtual Activity Activity { get; set; }
    }
}