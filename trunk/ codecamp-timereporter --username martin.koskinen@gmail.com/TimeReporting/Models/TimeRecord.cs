using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class TimeRecord
    {
        public int ID { get; set; }

        [Display(Name = "Project")]
        public int projectID { get; set; }

        [Display(Name = "Activity")]
        public int activityID { get; set; }

        public string userId { get; set; }

        [Display(Name = "Hour")]
        public int minutes { get; set; }

        public DateTime date { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string comment { get; set; }

        public virtual Activity Activity { get; set; }

    }
}
