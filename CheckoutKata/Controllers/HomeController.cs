using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckoutKata.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.InitModule = "CheckoutKataApp"; // for ng-app
            ViewBag.Title = "Checkout Kata";
            return View();
        }
    }
}