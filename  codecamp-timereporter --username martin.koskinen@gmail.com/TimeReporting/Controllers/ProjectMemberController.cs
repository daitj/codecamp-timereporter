using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReporting.Models;

namespace TimeReporting.Controllers
{
    public class ProjectMemberController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();
        //
        // GET: /ProjectMember/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ProjectMember/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        

        //
        // POST: /ProjectMember/Create

        //[HttpPost]
        public ActionResult RemoveMember(string projectID, string userName)
        {
            try
            {
                int id = Int32.Parse(projectID);
                if (ModelState.IsValid)
                {
                    IEnumerable<ProjectMember> projectmember = from member in db.ProjectMembers
                                                   where member.projectID == id && member.userName == userName
                                                   select member;

                    foreach (var i in projectmember) {
                        db.ProjectMembers.Remove(i);
                    }
                    
                    db.SaveChanges();
                }

                return RedirectToAction("../ProjectManager/Edit", new { id = projectID });
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /ProjectMember/Create
        //[HttpPost]
        public ActionResult Create(string projectID, string userName)
        {
            try
            {
                int id = Int32.Parse(projectID);
                if(ModelState.IsValid){

                    db.ProjectMembers.Add(new ProjectMember() {userName = userName, projectID = id });
                    db.SaveChanges();
                }                

                return RedirectToAction ("../ProjectManager/Edit", new {id = projectID});
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /ProjectMember/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ProjectMember/Edit/5

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
        // GET: /ProjectMember/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ProjectMember/Delete/5

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
