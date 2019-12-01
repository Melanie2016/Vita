using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Vita.Servicios;
using Vita.ViewModels;
using Vita.Views.Actividad;

namespace Vita.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private ActividadServicio actividadServicio = new ActividadServicio();
        private VitaEntities myDbContext = new VitaEntities();

        [HttpGet]
        public ActionResult Registro()
        {
            ViewBag.HayValidaciones = false;

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");

            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");

            return View();
        }

        [HttpGet]
        public ActionResult RegistroEntidad(string HayValidaciones)
        {
            ViewBag.HayValidaciones = false;

            if (HayValidaciones == "True")
            {
                ViewBag.HayValidaciones = true;
                ViewBag.Mensaje = "El nombre de usuario ya se encuentra registrado. Ingrese otro";

            }

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");

            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");

            return View();
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

        [HttpPost]
        public ActionResult Registro(Usuario usuario, int[] selectedSegmento, int[] selectedCategoria, HttpPostedFileBase Foto, string tipoRegistro)
        {
            ViewBag.HayValidaciones = false;

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");

            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");

            string path = uploadimage(Foto);
            if (path.Equals("-1"))
            {

            }
            else
            {
                usuario.Foto = path;
            }
            var nombreDeUsuarioExiste = usuarioServicio.VerificarExistenciaUsuarioNombre(usuario);
            var existeElUsuario = usuarioServicio.VerificarExistenciaDelUsuario(usuario);
            if (nombreDeUsuarioExiste != null)
            {
                //ACA DEBERIA DECIR, Si el nombre de usuario ya existe ingrese otro nombre de usuario 
                ViewBag.HayValidaciones = true;
                ViewBag.Mensaje = "El nombre de usuario ya se encuentra registrado. Ingrese otro";

                if (usuario.RolId == 1) //Persona
                {
                    if (tipoRegistro == "facebook")
                    {
                        return RedirectToAction("RegistrarFacebook", new RouteValueDictionary(new { controller = "Usuario", action = "RegistrarFacebook", ViewBag.Mensaje }));
                    }
                    else
                    {
                        return View();
                    }
                }
                else //Entidad
                {
                    return RedirectToAction("RegistroEntidad", new RouteValueDictionary(new { controller = "Usuario", action = "RegistroEntidad", HayValidaciones = true }));
                }

            }
            else if (existeElUsuario != null)
            {
                //ACA DEBERIA DECIR, su usuario ya existe 
                ViewBag.HayValidaciones = true;
                ViewBag.Mensaje = "Ya existe un usuario registrado con el número de documento " + usuario.Dni;

                if (tipoRegistro == "facebook")
                {
                    return RedirectToAction("RegistrarFacebook", new RouteValueDictionary(new { controller = "Usuario", action = "RegistrarFacebook", ViewBag.Mensaje }));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                usuarioServicio.CrearUsuario(usuario);
                if (usuario.RolId == 1)
                {
                    usuarioServicio.CrearUsuarioSegmento(usuario.Id, selectedSegmento);
                    usuarioServicio.CrearUsuarioCategoriaElegida(usuario.Id, selectedCategoria);
                    Session["Usuario"] = usuario;
                    return RedirectToAction("PerfilUsuario", "Usuario", usuario);
                }
                else
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("PerfilEntidad", "Usuario", usuario);
                }
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

                //Response.Write("<script>alert('Por Favor seleccione una imagen'); </script>");
                path = "-1";
            }
            return path;
        }


        [HttpGet]
        public ActionResult PerfilUsuario(Usuario usuario)
        {
            var usuarioLogueado = usuario;
            if (usuarioLogueado.Id == 0)
            {
                var buscarUsuarioLogueado = Session["Usuario"] as Usuario; //obtengo usuario logueado
                if (buscarUsuarioLogueado == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);

                    if (buscarUsuarioLogueado.UpdatedAt != null)
                    {
                        ViewBag.UltimaModificacion = buscarUsuarioLogueado.UpdatedAt.ToString().Remove(11);
                    }
                    else
                    {
                        ViewBag.UltimaModificacion = "";
                    }

                    List<Categoria> categoriasElegidas = categoriaServicio.GetAllCategoriasDelUsuario(buscarUsuarioLogueado);
                    ViewBag.ListacategoriasElegidas = new MultiSelectList(categoriasElegidas, "id", "descripcion");
                    List<Segmento> segmentoElegidos = segmentoServicio.GetAllSegmentosDelUsuario(buscarUsuarioLogueado);
                    ViewBag.ListasegmentosElegidos = new MultiSelectList(segmentoElegidos, "id", "descripcion");

                    return View(buscarUsuarioLogueado);
                }

            }
            else
            {
                usuarioLogueado = usuarioServicio.GetById(usuario.Id);

                if (usuarioLogueado.UpdatedAt != null)
                {
                    ViewBag.UltimaModificacion = usuarioLogueado.UpdatedAt.ToString().Remove(11);
                }
                else
                {
                    ViewBag.UltimaModificacion = "";
                }

                List<Categoria> categoriasElegidas = categoriaServicio.GetAllCategoriasDelUsuario(usuarioLogueado);
                ViewBag.ListacategoriasElegidas = new MultiSelectList(categoriasElegidas, "id", "descripcion");
                List<Segmento> segmentoElegidos = segmentoServicio.GetAllSegmentosDelUsuario(usuarioLogueado);
                ViewBag.ListasegmentosElegidos = new MultiSelectList(segmentoElegidos, "id", "descripcion");
                return View(usuarioLogueado);
            }


        }


        [HttpGet]
        public ActionResult RegistrarFacebook(Usuario usuario, string Mensaje)
        {
            ViewBag.HayValidaciones = false;

            if (Mensaje != null)
            {
                ViewBag.HayValidaciones = true;
                ViewBag.Mensaje = Mensaje;

            }

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");

            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");

            return View();

        }


        [HttpGet]
        public ActionResult PerfilEntidad(Usuario usuario)
        {
            var usuarioLogueado = usuario;
            if (usuarioLogueado.Id == 0)
            {
                var buscarUsuarioLogueado = Session["Usuario"] as Usuario; //obtengo usuario logueado
                if (buscarUsuarioLogueado == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    buscarUsuarioLogueado = usuarioServicio.GetById(buscarUsuarioLogueado.Id);

                    if (buscarUsuarioLogueado.UpdatedAt != null)
                    {
                        ViewBag.UltimaModificacion = buscarUsuarioLogueado.UpdatedAt.ToString().Remove(11);
                    }
                    else
                    {
                        ViewBag.UltimaModificacion = "";
                    }

                    return View(buscarUsuarioLogueado);
                }

            }
            else
            {
                usuarioLogueado = usuarioServicio.GetById(usuario.Id);

                if (usuarioLogueado.UpdatedAt != null)
                {
                    ViewBag.UltimaModificacion = usuarioLogueado.UpdatedAt.ToString().Remove(11);
                }
                else
                {
                    ViewBag.UltimaModificacion = "";
                }

                return View(usuarioLogueado);
            }
        }

        [HttpGet]
        public ActionResult IraModificarPerfilUsuario()
        {

            var usuario = Session["Usuario"] as Usuario;
            usuario = usuarioServicio.GetById(usuario.Id);

            if (usuario.UpdatedAt != null)
            {
                ViewBag.UltimaModificacion = usuario.UpdatedAt.ToString().Remove(11);
            }
            else
            {
                ViewBag.UltimaModificacion = "";
            }

            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            List<CheckedViewModel> ListaSegmentosUsuario = new List<CheckedViewModel>();

            foreach (var item in segmentos)
            {
                CheckedViewModel segmento = new CheckedViewModel();
                segmento.Id = item.Id;
                segmento.Descripcion = item.Descripcion;

                foreach (var segUsu in usuario.UsuarioSegmento)
                {
                    if (item.Id == segUsu.SegmentoId)
                    {
                        segmento.Cheked = true;
                    }
                }

                ListaSegmentosUsuario.Add(segmento);

            }
            ViewBag.ListaSegmentosUsuario = ListaSegmentosUsuario;

            List<Localidad> localidades = localidadServicio.GetAllLocalidades();
            ViewBag.ListaLocalidades = new MultiSelectList(localidades, "id", "descripcion");

            List<Categoria> categorias = categoriaServicio.GetAllCategorias();
            List<CheckedViewModel> ListaCategoriasUsuario = new List<CheckedViewModel>();

            foreach (var item in categorias)
            {
                CheckedViewModel categoria = new CheckedViewModel();

                categoria.Id = item.Id;
                categoria.Descripcion = item.Descripcion;

                foreach (var cateUsu in usuario.UsuarioCategoriaElegida)
                {
                    if (item.Id == cateUsu.CategoriaId)
                    {
                        categoria.Cheked = true;
                    }
                }

                ListaCategoriasUsuario.Add(categoria);

            }

            ViewBag.ListaInteresesUsuario = ListaCategoriasUsuario;

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");
            ViewBag.ProvinciaId = usuario.Localidad.Departamento.ProvinciaId;

            ViewBag.LocalidadId = usuario.LocalidadId;
            ViewBag.LocalidadDescripcion = usuario.Localidad.Descripcion;

            ViewBag.DepartamentId = usuario.Localidad.DepartamentoId;
            ViewBag.DesDepartamento = usuario.Localidad.Departamento.Descripcion;

            return View(usuario);

        }


        [HttpPost]
        public ActionResult ModificarPerfilUsuario(UsuarioModificarViewModel userViewModel)
        {
            var usua = new Usuario();
            if (ModelState.IsValid)
            {

                usuarioServicio.ModificarUsuario(userViewModel);
                usua = usuarioServicio.GetById(userViewModel.Id);

                if (userViewModel.RolId == 1)
                {
                    return RedirectToAction("PerfilUsuario", "Usuario", usua);
                }
                else
                {
                    return RedirectToAction("PerfilEntidad", "Usuario", usua);
                }


            }
            else
            {
                return View(usua);
            }
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            {

                var usuario = Session["Usuario"] as Usuario;
                var events = actividadServicio.GetAllActividadByUsuario(usuario);
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult Calendario()
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
        public ActionResult IraModificarPerfilEntidad()
        {

            var usuario = Session["Usuario"] as Usuario;
            usuario = usuarioServicio.GetById(usuario.Id);

            if (usuario.UpdatedAt != null)
            {
                ViewBag.UltimaModificacion = usuario.UpdatedAt.ToString().Remove(11);
            }
            else
            {
                ViewBag.UltimaModificacion = "";
            }

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            List<CheckedViewModel> ListaSegmentosUsuario = new List<CheckedViewModel>();

            foreach (var item in segmentos)
            {
                CheckedViewModel segmento = new CheckedViewModel();
                segmento.Id = item.Id;
                segmento.Descripcion = item.Descripcion;

                foreach (var segUsu in usuario.UsuarioSegmento)
                {
                    if (item.Id == segUsu.SegmentoId)
                    {
                        segmento.Cheked = true;
                    }
                }

                ListaSegmentosUsuario.Add(segmento);

            }
            ViewBag.ListaSegmentosUsuario = ListaSegmentosUsuario;

            List<Categoria> categorias = categoriaServicio.GetAllCategorias();
            List<CheckedViewModel> ListaCategoriasUsuario = new List<CheckedViewModel>();

            foreach (var item in categorias)
            {
                CheckedViewModel categoria = new CheckedViewModel();

                categoria.Id = item.Id;
                categoria.Descripcion = item.Descripcion;

                foreach (var cateUsu in usuario.UsuarioCategoriaElegida)
                {
                    if (item.Id == cateUsu.CategoriaId)
                    {
                        categoria.Cheked = true;
                    }
                }

                ListaCategoriasUsuario.Add(categoria);

            }

            ViewBag.ListaRubroEntidad = ListaCategoriasUsuario;

            List<Provincia> provincias = localidadServicio.GetAllProvincias();
            ViewBag.ListaProvincia = new MultiSelectList(provincias, "id", "descripcion");
            ViewBag.ProvinciaId = usuario.Localidad.Departamento.ProvinciaId;

            ViewBag.LocalidadId = usuario.LocalidadId;
            ViewBag.LocalidadDescripcion = usuario.Localidad.Descripcion;

            ViewBag.DepartamentId = usuario.Localidad.DepartamentoId;
            ViewBag.DesDepartamento = usuario.Localidad.Departamento.Descripcion;

            return View(usuario);

        }
    }
}