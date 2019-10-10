using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Vita.Servicios;

namespace Vita.Controllers
{
    public class HomeController : Controller
    {
     
        private VitaEntities myDbContext = new VitaEntities();
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Sugerencias()
        {
            return View();
        }
        public ActionResult Calendario()
        {
            return View();
        }
       
        public ActionResult Buscador()
        {
            return View();
        }   
    }
}