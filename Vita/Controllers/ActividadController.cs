using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
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
        public ActionResult CreacionActividad(ActividadViewModel actividad, int[] selectedSegmento, HttpPostedFileBase Foto)
        {

            string path = uploadimage(Foto);
            if (path.Equals("-1"))
            {

            }
            else
            {
                actividad.Foto = path;
            }
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {

                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                actividadServicio.CrearActividad(actividad, buscarUsuarioLogueado, selectedSegmento);
                var actividadCreada = actividadServicio.GetUltimaActividadPorUsuarioCreadaId(buscarUsuarioLogueado.Id);

                return actividad.AccionCrearPublicar == true
                    ? RedirectToAction("ExplicativoForm", "Actividad", actividadCreada)
                    : RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);


            }
        }


        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)

            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png") || extension.ToLower().Equals(".JPEG"))

                {
                    try

                    {

                        path = Path.Combine(Server.MapPath("~/Content/imagenes"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/imagenes/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Sólo jpg ,jpeg o png son aceptables....'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Por Favor seleccione una imagen'); </script>");
                path = "-1";
            }
            return path;
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
            ViewBag.ElegirDia = false;
            ViewBag.Inscripto = false;
            ViewBag.Compleja = false;
            ViewBag.CompletarFormulario = false;

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
                bool inscripto = actividadServicio.BuscarUsuarioInscriptoEnActividad(buscarUsuarioLogueado.Id, int.Parse(idActividad));
                ViewBag.Inscripto = inscripto;
                ViewBag.Logueado = true;
                ViewBag.Rol = buscarUsuarioLogueado.RolId;

                return View(buscarUsuarioLogueado);
            }
        }

        [HttpPost]
        public ActionResult FichaActividad(string idActividad, string inscribirse, int[] FechaActividadId, ViewModels.Gmail model)
        {


            var actividad = actividadServicio.GetActividad(int.Parse(idActividad));
            ViewBag.Actividad = actividad;
            ViewBag.FechasActividad = actividad.FechaActividad;
            ViewBag.Resultado = 0;
            ViewBag.IniciarSesion = "false";
            ViewBag.Domicilio = actividad.Domicilio.FirstOrDefault();
            ViewBag.Logueado = false;
            ViewBag.ElegirDia = false;
            ViewBag.Inscripto = false;
            ViewBag.Compleja = false;
            ViewBag.CompletarFormulario = false;

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
                ViewBag.Rol = buscarUsuarioLogueado.RolId;

                if (inscribirse == "true")
                {
                    if (FechaActividadId == null) //No eligió ningún dia y horario
                    {
                        ViewBag.ElegirDia = true;
                    }
                    else
                    {
                        var estadoString = ""; //aca se guarda el estado
                        if (actividad.ConUsuarioPendiente == true)
                        {
                            estadoString = "2"; //pendiente
                        }
                        else
                        {
                            estadoString = "1";//aprobado
                        }
                        var resultado = actividadServicio.InscribirUsuarioEnActividad(buscarUsuarioLogueado, idActividad, estadoString, FechaActividadId); //Aprobado
                        ViewBag.Resultado = resultado;

                        if (resultado == 1) //quedó inscripto en la actividad
                        {
                            if (actividad.ConUsuarioPendiente == true)
                            {
                                ViewBag.CompletarFormulario = true;
                            }

                            //Parte del Mail
                            /*
                            MailAddress to = new MailAddress(buscarUsuarioLogueado.Email);
                            MailAddress from = new MailAddress("vita.contactanos@gmail.com");
                            MailMessage mm = new MailMessage(from, to); */


                            var mensaje = "";
                            var body = "";
                            var tituloActividad = actividad.Titulo;
                            var celular = "whatsapp:+549" + buscarUsuarioLogueado.Celular;
                            var mail = buscarUsuarioLogueado.Email;

                            if (actividad.ConUsuarioPendiente == true) //Su inscripción queda pendiente
                            {
                                ViewBag.Compleja = true; //debe completar el formulario
                                mensaje = "Su inscripción está en estado PENDIENTE. Debe completar el formulario con los requisitos solicitados para poder realizar esta actividad. El mismo lo podrá ver en su perfil en la sección MIS ACTIVIDADES INSCRIPTAS. Se le informará cuando su inscripción este aprobada.";
                                body = "Tu inscripción a la actividad " + tituloActividad + " está en estado pendiente de aprobación. Te avisaremos cuando esté aprobada. Gracias! "; //Mensaje whatsApp


                            }
                            else //Queda aprobado de una
                            {
                                mensaje = "Su inscripción ha sido exitosa. Puede ir a su perfil para ver sus actividades";
                                body = "Tu inscripción a la actividad " + tituloActividad + " ha sido exitosa! "; //Mensaje whatsApp
                                                                                                                  //Parte Email
                                                                                                                  /*  mm.Subject = "Inscripción a " + tituloActividad + " exitosa";
                                                                                                                    mm.Body = "¡Hola! A partir de ahora, Comienza tu nueva actividad - " + tituloActividad + " - VITA Espera que sea de tu agrado y lo más importante... ¡Que te diviertas! ";
                                                                                                                    mm.IsBodyHtml = true;

                                                                                                                    SmtpClient smtp = new SmtpClient();
                                                                                                                    smtp.Host = "smtp.gmail.com";
                                                                                                                    smtp.Port = 587;
                                                                                                                    smtp.EnableSsl = true;

                                                                                                                    NetworkCredential nc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                                                                                                                    smtp.UseDefaultCredentials = true;
                                                                                                                    smtp.Credentials = nc;
                                                                                                                    smtp.Send(mm);*/
                            }

                            ViewBag.Mensaje = mensaje;

                            //Notificaciones de whatsap
                            /*var accountSid = "";
                            var authToken = "";

                            TwilioClient.Init(accountSid, authToken);
                            var message = MessageResource.Create(
                                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                body: body,
                                to: new Twilio.Types.PhoneNumber(celular)
                            );


                            var respuestaApi = message.Sid;*/
                        }
                        else
                        {
                            ViewBag.Mensaje = "Hubo un error al realizar la inscripción";
                        }
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
                ViewBag.Categorias = categoriaServicio.GetAllCategorias();
                //  ViewBag.ListaUsuariosInscriptoActividad = actividadServicio.GetAllActividadUsuarioInscriptoByActividadId( tiene que recibir la actividad id para poder hacerlo, hay que porbar)

                return View(buscarUsuarioLogueado);
                // return View(actividades);
            }
        }

        [HttpPost]
        public ActionResult ListaActividades(int? idCategoria, DateTime? fechaDesde , DateTime? fechaHasta)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                ViewBag.ListaActvidadesFiltrada = actividadServicio.GetActividadesFiltradasPorUsuario(buscarUsuarioLogueado.Id, idCategoria,fechaDesde,fechaHasta);
                ViewBag.Categorias = categoriaServicio.GetAllCategorias(); // solo para q no rompa en el filtro cuando vuelvo a llamar a la vista
                ViewBag.ListaActvidades = actividadServicio.GetAllActividadByRolEntidadId(buscarUsuarioLogueado.Id);
                return View(buscarUsuarioLogueado);


            }
        }

        [HttpPost]
        public ActionResult Actividades(string textoIngresado, int? categoriaId, int? subCategoriaId, int? segmentoId, int? provinciaId, int? departamentoId, int? localidadId, string precio)
        {
            var lista = actividadServicio.GetBusquedaAvanzada(textoIngresado, categoriaId, subCategoriaId, segmentoId, provinciaId, departamentoId, localidadId, precio);
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



        [HttpGet]
        [Route("obtenerSubcategorias{idCategoria}")]
        public string ObtenerSubcategorias(int? id)
        {
            List<SubCategoria> subCategorias = categoriaServicio.GetAllSubCategoriasByCategoriaId(id);
            List<ListaViewModel> listaSubcategorias = new List<ListaViewModel>();
            var i = 0;

            foreach (var item in subCategorias)
            {
                listaSubcategorias.Insert(i, new ListaViewModel() { Id = item.Id, Descripcion = item.Descripcion });
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
                ViewBag.ListaUsuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);
                ViewBag.Actividad = actividadServicio.GetActividad(actividadId);
                ViewBag.Estado = estadoId.ToString();
                return View(buscarUsuarioLogueado);
            }
        }
        [HttpGet]
        public ActionResult CrearFormularioDinamico(string idActividad, bool? publicar)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            { return RedirectToAction("Login", "Login"); }
            else
            {
                ViewBag.PublicarAhora = publicar;
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
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
                if (formularioDinamicoViewModel.publicar == true)
                {
                    actividadServicio.PublicarActividad(activdadCreada.Id);
                }
                return RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);


            }
        }
        [HttpGet]
        public ActionResult ActividadesDelUsuarioInscripto()
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                var actividades = actividadServicio.GetAllActividadByRolUsuarioId(buscarUsuarioLogueado.Id);
                ViewBag.ListaActividades = actividades;
                List<Respuesta> listaRespuestas = new List<Respuesta>();

                listaRespuestas.AddRange(actividadServicio.GetRespuestasByUsuarioId(buscarUsuarioLogueado.Id).ToList());

                ViewBag.ListaRespuestaFormu = listaRespuestas;
                return View(buscarUsuarioLogueado);
            }
        }
        [HttpPost]
        public ActionResult AprobarUsuario(UsuarioEstado usuarioEstado)
        {

            //   foreach(var us in usuarioEstado.Usuarios)
            //   {
            actividadServicio.CambiarEstadoUsuarioInscripto(usuarioEstado.Estado, usuarioEstado.UsuarioId,
                usuarioEstado.ActividadId);

            //  }
            return RedirectToAction("ListaActividades", "Actividad");
            // return RedirectToActionPermanent("ListaEstado", "Actividad",usuarioEstado.EstadoAnterior, usuarioEstado.ActividadId);
        }

        [HttpGet]
        public ActionResult CompletarFormularioDinamicoUsuario(int actividadId)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                ViewBag.Formulario = actividadServicio.GetFormularioDinamicoByActividadId(actividadId);

                return View(buscarUsuarioLogueado);
            }
        }

        [HttpPost]
        public ActionResult ActualizarFormularioUsuario(FormularioLlenoViewModel formu)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);

                foreach (var c in formu.CamposVm)
                {
                    //var res = actividadServicio.GetRespuestaById(c.Id);
                    if (c.Foto != null)
                    {
                        c.RespuestaFoto = this.uploadimage(c.Foto);
                    }
                    c.UsuarioId = buscarUsuarioLogueado.Id;
                }

                actividadServicio.ActualizarRespuestas(formu.CamposVm);


                return RedirectToAction("ActividadesDelUsuarioInscripto", "Actividad", buscarUsuarioLogueado);
            }
        }
        [HttpPost]
        public ActionResult GuardarFormularioUsuario(FormularioLlenoViewModel formu)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                foreach (var c in formu.CamposVm)
                {
                    if (c.Foto != null)
                    {
                        c.RespuestaFoto = this.uploadimage(c.Foto);
                    }
                    c.UsuarioId = buscarUsuarioLogueado.Id;
                }

                actividadServicio.GuardarFormularioUsuario(formu);


                return RedirectToAction("ActividadesDelUsuarioInscripto", "Actividad", buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult ModificarFormularioDinamicoUsuario(int actividadId)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                ViewBag.Formulario = actividadServicio.GetFormularioDinamicoByActividadId(actividadId);
                var respuestas = actividadServicio.GetRespuestasByUsuarioIdandActividadId(buscarUsuarioLogueado.Id, actividadId);
                ViewBag.FormularioAModificar = respuestas;

                return View(buscarUsuarioLogueado);
            }
        }
        [HttpGet]
        public ActionResult RespuestasFormularioDinamico(int actividadId, int usuarioRespuestaId)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                var actividad = actividadServicio.GetActividad(actividadId);
                ViewBag.UsuarioRespuestaId = usuarioRespuestaId;
                var respuestasFoto = new List<Respuesta>();

                foreach (var item in actividad.FormularioDinamico)
                {
                    if (item.ActividadId == actividadId)
                    {
                        ViewBag.Campos = item.Campos; //consignas
                        ViewBag.IdFormularioDinamico = item.Id; //id formulario dinamico
                        ViewBag.NombreFormulario = item.Titulo; //titulo
                        ViewBag.DescripcionFormulario = item.Descripcion; //descripcion
                    }
                }

                return View(buscarUsuarioLogueado);
            }
        }

        public ActionResult ExplicativoForm(Actividad actividad)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                ViewBag.Actividad = actividadServicio.GetActividad(actividad.Id);
                return View(buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult Publicar(string idActividad)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {

                actividadServicio.PublicarActividad(int.Parse(idActividad));
                //ViewBag.actividadCreada = actividadServicio.GetActividad(actividad.Id);
                return RedirectToAction("ListaActividades", "Actividad");
            }
        }

        [HttpGet]
        public ActionResult VerRespuestaFormulario(int actividadId)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                var actividad = actividadServicio.GetActividad(actividadId);
                ViewBag.UsuarioRespuestaId = buscarUsuarioLogueado.Id;

                foreach (var item in actividad.FormularioDinamico)
                {
                    if (item.ActividadId == actividadId)
                    {
                        ViewBag.Campos = item.Campos; //consignas
                        ViewBag.IdFormularioDinamico = item.Id; //id formulario dinamico
                        ViewBag.NombreFormulario = item.Titulo; //titulo
                        ViewBag.DescripcionFormulario = item.Descripcion; //descripcion
                    }
                }

                return View(buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult DarseDeBajaActividad(int actividadId)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);


                actividadServicio.DarseDeBajaActividad(actividadId, buscarUsuarioLogueado.Id);


                return RedirectToAction("ActividadesDelUsuarioInscripto", "Actividad", buscarUsuarioLogueado);
            }
        }
    }
}