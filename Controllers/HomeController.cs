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
                ViewBag.kamers = kamers;
                ViewBag.msg = "Hello World";
                return View();

            }


        }
    }
}