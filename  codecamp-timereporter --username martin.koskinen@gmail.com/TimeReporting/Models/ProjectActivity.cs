using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class ProjectActivity
    {
        public int projectId { get; set; }
        public string activity { get; set; }
    }
}