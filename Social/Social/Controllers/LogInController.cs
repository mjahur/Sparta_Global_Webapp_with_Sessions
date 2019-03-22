using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Social;

namespace Social.Controllers
{
    public class LogInController : Controller
    {
        private SocialModel db = new SocialModel();

        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }
        //Post: LogIn
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            User us = db.Users.FirstOrDefault(u => u.username.Equals(user.username) && u.password.Equals(user.password));

            Session["userID"] = user.userID;
            Session["username"] = user.username;
            Session["Description"] = user.Description;
            Session["Universe"] = user.Universe;
            Session["Group"] = user.Group;
            if (us == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Details", "LogIn", new { @id = us.userID });
            }
            
        }

        // GET: LogIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: LogIn/Create
        public ActionResult Create()
        {
            ViewBag.description_descriptionID = new SelectList(db.Descriptions, "descriptionID", "background");
            ViewBag.group_groupID = new SelectList(db.Groups, "groupID", "groupName");
            ViewBag.universe_universeID = new SelectList(db.Universes, "universeID", "origin");
            return View();
        }

        // POST: LogIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,password,username,description_descriptionID,group_groupID,universe_universeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.description_descriptionID = new SelectList(db.Descriptions, "descriptionID", "background", user.description_descriptionID);
            ViewBag.group_groupID = new SelectList(db.Groups, "groupID", "groupName", user.group_groupID);
            ViewBag.universe_universeID = new SelectList(db.Universes, "universeID", "origin", user.universe_universeID);
            return View(user);
        }

        // GET: LogIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.description_descriptionID = new SelectList(db.Descriptions, "descriptionID", "background", user.description_descriptionID);
            ViewBag.group_groupID = new SelectList(db.Groups, "groupID", "groupName", user.group_groupID);
            ViewBag.universe_universeID = new SelectList(db.Universes, "universeID", "origin", user.universe_universeID);
            return View(user);
        }

        // POST: LogIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,password,username,description_descriptionID,group_groupID,universe_universeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.description_descriptionID = new SelectList(db.Descriptions, "descriptionID", "background", user.description_descriptionID);
            ViewBag.group_groupID = new SelectList(db.Groups, "groupID", "groupName", user.group_groupID);
            ViewBag.universe_universeID = new SelectList(db.Universes, "universeID", "origin", user.universe_universeID);
            return View(user);
        }

        // GET: LogIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: LogIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
