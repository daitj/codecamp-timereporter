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
    public class ProjectActivityController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();

        //
        // GET: /ProjectActivity/

        public ViewResult Index()
        {
            var projectactivities = db.ProjectActivities.Include(p => p.Project);
            return View(projectactivities.ToList());
        }

        //
        // GET: /ProjectActivity/Details/5

        public ViewResult Details(int id)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            return View(projectactivity);
        }

        //
        // GET: /ProjectActivity/Create

        public ActionResult Create()
        {
            ViewBag.projectId = new SelectList(db.Projects, "projectID", "title");
            return View();
        } 

        //
        // POST: /ProjectActivity/Create

        [HttpPost]
        public ActionResult Create(ProjectActivity projectactivity)
        {
            if (ModelState.IsValid)
            {
                db.ProjectActivities.Add(projectactivity);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.projectId = new SelectList(db.Projects, "projectID", "title", projectactivity.projectId);
            return View(projectactivity);
        }
        
        //
        // GET: /ProjectActivity/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            ViewBag.projectId = new SelectList(db.Projects, "projectID", "title", projectactivity.projectId);
            return View(projectactivity);
        }

        //
        // POST: /ProjectActivity/Edit/5

        [HttpPost]
        public ActionResult Edit(ProjectActivity projectactivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectactivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectId = new SelectList(db.Projects, "projectID", "title", projectactivity.projectId);
            return View(projectactivity);
        }

        //
        // GET: /ProjectActivity/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            return View(projectactivity);
        }

        //
        // POST: /ProjectActivity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ProjectActivity projectactivity = db.ProjectActivities.Find(id);
            db.ProjectActivities.Remove(projectactivity);
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