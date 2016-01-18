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
                return RedirectToAction("Index");
            }

            return View(gast);
        }
        public ActionResult Period(int? id)
        {
            

            if (Request.Form["Book.StartDate"] != null)
            {
                Response.Cookies.Add(new HttpCookie("StartDate", Request.Form["Book.StartDate"]));

                Response.Cookies.Add(new HttpCookie("EndDate", Request.Form["Book.EndDate"]));
                Response.BufferOutput = true;
                return RedirectToAction("Register/" + id); //Response.Redirect("http://localhost:49580/Book/Register/" + id);
                
                
            }
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
            
            Response.Cookies["Roomid"].Value = id.ToString();
            
           
            k.Booking = db.Booking.Where(i => i.KamerNr == id).ToList();
            
           
            return View(k);
        }
    }
}