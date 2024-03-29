﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReporting.Models;

namespace TimeReporting.Controllers
{
    public class ProjectController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();
        private Project currentProject = null;

        
        public ActionResult ProjectDetails(string input)
        {
            try
            {
                int id = Int32.Parse(input);
                currentProject = db.Projects.Find(id);
            }
            catch
            {
                return PartialView("ProjectDetails");
            }

            return PartialView("ProjectDetails", currentProject);
        }

        [HttpPost]
        public ActionResult ProjectDetails()
        {
            

            return PartialView("ProjectDetails");
        }
        

        //
        // GET: /Project/
        public ActionResult Index()
        {
            /*List<Project> myProjects = db.Projects.ToList();
            foreach (var i in myProjects)
            {
                if (!i.userNames.Contains(User.Identity.Name))
                {
                    myProjects.Remove(i);
                }
            }*/
            ViewBag.projectTitle = new SelectList(db.Projects, "projectID", "title");
            return View();
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        }
        

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Project/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5

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
        // GET: /Project/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5

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
