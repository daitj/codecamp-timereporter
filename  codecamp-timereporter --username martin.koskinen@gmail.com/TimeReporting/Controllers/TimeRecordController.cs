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
        // POST: /TimeRecords/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
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
