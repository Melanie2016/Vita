using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vita.Controllers
{
    public class ColaboracionController: Controller
    {
        /*Las colaboraciones en las que el usuario entidad creo*/
        public ActionResult ColaboracionesEntidad()
        {
            return View();
        }
        /*Las colaboraciones en las que el usuario participa*/
        public ActionResult ColaboracionesUsuario()
        {
            return View();
        }
    }
}