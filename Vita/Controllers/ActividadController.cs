using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vita.Controllers
{
    public class ActividadController: Controller
    {
        public ActionResult Actividades()
        {
            ViewBag.Message = "Ranking de los más populares";

            return View();
        }
        public ActionResult CrearActividad()
        {
            return View();
        }
        public ActionResult ModificarActividad()
        {
            return View();
        }
        public ActionResult FichaActividad()
        {
            return View();
        }
        public ActionResult ListaActividades()
        {
            return View();
        }



    }
}