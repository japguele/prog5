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
    public class BookingController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Booking
        public ActionResult Index()
        {
            var booking = db.Booking.Include(b => b.Gast).Include(b => b.Kamer);
            return View(booking.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.GastNr = new SelectList(db.Gast, "GastNr", "Naam");
            ViewBag.KamerNr = new SelectList(db.Kamers, "KamerNr", "Naam");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booknr,KamerNr,GastNr,StartDate,EndDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Booking.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GastNr = new SelectList(db.Gast, "GastNr", "Naam", booking.GastNr);
            ViewBag.KamerNr = new SelectList(db.Kamers, "KamerNr", "Naam", booking.KamerNr);
            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.GastNr = new SelectList(db.Gast, "GastNr", "Naam", booking.GastNr);
            ViewBag.KamerNr = new SelectList(db.Kamers, "KamerNr", "Naam", booking.KamerNr);
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booknr,KamerNr,GastNr,StartDate,EndDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GastNr = new SelectList(db.Gast, "GastNr", "Naam", booking.GastNr);
            ViewBag.KamerNr = new SelectList(db.Kamers, "KamerNr", "Naam", booking.KamerNr);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Booking.Find(id);
            db.Booking.Remove(booking);
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
