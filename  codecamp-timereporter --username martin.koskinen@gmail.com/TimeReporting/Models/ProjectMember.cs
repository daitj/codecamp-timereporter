﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeReporting.Models
{
    public class ProjectMember
    {
        public int id { get; set; }
        public string userName { get; set; }
    }
}