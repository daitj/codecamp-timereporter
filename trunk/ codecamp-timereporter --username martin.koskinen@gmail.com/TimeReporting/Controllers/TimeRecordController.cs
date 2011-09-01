using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReporting.Models;


namespace TimeReporting.Controllers
{
    public class TimeRecordController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();
        //
        // GET: /TimeRecords/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexFrame()
        {
            List<Project> usersProjects = new List<Project>();
            foreach (var temp in db.Projects)
            {
                foreach (var innerTemp in temp.ProjectMembers)
                {
                    if (innerTemp.userName == User.Identity.Name)
                    {
                        usersProjects.Add(temp);
                    }
                }
            }



            ViewBag.projectID = new SelectList(usersProjects, "projectID", "title");
            return PartialView("IndexFrame");
        }

        public ActionResult getActivity(string pID)
        {
            try
            {
                int id = Int32.Parse(pID);
                List<Activity> projectActivity = new List<Activity>();
                foreach (var temp in db.Activities)
                {
                    if (id == temp.projectID)
                    {
                        projectActivity.Add(temp);
                    }
                }
                ViewBag.activityID = new SelectList(projectActivity, "activityID", "title");

            }
            catch
            {
                return PartialView("getActivity");
            }
            return PartialView("getActivity");
        }
        // POST: /TimeRecords/IndexFrame
        [HttpPost]
        public ActionResult IndexFrame(TimeRecord time)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                time.userId = userName;
                time.date = DateTime.Now;
                db.TimeRecords.Add(time);
                db.SaveChanges();
                ViewBag.success = true;
                return PartialView("IndexFrame", time);
            }
            return PartialView("IndexFrame",time);

        }
        //
        // GET: /TimeRecords/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TimeRecords/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        
        //
        // GET: /TimeRecords/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TimeRecords/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TimeRecords/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TimeRecords/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
