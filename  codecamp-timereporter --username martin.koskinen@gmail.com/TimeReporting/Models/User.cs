using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class User 
    {
        public int id { get; private set; }
        public string name { get; set; }
        public string email { get; set; }
        public long lastLogOn { get; set; }
        public string ip { get; set; }

    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}