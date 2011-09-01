using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeReporting.Models
{
    public class Chat
    {
        public int chatId { get; set; }
        public string userName { get; set; }
        public string chatMsg { get; set; }
        public DateTime timeStamp { get; set; }
    }
}