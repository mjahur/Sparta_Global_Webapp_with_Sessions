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
    public class UniversesController : Controller
    {
        private SocialModel db = new SocialModel();

        // GET: Universes
        public ActionResult Index()
        {
            return View(db.Universes.ToList());
        }

        // GET: Universes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universe universe = db.Universes.Find(id);
            if (universe == null)
            {
                return HttpNotFound();
            }
            return View(universe);
        }

        // GET: Universes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "universeID,origin,universeName")] Universe universe)
        {
            if (ModelState.IsValid)
            {
                db.Universes.Add(universe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universe);
        }

        // GET: Universes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universe universe = db.Universes.Find(id);
            if (universe == null)
            {
                return HttpNotFound();
            }
            return View(universe);
        }

        // POST: Universes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "universeID,origin,universeName")] Universe universe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universe);
        }

        // GET: Universes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universe universe = db.Universes.Find(id);
            if (universe == null)
            {
                return HttpNotFound();
            }
            return View(universe);
        }

        // POST: Universes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universe universe = db.Universes.Find(id);
            db.Universes.Remove(universe);
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
