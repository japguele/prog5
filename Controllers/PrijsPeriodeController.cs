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
    public class PrijsPeriodeController : Controller
    {
        private MyContext db = new MyContext();

        // GET: PrijsPeriode
        public ActionResult Index()
        {
            var prijsPeriode = db.PrijsPeriode.Include(p => p.prijs);
            return View(prijsPeriode.ToList());
        }

        // GET: PrijsPeriode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijsPeriode prijsPeriode = db.PrijsPeriode.Find(id);
            if (prijsPeriode == null)
            {
                return HttpNotFound();
            }
            return View(prijsPeriode);
        }

        // GET: PrijsPeriode/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Prijs, "id", "Naam");
            return View();
        }

        // POST: PrijsPeriode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrijsPeriodeId,id,BeginDatum,EindDatum")] PrijsPeriode prijsPeriode)
        {
            if (ModelState.IsValid)
            {
                db.PrijsPeriode.Add(prijsPeriode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Prijs, "id", "Naam", prijsPeriode.id);
            return View(prijsPeriode);
        }

        // GET: PrijsPeriode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijsPeriode prijsPeriode = db.PrijsPeriode.Find(id);
            if (prijsPeriode == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Prijs, "id", "Naam", prijsPeriode.id);
            return View(prijsPeriode);
        }

        // POST: PrijsPeriode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrijsPeriodeId,id,BeginDatum,EindDatum")] PrijsPeriode prijsPeriode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijsPeriode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Prijs, "id", "Naam", prijsPeriode.id);
            return View(prijsPeriode);
        }

        // GET: PrijsPeriode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijsPeriode prijsPeriode = db.PrijsPeriode.Find(id);
            if (prijsPeriode == null)
            {
                return HttpNotFound();
            }
            return View(prijsPeriode);
        }

        // POST: PrijsPeriode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrijsPeriode prijsPeriode = db.PrijsPeriode.Find(id);
            db.PrijsPeriode.Remove(prijsPeriode);
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
