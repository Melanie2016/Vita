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
        private EntidadServicio entidadServicio = new EntidadServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private VitaEntities myDbContext = new VitaEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
          
            /*List<Categoria> rubros = categoriaServicio.GetAllCategorias();
            ViewBag.ListaRubro = new MultiSelectList(rubros, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");
            */

            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario, Entidad entidad )
        {

            if (usuario.apellido != null && usuario.nombre != null) //buscar una forma mejor de validar
            {
                //no trae celular, localidadId, muestra la contrasenia en plano
                
                usuarioServicio.CrearUsuario(usuario);
                return RedirectToAction("PerfilUsuario", "Home");
            }
            else
            {
                //no trae localidadId, muestra la contrasenia en plano
                
                entidadServicio.CrearEmpresa(entidad);
                return RedirectToAction("PerfilEntidad", "Home");

            }
        
           
        }
        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            
            return View();
        }

        public ActionResult PerfilEntidad()
        {
            return View();
        }
        public ActionResult Sugerencias()
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

        public ActionResult Calendario()
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
    }
}