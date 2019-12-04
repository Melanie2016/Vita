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
            ViewBag.ActividadId = actividad.Id;
            ViewBag.FechasActividad = actividad.FechaActividad;
            ViewBag.Resultado = 0;
            ViewBag.IniciarSesion = "false";
            ViewBag.Domicilio = actividad.Domicilio.FirstOrDefault();
            ViewBag.Logueado = false;
            ViewBag.ElegirDia = false;
            ViewBag.Inscripto = false;
            ViewBag.Compleja = false;
            if(actividad.ConUsuarioPendiente== true){
                ViewBag.CompletarFormulario = true;
            }
            else
            {
                ViewBag.CompletarFormulario = false;
            }
           

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
            ViewBag.ActividadId = actividad.Id;
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
                            
                            MailAddress to = new MailAddress(buscarUsuarioLogueado.Email);
                            MailAddress from = new MailAddress("vita.contactanos@gmail.com");
                            MailMessage mm = new MailMessage(from, to); 


                            var mensaje = "";
                            var body = "";
                            var tituloActividad = actividad.Titulo;
                            var celular = "whatsapp:+549" + buscarUsuarioLogueado.Celular;
                            var mail = buscarUsuarioLogueado.Email;

                            if (actividad.ConUsuarioPendiente == true) //Su inscripción queda pendiente
                            {
                                ViewBag.Compleja = true; //debe completar el formulario
                                try
                                {
                                 
                                    mensaje = "Su inscripción está en estado PENDIENTE. Debe completar un formulario con los requisitos solicitados para realizar esta actividad. Se le informará cuando su inscripción este aprobada.";
                                    body = "Tu inscripción a la actividad " + tituloActividad + " está en estado pendiente de aprobación. Te avisaremos cuando esté aprobada. Gracias! "; //Mensaje whatsApp
                                    mm.Subject = "Inscripción a " + tituloActividad + " en estado Pendiente";
                                    mm.Body = "¡Hola! Tu inscripción a la actividad " + tituloActividad + " está en estado pendiente de aprobación. Te avisaremos cuando esté aprobada. Gracias! ";
                                    mm.IsBodyHtml = true;

                                    SmtpClient smtp = new SmtpClient();
                                    smtp.Host = "smtp.gmail.com";
                                    smtp.Port = 587;
                                    smtp.EnableSsl = true;

                                    NetworkCredential nc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                                    smtp.UseDefaultCredentials = true;
                                    smtp.Credentials = nc;
                                    smtp.Send(mm);
                                }
                                catch (Exception e)
                                {
                                    ViewBag.Mensaje = "No tenes internet";
                                }
                                

                            }
                            else //Queda aprobado de una
                            {
                                mensaje = "Su inscripción ha sido exitosa. Puede ir a su perfil para ver sus actividades";
                                body = "Tu inscripción a la actividad " + tituloActividad + " ha sido exitosa! ";
                                //Parte Email
                                  mm.Subject = "Inscripción a " + tituloActividad + " exitosa";
                                  mm.Body = "¡Hola! A partir de ahora, Comienza tu nueva actividad - " + tituloActividad + " - VITA Espera que sea de tu agrado y lo más importante... ¡Que te diviertas! ";
                                  mm.IsBodyHtml = true;

                                  SmtpClient smtp = new SmtpClient();
                                  smtp.Host = "smtp.gmail.com";
                                  smtp.Port = 587;
                                  smtp.EnableSsl = true;

                                  NetworkCredential nc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                                  smtp.UseDefaultCredentials = true;
                                  smtp.Credentials = nc;
                                  smtp.Send(mm);
                            }

                            ViewBag.Mensaje = mensaje;

                            //Notificaciones de WhatsApp
                            try
                            {
                                var accountSid = "ACe237f679127cbe29fcb106e4f6a0be6f";
                                var authToken = "";
                                    /*
                                TwilioClient.Init(accountSid, authToken);
                                var message = MessageResource.Create(
                                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                    body: body,
                                    to: new Twilio.Types.PhoneNumber(celular)
                                );

                                var respuestaApi = message.Sid;*/
                            }
                            catch
                            {

                            }


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

        [HttpGet]
        public ActionResult ListaActividades()
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                DateTime fechaNull = new DateTime(978361200);//esto es fecha null

                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                ViewBag.Estados = actividadServicio.GetEstadosActividad();
                ViewBag.Categorias = categoriaServicio.GetAllCategorias();
                var actividades = actividadServicio.GetAllActividadByRolEntidadId(buscarUsuarioLogueado.Id);

                if (actividades.Any())
                {

                    var listaActividadesVigentes = actividades.Where(x => x.DeletedAt == fechaNull || x.DeletedAt == null).ToList();
                    ViewBag.ListaActvidades = listaActividadesVigentes;
                    ViewBag.ListaActividadesEliminadas = actividadServicio.GetAllActividadesEliminadasByEntidadId(buscarUsuarioLogueado.Id);
                    var actividadesVigentes = actividadServicio.GetAllActividadesVigentesByEntidadId(buscarUsuarioLogueado.Id);
                }
                else
                {
                    ViewBag.ListaActvidades = actividades;
                }


                return View(buscarUsuarioLogueado);
            }
        }

        [HttpPost] //texto tiene que pasar 
        public ActionResult ListaActividades(string titulo, int? idCategoria, int? idEstado, DateTime? fechaDesde )
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var ListaActvidadesFiltrada = new List<Actividad>();
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                ListaActvidadesFiltrada = actividadServicio.GetActividadesFiltradasPorUsuario(titulo,buscarUsuarioLogueado.Id, idCategoria, idEstado, fechaDesde);
                ViewBag.ListaActvidadesFiltrada = ListaActvidadesFiltrada;
                
                if (ListaActvidadesFiltrada.Count() == 0)
                {
                    ViewBag.resultadoVacio = "No se encontraron resultados para esta busqueda";
                }
                ViewBag.Categorias = categoriaServicio.GetAllCategorias(); // solo para q no rompa en el filtro cuando vuelvo a llamar a la vista
                ViewBag.Estados = actividadServicio.GetEstadosActividad();
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
        public ActionResult ListaEstado(int estadoId, int? estadoId2, int? estadoId3, int actividadId)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);
                if (estadoId2 != null && estadoId3 != null) //hay ambas
                {
                    List<Usuario> listaUsuario = new List<Usuario>();
                    var lista1Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);
                    var lista2Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId2.Value, actividadId);
                    var lista3Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId3.Value, actividadId);
                    listaUsuario.AddRange(lista1Usuario);
                    listaUsuario.AddRange(lista2Usuario);
                    listaUsuario.AddRange(lista3Usuario);
                    ViewBag.ListaUsuario = listaUsuario;
                }
                else
                {
                    if(estadoId2 != null && estadoId3== null)
                    {
                        List<Usuario> listaUsuario = new List<Usuario>();
                        var lista1Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);
                        var lista2Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId2.Value, actividadId);
                        listaUsuario.AddRange(lista1Usuario);
                        listaUsuario.AddRange(lista2Usuario);
                        ViewBag.ListaUsuario = listaUsuario;
                    }
                    else if (estadoId3 != null && estadoId2 == null)
                    {
                        List<Usuario> listaUsuario = new List<Usuario>();
                        var lista1Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);
                        var lista3Usuario = actividadServicio.GetUsuariosByEstadoId(estadoId3.Value, actividadId);
                        listaUsuario.AddRange(lista1Usuario);
                        listaUsuario.AddRange(lista3Usuario);
                        ViewBag.ListaUsuario = listaUsuario;
                    }
                    else
                    {
                         ViewBag.ListaUsuario = actividadServicio.GetUsuariosByEstadoId(estadoId, actividadId);

                    }

                }
                ViewBag.Actividad = actividadServicio.GetActividad(actividadId);
                ViewBag.Estado = estadoId.ToString();
                ViewBag.EstadoString = actividadServicio.GetByEstadoId(estadoId).Descripcion;
                return View(buscarUsuarioLogueado);
            }
        }
        [HttpGet]
        public ActionResult CrearFormularioDinamico(int? idActividad, bool? publicar)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            { return RedirectToAction("Login", "Login"); }
            else
            {
                ViewBag.Actividad = idActividad;
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
                var activdadCreada = actividadServicio.GetActividad(formularioDinamicoViewModel.ActividadId);
                actividadServicio.CrearFormularioDinamico(formularioDinamicoViewModel, activdadCreada);
                if (formularioDinamicoViewModel.publicar == true)
                {
                    actividadServicio.PublicarActividad(activdadCreada.Id, true);
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
        public ActionResult AprobarORechazarUsuario(UsuarioEstado usuarioEstado, String Para, String Asunto, String Mensaje, String Estado, String Rechazar, String RechazoNoti, ViewModels.Gmail model)
        {
            try
            {
                //   foreach(var us in usuarioEstado.Usuarios)
                //   {
                actividadServicio.CambiarEstadoUsuarioInscripto(usuarioEstado.Estado, usuarioEstado.UsuarioId,
                    usuarioEstado.ActividadId);
                actividadServicio.CambiarEstadoUsuarioInscripto(usuarioEstado.Estado, usuarioEstado.UsuarioId,
               usuarioEstado.ActividadId);
                var tituloActividad = actividadServicio.GetActividad(usuarioEstado.ActividadId).Titulo;
                var to = usuarioServicio.GetUsuarioById(usuarioEstado.UsuarioId).Email;

                if (Estado != null)
                {
                    try
                    {
                        MailMessage mm = new MailMessage("vita.contactanos@gmail.com", to);
                        mm.Subject = "Inscripción a " + tituloActividad + " Aprobada";
                        mm.Body = "¡Tu solicitud ha sido aprobada! A partir de ahora, Comienza tu nueva actividad - " + tituloActividad + " - VITA Espera que sea de tu agrado y lo más importante... ¡Que te diviertas! ";
                        mm.IsBodyHtml = true;

                        SmtpClient smtpp = new SmtpClient();
                        smtpp.Host = "smtp.gmail.com";
                        smtpp.Port = 587;
                        smtpp.EnableSsl = true;

                        NetworkCredential ncc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                        smtpp.UseDefaultCredentials = true;
                        smtpp.Credentials = ncc;
                        smtpp.Send(mm);
                    }
                    catch
                    {

                    }
               
                }

                else if (Rechazar != null)
                {
                    try
                    {
                        MailMessage mm = new MailMessage("vita.contactanos@gmail.com", to);
                        mm.Subject = "Inscripción a " + tituloActividad + " Rechazada :( ";
                        mm.Body = "Te han rechazado a la Actividad: - " + tituloActividad + " pero no te preocupes! ¡Tenemos muchas más Actividades para vos!";
                        mm.IsBodyHtml = true;

                        SmtpClient smtpp = new SmtpClient();
                        smtpp.Host = "smtp.gmail.com";
                        smtpp.Port = 587;
                        smtpp.EnableSsl = true;

                        NetworkCredential ncc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                        smtpp.UseDefaultCredentials = true;
                        smtpp.Credentials = ncc;
                        smtpp.Send(mm);
                    }
                    catch
                    {

                    }
                  
                }

                else if (RechazoNoti != null)
                {
                    try
                    {
                        MailMessage correo = new MailMessage();
                        correo.From = new MailAddress("vita.contactanos@gmail.com");
                        correo.To.Add(Para);
                        correo.Subject = Asunto;
                        correo.Body = Mensaje;
                        correo.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        NetworkCredential nc = new NetworkCredential("vita.contactanos@gmail.com", "vita0019");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = nc;
                        smtp.Send(correo);
                    }
                    catch
                    {

                    }
                
                   
                }

                try
                {
                    //Notificaciones de WhatsApp
                    var body = "";
                    var celular = "whatsapp:+549" + usuarioServicio.GetUsuarioById(usuarioEstado.UsuarioId).Celular;

                    if (usuarioEstado.Estado)
                    {
                        body = "Tu inscripción a la actividad " + tituloActividad + " ha sido aprobada!";
                    }
                    else
                    {
                        if (Mensaje != null)
                        {
                            body = "Tu inscripción a la actividad " + tituloActividad + " ha sido rechazada. " + Mensaje;
                        }
                        else
                        {
                            body = "Tu inscripción a la actividad " + tituloActividad + " ha sido rechazada.";
                        }

                    }
                }
                catch
                {

                }
                

                try
                {
                    
                    var accountSid = "ACe237f679127cbe29fcb106e4f6a0be6f";
                    var authToken = "";
                    /*
                    TwilioClient.Init(accountSid, authToken);
                    var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                        body: body,
                        to: new Twilio.Types.PhoneNumber(celular)
                    );

                    var respuestaApi = message.Sid;*/
                }
                catch
                {

                }

                //  }
                return RedirectToAction("ListaActividades", "Actividad");
                // return RedirectToActionPermanent("ListaEstado", "Actividad",usuarioEstado.EstadoAnterior, usuarioEstado.ActividadId);
            }
            catch
            {
                return RedirectToAction("ListaActividades", "Actividad");
            }



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
                var motivoRechazo = actividadServicio.GetMotivoRechazoForm(buscarUsuarioLogueado.Id, ViewBag.Formulario.Id, ViewBag.Formulario.ActividadId);
                var camposModificar = actividadServicio.GetCampoRechazadosDelMotivoRechazoId(motivoRechazo.Id);
                var respuestas = actividadServicio.GetRespuestasByUsuarioIdandActividadId(buscarUsuarioLogueado.Id, actividadId);
                var prueba = actividadServicio.GetArmarFormularioRehacerUsuario(buscarUsuarioLogueado.Id, motivoRechazo.Id);
                ViewBag.FormularioAModificar = respuestas;
                ViewBag.MotivoRechazo = motivoRechazo;
                ViewBag.CamposModificar = camposModificar;
                ViewBag.Prueba = prueba;

                return View(buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult ModificarFormularioDinamicoEntidad(int actividadId)
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
                //  var respuestas = actividadServicio.GetRespuestasByUsuarioIdandActividadId(buscarUsuarioLogueado.Id, actividadId);
                //   ViewBag.FormularioAModificar = respuestas;

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
                ViewBag.ActividadId = actividad.Id.ToString();
                ViewBag.UsuarioRespuestaId = usuarioRespuestaId;
                var usuarioInscripto = usuarioServicio.GetById(usuarioRespuestaId);

                foreach (var item in usuarioInscripto.UsuarioInscriptoActividad)
                {
                    if (item.ActividadId == actividadId)
                    {
                        ViewBag.Estado = item.EstadoId;
                    }
                }

                var respuestasFoto = new List<Respuesta>();

                foreach (var item in actividad.FormularioDinamico)
                {
                    if (item.ActividadId == actividadId)
                    {
                        ViewBag.DatosUsuario = usuarioServicio.GetById(usuarioRespuestaId);
                        ViewBag.Actividad = item.Actividad;
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
        public ActionResult Publicar(string idActividad, bool? conUsuarioPendiente)
        {
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                var user = new Usuario();
                return View(user);
            }
            else
            {

                actividadServicio.PublicarActividad(int.Parse(idActividad), conUsuarioPendiente);
                //ViewBag.actividadCreada = actividadServicio.GetActividad(actividad.Id);
                return RedirectToAction("ListaActividades", "Actividad");
            }
        }

        public ActionResult EstadisticasCategoria()
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

        public ActionResult EstadisticasSemana()
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

        public ActionResult EstadisticasSegmento()
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

        [HttpGet]
        public JsonResult GetEstadisticasDonut(int estadisticaSeleccionada)
        {
            {
                var usuario = Session["Usuario"] as Usuario;
                if (estadisticaSeleccionada == ConstantesUtil.ESTADISTICA_CATEGORIA)
                {
                    var events = actividadServicio.GetEstadisticasDonutCategoria();
                    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    if(estadisticaSeleccionada == ConstantesUtil.ESTADISTICA_SEMANA)
                    {
                        var events = actividadServicio.GetEstadisticasDonutSemana();
                        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        var events = actividadServicio.GetEstadisticasDonutSegmento();
                        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    
                }
                
            }
        }

        [HttpGet]
        public JsonResult GetEstadisticasBar(int estadisticaSeleccionada)
        {
            {
                var usuario = Session["Usuario"] as Usuario;
                if(estadisticaSeleccionada == ConstantesUtil.ESTADISTICA_CATEGORIA)
                {
                    var events = actividadServicio.GetEstadisticasBarCategoria();
                    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    if (estadisticaSeleccionada == ConstantesUtil.ESTADISTICA_SEMANA)
                    {
                        var events = actividadServicio.GetEstadisticasBarSemana();
                        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        var events = actividadServicio.GetEstadisticasBarSegmento();
                        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    
                }
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
        public ActionResult VerFormularioEntidad(int actividadId)
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
                ViewBag.Formulario = actividadServicio.GetFormularioDinamicoByActividadId(actividadId);

                //ViewBag.UsuarioRespuestaId = buscarUsuarioLogueado.Id;

                //foreach (var item in actividad.FormularioDinamico)
                //{
                //    if (item.ActividadId == actividadId)
                //    {
                //        ViewBag.Campos = item.Campos; //consignas
                //        ViewBag.IdFormularioDinamico = item.Id; //id formulario dinamico
                //        ViewBag.NombreFormulario = item.Titulo; //titulo
                //        ViewBag.DescripcionFormulario = item.Descripcion; //descripcion
                //    }
                //}

                return View(buscarUsuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult EliminaroDarseBajaActividad(int actividadId)
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
                var usuario = usuarioServicio.GetById(buscarUsuarioLogueado.Id);

                return usuario.RolId == 1
                   ? RedirectToAction("ActividadesDelUsuarioInscripto", "Actividad", buscarUsuarioLogueado)
                   : RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);
                // return RedirectToAction("ActividadesDelUsuarioInscripto", "Actividad", buscarUsuarioLogueado);
            }
        }

        [HttpPost]
        public ActionResult MandarRehacerFormuDinamico(RehacerFormuDinamico formu, int[] CamposRehacer)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                formu.EntidadId = buscarUsuarioLogueado.Id;
                actividadServicio.MandarRehacerFormuDinamico(formu, CamposRehacer);

                //Notificaciones de WhatsApp
                var tituloActividad = actividadServicio.GetActividad(formu.ActividadId).Titulo;
                var body = "Hola! su inscripción a la actividad " + tituloActividad + " ha sido rechazada. Debe rehacer el formulario: " + formu.DescripcionMotivo;         
                var usuarioForm = usuarioServicio.GetById(formu.UsuarioId);
                var celular = "whatsapp:+549" + usuarioForm.Celular;
                try
                {
                    var accountSid = "ACe237f679127cbe29fcb106e4f6a0be6f";
                    var authToken = "";
                    /*
                   TwilioClient.Init(accountSid, authToken);
                    var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                        body: body,
                        to: new Twilio.Types.PhoneNumber(celular)
                    );

                    var respuestaApi = message.Sid;*/
                }
                catch
                {

                }


                return RedirectToAction("ListaActividades", "Actividad", buscarUsuarioLogueado);

            }
        }
    }
}