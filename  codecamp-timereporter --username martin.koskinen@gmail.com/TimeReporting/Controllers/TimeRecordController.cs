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
    public class TimeRecordController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();

        //
        // GET: /TimeRecord/

        public ViewResult Index()
        {
            var timerecords = db.TimeRecords.Include(t => t.Project);
            return View(timerecords.ToList());
        }

        // POST: /TimeRecords
        [HttpPost]
        public ActionResult Index(TimeRecord time)
        {
            if (ModelState.IsValid)
            {
                db.TimeRecords.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(time);
        }

        //
        // GET: /TimeRecord/Details/5

        public ViewResult Details(int id)
        {
            TimeRecord timerecord = db.TimeRecords.Find(id);
            return View(timerecord);
        }

        //
        // GET: /TimeRecord/Create

        public ActionResult Create()
        {
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title");
            return View();
        } 

        //
        // POST: /TimeRecord/Create

        [HttpPost]
        public ActionResult Create(TimeRecord timerecord)
        {
            if (ModelState.IsValid)
            {
                db.TimeRecords.Add(timerecord);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", timerecord.projectID);
            return View(timerecord);
        }
        
        //
        // GET: /TimeRecord/Edit/5
 
        public ActionResult Edit(int id)
        {
            TimeRecord timerecord = db.TimeRecords.Find(id);
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", timerecord.projectID);
            return View(timerecord);
        }

        //
        // POST: /TimeRecord/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeRecord timerecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timerecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectID = new SelectList(db.Projects, "projectID", "title", timerecord.projectID);
            return View(timerecord);
        }

        //
        // GET: /TimeRecord/Delete/5
 
        public ActionResult Delete(int id)
        {
            TimeRecord timerecord = db.TimeRecords.Find(id);
            return View(timerecord);
        }

        //
        // POST: /TimeRecord/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TimeRecord timerecord = db.TimeRecords.Find(id);
            db.TimeRecords.Remove(timerecord);
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