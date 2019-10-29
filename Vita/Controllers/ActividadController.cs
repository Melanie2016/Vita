using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vita.Servicios;

namespace Vita.Controllers
{
    public class ActividadController : Controller
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private ActividadServicio actividadServicio = new ActividadServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private VitaEntities myDbContext = new VitaEntities();


        [HttpGet]
        public ActionResult CrearActividad()
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            { return RedirectToAction("Login", "Login"); }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                List<Categoria> rubros = categoriaServicio.GetAllCategorias();
                ViewBag.ListaRubro = new MultiSelectList(rubros, "id", "descripcion");
                List<SubCategoria> tipoActividad = categoriaServicio.GetAllSubCategorias();//hacer que le pase el id de categoria
                ViewBag.ListaTipoActividad = new MultiSelectList(tipoActividad, "id", "descripcion");
                List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
                ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");
                List<Localidad> localidades = localidadServicio.GetAllLocalidades();
                ViewBag.ListaLocalidades = new MultiSelectList(localidades, "id", "descripcion");
                return View(buscarUsuarioLogueado);

            }

        }

        [HttpPost]
        public ActionResult CreacionActividad(Actividad actividad, int[] selectedSegmento)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {

                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                actividadServicio.CrearActividad(actividad, buscarUsuarioLogueado, selectedSegmento);

                return RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);

            }
        }
        public ActionResult ModificarActividad()
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                return View(buscarUsuarioLogueado);
            }
        }
        public ActionResult FichaActividad()
        {
            //obtengo usuario logueado
            /* if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
             {
                 return RedirectToAction("Login", "Login");
             }
             else
             {
                 buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                 return View(buscarUsuarioLogueado);
             }*/

            return View();
        }
        public ActionResult ListaActividades()
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                ViewBag.ListaActvidades = actividadServicio.GetAllActividadByRolEntidadId(buscarUsuarioLogueado.Id);

                //  ViewBag.ListaUsuariosInscriptoActividad = actividadServicio.GetAllActividadUsuarioInscriptoByActividadId( tiene que recibir la actividad id para poder hacerlo, hay que porbar)

                return View(buscarUsuarioLogueado);
                // return View(actividades);
            }
        }


        [HttpPost]
        public ActionResult Actividades(string textoIngresado)
        {
            var lista = actividadServicio.GetBusquedaAvanzada(textoIngresado);
            ViewBag.Lista = lista;
            ViewBag.Contador = lista.Count();
            ViewBag.Valor = textoIngresado;

            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                return View(buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult Actividades(Usuario usuario, string categoriaId)
        {
            if (categoriaId == null)
            {
                categoriaId = "0";
            }

            var lista = actividadServicio.GetBusquedaPorIdCategoria(categoriaId);
            ViewBag.Lista = lista;
            ViewBag.Contador = lista.Count();

            var usuarioLogueado = usuario;
            if (usuarioLogueado.Id == 0)
            {
                var buscarUsuarioLogueado = Session["Usuario"] as Usuario; //obtengo usuario logueado
                if (buscarUsuarioLogueado == null)
                {
                    var user = new Usuario();
                    return View(user);
                }
                else
                {
                    return View(buscarUsuarioLogueado);
                }
            }
            else
            {
                usuarioLogueado = usuarioServicio.GetById(usuario.Id);
                return View(usuarioLogueado);
            }

        }


        [HttpGet]
        [Route("obtenersubcategoria{idCategoria}")]
        public JsonResult ObtenerSubcategoria(int? idCategoria)
        {
            List<SubCategoria> subCategorias = categoriaServicio.GetAllSubCategoriasByCategoriaId(idCategoria);

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(subCategorias);
            return Json(json, JsonRequestBehavior.AllowGet);

        }
    }
}