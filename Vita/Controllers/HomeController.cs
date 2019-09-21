using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vita.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            ViewBag.Message = "Registrese! Maldita sea";

            return View();
        }

        public ActionResult Actividades()
        {
            ViewBag.Message = "Ranking de los más populares";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}