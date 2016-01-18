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
    public class BookController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Book
        public ActionResult Index()
        {
            return View(db.Kamers.ToList());
        
        }

        public ActionResult Cancel(int? id)
        {
            Booking gast = db.Booking.Find(id);
            db.Booking.Remove(gast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Register(int? id)
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(int? id,[Bind(Include = "GastNr,Naam,TussenVoegsel,Achternaam,Geboortedatum,Vrouw,Woonplaats,Email,Postcode,Addres")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.Gast.Add(gast);
                db.SaveChanges();
                Booking book = new Booking();
                book.GastNr = gast.GastNr;
                book.KamerNr = id.Value; //Convert.ToInt32(Request.Url.Fragment.Last().ToString());
                book.StartDate = DateTime.Parse(Request.Cookies["StartDate"].Value.ToString());
                book.EndDate = DateTime.Parse(Request.Cookies["EndDate"].Value.ToString());


                db.Booking.Add(book);
                db.SaveChanges();
                return RedirectToAction("Balance/" + book.Booknr);
            }

            return View(gast);
        }

        public ActionResult Balance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking book = db.Booking.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
             ViewBag.Prijs = book.Kamer.MinimalePrijs;
               int prijs = 0;
            if (book.Kamer.PeriodeId.HasValue)
            {
             
                DateTime day = book.StartDate;
                TimeSpan d = book.EndDate - book.StartDate;
                for (int x = 0; x < d.Days; x++)
                {
                    day.AddDays(1);

                    if (day >= book.Kamer.PrijsPeriode.BeginDatum && day <= book.Kamer.PrijsPeriode.EindDatum)
                    {
                        prijs = prijs +  book.Kamer.PrijsPeriode.prijs.Kosten;
                    }else{
                        prijs = prijs +  book.Kamer.MinimalePrijs;
                    }

                }



            }
            else
            {
                TimeSpan d = book.EndDate - book.StartDate;
                prijs = d.Days * book.Kamer.MinimalePrijs;
            }
            ViewBag.Prijs = prijs;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Period(int? id,[Bind(Include = "Startdate,EndDate")] BookKamerModel m)
        {
            Kamer k = db.Kamers.Find(id);

            if (k == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Booking> bookings = db.Booking.Where(i => i.KamerNr == k.KamerNr).ToList();
            bool ocupied = false;
            DateTime startdate = DateTime.Parse(Request.Form["Book.StartDate"]);
            
            DateTime enddate = DateTime.Parse(Request.Form["Book.EndDate"]);
            foreach (Booking b in bookings)
            {
                if ((b.StartDate < startdate && startdate < b.EndDate) || (b.StartDate < enddate && enddate < b.EndDate))
                {
                    ocupied = true;
                }
            }
            if (startdate < enddate)
            {
                if (!ocupied)
                {
                    Response.Cookies.Add(new HttpCookie("StartDate", Request.Form["Book.Startdate"]));

                    Response.Cookies.Add(new HttpCookie("EndDate", Request.Form["Book.EndDate"]));
                    Response.BufferOutput = true;
                    return RedirectToAction("Register/" + id); //Response.Redirect("http://localhost:49580/Book/Register/" + id);
                }
                else
                {
                    ViewBag.Error = "Allready ocupied";
                }

            }
            else
            {
                ViewBag.Error = "EndDate is not afther startDate";
            }
            BookKamerModel ka = new BookKamerModel();
            ka.Kamer = k;



            ka.Booking = db.Booking.Where(i => i.KamerNr == id).ToList();
            
            return View(ka);

            

        }
        public ActionResult Period(int? id)
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
            BookKamerModel k = new BookKamerModel();
            k.Kamer = kamer;
            
           
           
            k.Booking = db.Booking.Where(i => i.KamerNr == id).ToList();
            
           
            return View(k);
        }
    }
}