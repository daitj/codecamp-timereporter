using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReporting.Models;
using System.Web.Security;

namespace TimeReporting.Controllers
{ 
    [Authorize(Roles="ProjectManager")]
    public class ProjectManagerController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();
        Project currentProject = null;

        //
        // GET: /ProjectManager/

        public ActionResult AddMember(string member)
        {
             try
            {
                if(ModelState.IsValid){

                    db.ProjectMembers.Add(new ProjectMember() {userName = member, projectID=currentProject.projectID });
                    db.SaveChanges();
                }                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ViewResult Index()
        {
            return View(db.Projects.ToList());
        }

        //
        // GET: /ProjectManager/Details/5

        public ViewResult Details(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // GET: /ProjectManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ProjectManager/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(project);
        }
        
        //
        // GET: /ProjectManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            IEnumerable<string> temp = from member in db.ProjectMembers
                                               where member.Project.projectID == id
                                               select member.userName;

            List<string> temp2 = temp.ToList();
            List<string> allUsernames = new List<string>();

            foreach(MembershipUser i in allUsers){
                allUsernames.Add(i.UserName);
            }

            foreach (var user in temp2)
            {   
                if (allUsernames.Contains(user)) allUsernames.Remove(user);
            }

            ViewBag.projectnonMembers = new SelectList((IEnumerable<string>)allUsernames);
            ViewBag.projectMembers = new SelectList(temp);
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // POST: /ProjectManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /ProjectManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // POST: /ProjectManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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