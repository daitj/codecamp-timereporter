using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class Project
    {
        public int projectID { get; set; }
        public string title { get; set; }
        public string client { get; set; }
        public string managerName { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<ProjectActivity> ProjectActivitys { get; set; }
        public virtual ICollection<TimeRecord> TimeRecords { get; set; }
    }
}