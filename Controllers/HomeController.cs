using prog5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prog5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new MyContext())
            {
                var kamers = context.Kamers.ToList();
                var prijs = context.Prijs.ToList();
                ViewBag.kamers = kamers;
                ViewBag.prijs = prijs;
                return View();

            }


        }
    }
}