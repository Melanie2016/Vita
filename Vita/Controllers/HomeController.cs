using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult Registro()
        {
            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Localidad> localidades = localidadServicio.GetAllLocalidades();
            ViewBag.ListaLocalidades = new MultiSelectList(localidades, "id", "descripcion");

            List<Categoria> rubros = categoriaServicio.GetAllCategorias();
            ViewBag.ListaRubro = new MultiSelectList(rubros, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");


            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
           
            usuarioServicio.CrearUsuario(usuario);
            if (usuario.RolId == 1)
            {
                return RedirectToAction("PerfilUsuario", "Home");
            }
            else
            {
                return RedirectToAction("PerfilEntidad", "Home");
            }


        }
        [HttpGet]
        public ActionResult PerfilUsuario(Usuario usuario)
        {
            
            return View(usuario);
        }

        public ActionResult PerfilEntidad(Usuario usuario)
        {
            return View(usuario);
        }
        public ActionResult Muro()
        {
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


        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult FichaEvento()
        {
            return View();
        }
    }
}