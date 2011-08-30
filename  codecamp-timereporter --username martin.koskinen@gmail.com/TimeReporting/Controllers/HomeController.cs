﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeReporting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Group G Time controller!";

            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
    }
}
