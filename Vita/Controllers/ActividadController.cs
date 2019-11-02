using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vita.Servicios;
using Vita.ViewModels;

using Twilio.Rest.Api.V2010.Account;
using Twilio;

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
                List<Provincia> provincias = localidadServicio.GetAllProvincias();
                ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");
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
        public ActionResult CreacionActividad(ActividadViewModel actividad, int[] selectedSegmento)
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
        public ActionResult FichaActividad(string idActividad, string inscribirse)
        {
            var actividad = actividadServicio.GetActividad(int.Parse(idActividad));
            ViewBag.Actividad = actividad;
            ViewBag.Resultado = 0;
            ViewBag.IniciarSesion = "false";
            ViewBag.Domicilio = actividad.Domicilio.FirstOrDefault();

            //obtengo usuario logueado
                if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
             {
                var user = new Usuario();

                if (inscribirse == "true")
                {
                    ViewBag.IniciarSesion = "true";
                }

                    return View(user);
            }
             else
             {
                 buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);

                    if (inscribirse == "true")
                    {
                       var resultado = actividadServicio.InscribirUsuarioEnActividad(buscarUsuarioLogueado, idActividad, "1"); //Aprobado
                        ViewBag.Resultado = resultado;

                        if (resultado == 1)
                        {
                            var mensaje = "Su inscripción ha sido exitosa. Puede ir a su perfil para ver sus actividades";
                            ViewBag.Mensaje = mensaje;

                            //Notificaciones de whatsap
                            var accountSid = "ACe4ace95ec1876ed6708c1005e641c841";
                            var authToken = "d64586e41962636783566d12ef4c103e";

                            TwilioClient.Init(accountSid, authToken);

                            var message = MessageResource.Create(
                                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                body: "Su inscripción ha sido exitosa",
                                to: new Twilio.Types.PhoneNumber("whatsapp:+5491127814553")
                            );


                            var respuestaApi = message.Sid;
                        }
                        else
                        {
                            ViewBag.Mensaje = "Hubo un error al realizar la inscripción";
                        }
                    }

                return View(buscarUsuarioLogueado);
             }
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
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
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
                var lista1 = actividadServicio.GetAllActividades();
                ViewBag.Lista = lista1;
                ViewBag.Contador = lista1.Count();
            }
            else
            {
                var lista2 = actividadServicio.GetBusquedaPorIdCategoria(categoriaId);
                ViewBag.Lista = lista2;
                ViewBag.Contador = lista2.Count();
            }
           
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

        //Lo comento porque no me funciona no eliminar
      /*  [HttpGet]
        [Route("obtenersubcategoria{idCategoria}")]
       
        public JsonResult ObtenerSubcategoria(int? id)
        {
           if(id == null)
            {
                id = 3;
            }
            List<SubCategoria> subCategorias = categoriaServicio.GetAllSubCategoriasByCategoriaId(id);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(subCategorias);

            return Json(json, JsonRequestBehavior.AllowGet);
        }*/
        //public string ObtenerSubcategoria(int? id)
        //{
        //    List<SubCategoria> subCategorias = categoriaServicio.GetAllSubCategoriasByCategoriaId(id);

        //    string result = JsonConvert.SerializeObject(subCategorias,
        //          new JsonSerializerSettings
        //          {
        //              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //          });

        //    return result;

        //}
        [HttpGet]
        [Route("obtenerselectpaisusuario{idPais}")]
        public string ObtenerSelectPaisUsuario(int? id)
        {
            List<Departamento> departamentos = localidadServicio.GetDepartamentosByProvinciaId(id);

            string result = JsonConvert.SerializeObject(departamentos,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return result;
        }
        [HttpGet]
        [Route("obtenerselectdepartamentousuario{idDepartamento}")]
        public string ObtenerSelectDepartamentoUsuario(int? id)
        {
            List<Localidad> localidades = localidadServicio.GetLocalidadesByDepartamentoId(id);
            string result = JsonConvert.SerializeObject(localidades,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return result;
        }
        [HttpGet]
        public ActionResult ListaEstado(int estadoId, int actividadId)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
              //  var actividadesPorEstado = actividadServicio.GetByEstadoId(estadoId, actividadId);
                ViewBag.ListaUsuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);

                return View(buscarUsuarioLogueado);
                // return View(actividades);
            }
        }
    }
}