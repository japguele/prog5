using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prog5.Models;

namespace prog5.Controllers
{
    public class KamersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Kamers
        public ActionResult Index()
        {
            return View(db.Kamers.ToList());
        }

        // GET: Kamers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kamer kamer = db.Kamers.Find(id);
            if (kamer == null)
            {
                return HttpNotFound();
            }
            return View(kamer);
        }

        // GET: Kamers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kamers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KamerNr,Naam,Capaciteit,Prijs")] Kamer kamer)
        {
            if (ModelState.IsValid)
            {
                db.Kamers.Add(kamer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kamer);
        }

        // GET: Kamers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kamer kamer = db.Kamers.Find(id);
            if (kamer == null)
            {
                return HttpNotFound();
            }
            return View(kamer);
        }

        // POST: Kamers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KamerNr,Naam,Capaciteit,Prijs")] Kamer kamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kamer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kamer);
        }

        // GET: Kamers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kamer kamer = db.Kamers.Find(id);
            if (kamer == null)
            {
                return HttpNotFound();
            }
            return View(kamer);
        }

        // POST: Kamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kamer kamer = db.Kamers.Find(id);
            db.Kamers.Remove(kamer);
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
