﻿using System;
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

        [Display(Name = "Time(HH:MM)")]
        public int minutes { get; set; }
        
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Display(Name = "Comment")]
        public string comment { get; set; }

        public virtual Activity Activity { get; set; }

    }
}
