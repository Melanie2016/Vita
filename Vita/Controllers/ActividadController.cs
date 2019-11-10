using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Vita.Servicios;
using Vita.ViewModels;

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
                var activdadCreada = actividadServicio.GetUltimaActividadPorUsuarioCreadaId(buscarUsuarioLogueado.Id);
                if (activdadCreada.Compleja == true)
                {
                    return RedirectToAction("CrearFormularioDinamico", "Actividad", activdadCreada);

                }
                else
                {
                    return RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);

                }


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
            ViewBag.FechasActividad = actividad.FechaActividad;
            ViewBag.Resultado = 0;
            ViewBag.IniciarSesion = "false";
            ViewBag.Domicilio = actividad.Domicilio.FirstOrDefault();
            ViewBag.Logueado = false;

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
                ViewBag.Logueado = true;

                if (inscribirse == "true")
                {
                    var resultado = actividadServicio.InscribirUsuarioEnActividad(buscarUsuarioLogueado, idActividad, "1"); //Aprobado
                    ViewBag.Resultado = resultado;

                    if (resultado == 1)
                    {
                        var mensaje = "Su inscripción ha sido exitosa. Puede ir a su perfil para ver sus actividades";
                        ViewBag.Mensaje = mensaje;

                        //Notificaciones de whatsap
                       /* var accountSid = "ACe4ace95ec1876ed6708c1005e641c841";
                        var authToken = "";

                        TwilioClient.Init(accountSid, authToken);

                        var tituloActividad = actividad.Titulo;

                        var message = MessageResource.Create(
                            from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                            body: "Tu inscripción a la actividad " + tituloActividad + " ha sido exitosa! ",
                            to: new Twilio.Types.PhoneNumber("whatsapp:+5491127814553")
                        );


                        var respuestaApi = message.Sid;*/
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
        public ActionResult Actividades(string textoIngresado, int idCategoria, int idSubcategoria, int idSegmento, int idProvincia, int idDepartamento, int idLocalidad)
        {
            var lista = actividadServicio.GetBusquedaAvanzada(textoIngresado);
            ViewBag.Lista = lista;
            ViewBag.Contador = lista.Count();
            ViewBag.Valor = textoIngresado;
            ViewBag.Categorias = categoriaServicio.GetAllCategorias(); //obtengo todas las categorias para el filtro
            ViewBag.Segmentos = segmentoServicio.GetAllSegmento(); //obtengo todos los segmentos para el filtro
            ViewBag.Provincias = localidadServicio.GetAllProvincias(); //obtengo todas las provincias para el filtro

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
            ViewBag.Categorias = categoriaServicio.GetAllCategorias(); //obtengo todas las categorias para el filtro
            ViewBag.Segmentos = segmentoServicio.GetAllSegmento(); //obtengo todos los segmentos para el filtro
            ViewBag.Provincias = localidadServicio.GetAllProvincias(); //obtengo todas las provincias para el filtro

            if (categoriaId == null)
            {
                var lista1 = actividadServicio.GetAllActividades(); //obtiene todas las actividades
                ViewBag.Lista = lista1;
                ViewBag.Contador = lista1.Count();
            }
            else
            {
                var lista2 = actividadServicio.GetBusquedaPorIdCategoria(categoriaId); //obtiene las actividades por categoria
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
                    return View(user); //no logueado
                }
                else
                {
                    return View(buscarUsuarioLogueado); //logueado
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
        [Route("obtenerSubcategorias{idCategoria}")]
        public string ObtenerSubcategorias(int? id)
        {
            List<SubCategoria> subCategorias = categoriaServicio.GetAllSubCategoriasByCategoriaId(id);
            List<ListaViewModel> listaSubcategorias = new List<ListaViewModel>();
            var i = 0;

            foreach (var item in subCategorias)
            {
                listaSubcategorias.Insert(i, new ListaViewModel() { Id = item.Id, Descripcion = item.Descripcion});
                i++;
            }

            string result = JsonConvert.SerializeObject(listaSubcategorias,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return result;
        }

        [HttpGet]
        [Route("obtenerDepartamentos{idProvincia}")]
        public string ObtenerDepartamentos(int? id)
        {
            List<Departamento> departamentos = localidadServicio.GetDepartamentosByProvinciaId(id);
            List<ListaViewModel> listaDepartamentos = new List<ListaViewModel>();
            var i = 0;

            foreach (var item in departamentos)
            {
                listaDepartamentos.Insert(i, new ListaViewModel() { Id = item.Id, Descripcion = item.Descripcion });
                i++;
            }

            string result = JsonConvert.SerializeObject(listaDepartamentos,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return result;
        }

        [HttpGet]
        [Route("obtenerLocalidades{idDepartamento}")]
        public string ObtenerLocalidades(int? id)
        {
            List<Localidad> localidades = localidadServicio.GetLocalidadesByDepartamentoId(id);
            List<ListaViewModel> listaLocalidades = new List<ListaViewModel>();
            var i = 0;

            foreach (var item in localidades)
            {
                listaLocalidades.Insert(i, new ListaViewModel() { Id = item.Id, Descripcion = item.Descripcion });
                i++;
            }

            string result = JsonConvert.SerializeObject(listaLocalidades,
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
        [HttpGet]
        public ActionResult CrearFormularioDinamico(Actividad actividad)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            { return RedirectToAction("Login", "Login"); }
            else
            {
                List<TipoDatoCampo> listaTipoDatoCampo = actividadServicio.GetAllTipoDatoCampo();
                ViewBag.ListaTipoPregunta = new MultiSelectList(listaTipoDatoCampo, "id", "descripcion");
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                //   return View();
                return View(buscarUsuarioLogueado);
            }

        }
        [HttpPost]
        public ActionResult CreacionFormularioDinamico(FormularioDinamicoViewModel formularioDinamicoViewModel)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {

                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                var activdadCreada = actividadServicio.GetUltimaActividadPorUsuarioCreadaId(buscarUsuarioLogueado.Id);
                actividadServicio.CrearFormularioDinamico(formularioDinamicoViewModel, activdadCreada);
              
                return RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);


            }
        }
    }
}