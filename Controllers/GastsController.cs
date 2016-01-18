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
    public class GastsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Gasts
        public ActionResult Index()
        {
            return View(db.Gast.ToList());
        }

        // GET: Gasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.Gast.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // GET: Gasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GastNr,Naam,TussenVoegsel,Achternaam,Geboortedatum,Vrouw,Woonplaats,Email,Postcode,Addres")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.Gast.Add(gast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gast);
        }

        // GET: Gasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.Gast.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // POST: Gasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GastNr,Naam,TussenVoegsel,Achternaam,Geboortedatum,Vrouw,Woonplaats,Email,Postcode,Addres")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gast);
        }

        // GET: Gasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.Gast.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // POST: Gasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gast gast = db.Gast.Find(id);
            db.Gast.Remove(gast);
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
