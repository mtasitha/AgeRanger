using AgeRanger.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeRanger.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AgeRangerDbContext db = new AgeRangerDbContext();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
