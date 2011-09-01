using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReporting.Models;

namespace TimeReporting.Controllers
{ 
    public class ActivityController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();

        //
        // GET: /Activity/

        public ViewResult Index()
        {
            var activities = db.Activities.Include(a => a.Project);
            return View(activities.ToList());
        }

        //
        // GET: /Activity/Details/5

        public ViewResult Details(int id)
        {
            Activity activity = db.Activities.Find(id);
            return View(activity);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title");
            return View();
        } 

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("../ProjectManager/Index");  
            }

            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", activity.projectID);
            return View(activity);
        }
        
        //
        // GET: /Activity/Edit/5
 
        public ActionResult Edit(int id)
        {
            Activity activity = db.Activities.Find(id);
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", activity.projectID);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", activity.projectID);
            return View(activity);
        }

        //
        // GET: /Activity/Delete/5
 
        public ActionResult Delete(int id)
        {
            Activity activity = db.Activities.Find(id);
            return View(activity);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}