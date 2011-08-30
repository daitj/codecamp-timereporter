using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeReporting.Models
{
    public class Activity
    {
        public int id { get; private set; }
        public string projectId { get; set; }
        public string title { get; set; }
    }
}