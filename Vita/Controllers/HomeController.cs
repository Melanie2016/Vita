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
        private VitaEntities myDbContext = new VitaEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario, Entidad entidad )
        {

            if (usuario.apellido != null && usuario.nombre != null) //buscar una forma mejor de validar
            {
                //no trae celular, localidadId,categoria, muestra la contrasenia en plano
                usuarioServicio.CrearUsuario(usuario);
                return RedirectToAction("PerfilUsuario", "Home");
            }
            else
            {
                //no trae celular, telefono, categoriaID, localidadId, muestra la contrasenia en plano
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
    }
}