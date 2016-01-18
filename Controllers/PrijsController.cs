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
    public class PrijsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Prijs
        public ActionResult Index()
        {
            return View(db.Prijs.ToList());
        }

        // GET: Prijs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijs prijs = db.Prijs.Find(id);
            if (prijs == null)
            {
                return HttpNotFound();
            }
            return View(prijs);
        }

        // GET: Prijs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prijs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Naam,Kosten")] Prijs prijs)
        {
            if (ModelState.IsValid)
            {
                db.Prijs.Add(prijs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prijs);
        }

        // GET: Prijs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijs prijs = db.Prijs.Find(id);
            if (prijs == null)
            {
                return HttpNotFound();
            }
            return View(prijs);
        }

        // POST: Prijs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Naam,Kosten")] Prijs prijs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijs);
        }

        // GET: Prijs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijs prijs = db.Prijs.Find(id);
            if (prijs == null)
            {
                return HttpNotFound();
            }
            return View(prijs);
        }

        // POST: Prijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Prijs prijs = db.Prijs.Find(id);
            db.Prijs.Remove(prijs);
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
