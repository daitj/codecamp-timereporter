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

        public ViewResult Index()
        {
            return View(db.Chats.ToList());
        }

        //
        // GET: /Chat/Details/5

        public ViewResult Details(int id)
        {
            Chat chat = db.Chats.Find(id);
            return View(chat);
        }

        //
        // GET: /Chat/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Chat/Create

        [HttpPost]
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
 
        public ActionResult Delete(int id)
        {
            Chat chat = db.Chats.Find(id);
            return View(chat);
        }

        //
        // POST: /Chat/Delete/5

        [HttpPost, ActionName("Delete")]
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