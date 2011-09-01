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
    public class ChatController : Controller
    {
        private TimeReportingDataBaseEntities db = new TimeReportingDataBaseEntities();    
        //
        // GET: /Chat/
        [Authorize]
        public ActionResult chatUpdate()
        {
            return PartialView("chatUpdate", db.Chats.ToList());
        }

        // GET: /Chat/
        [Authorize]
        public ViewResult Index()
        {
            return View(db.Chats.ToList());
        }

        //
        // GET: /Chat/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            Chat chat = db.Chats.Find(id);
            return View(chat);
        }

        //
        // GET: /Chat/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Chat/Create
        
        [HttpPost][Authorize]
        public ActionResult Create(Chat chat)
        {
            if (ModelState.IsValid)
            {
                chat.timeStamp = DateTime.Now.ToUniversalTime();
                chat.userName = User.Identity.Name;
                db.Chats.Add(chat);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(chat);
        }
        
        //
        // GET: /Chat/Edit/5
 
        

        //
        // POST: /Chat/Edit/5

        

        //
        // GET: /Chat/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Chat chat = db.Chats.Find(id);
            if (chat.userName == User.Identity.Name)
            {
                return View(chat);
            }
            else
            {
                ViewBag.error = "This is huge error";
                return View();
            }
            
        }

        //
        // POST: /Chat/Delete/5

        [HttpPost, ActionName("Delete"), Authorize]
        public ActionResult DeleteConfirmed(int id)
        {            
            Chat chat = db.Chats.Find(id);
            if (chat.userName == User.Identity.Name) {
                db.Chats.Remove(chat);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}