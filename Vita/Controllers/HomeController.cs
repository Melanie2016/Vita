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
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private VitaEntities myDbContext = new VitaEntities();
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Sugerencias()
        {
            return View();
        }
        public ActionResult ModificarActividad()
        {
            return View();
        }
        public ActionResult ModificarEvento()
        {
            return View();
        }
        public ActionResult Actividades()
        {
            ViewBag.Message = "Ranking de los más populares";

            return View();
        }


      
        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult FichaEvento()
        {
            return View();
        }

        public ActionResult FichaActividad()
        {
            return View();
        }

        public ActionResult Calendario()
        {
            return View();
        }

        public ActionResult ListaActividades()
        {
            return View();
        }


        public ActionResult ListaEventos()
        {
            return View();
        }
        public ActionResult Buscador()
        {
            return View();
        }









        public ActionResult ChatSimple()
        {
            return View();
        }
        public ActionResult ChatGrupal()
        {
            return View();
        }
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
        public ActionResult CrearActividad()
        {
            return View();
        }
        public ActionResult CrearEvento()
        {
            return View();
        }
    }
}