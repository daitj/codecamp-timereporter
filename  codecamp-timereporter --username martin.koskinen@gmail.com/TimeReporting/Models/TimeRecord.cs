using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class TimeRecord
    {
        public int ID { get; set; }
        public int projectID { get; set; }
        public int activityID { get; set; }
        public string userName { get; set; }
        public int minutes { get; set; }
        public DateTime date { get; set; }
        public virtual Project Project { get; set; }
    }
}
