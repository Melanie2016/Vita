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
     
        private VitaEntities myDbContext = new VitaEntities();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        //private BuscardorServicio buscardorServicio = new BuscardorServicio();
        private ActividadServicio actividadServicio = new ActividadServicio();
        private EventoServicio eventoServicio = new EventoServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Sugerencias()
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
        public ActionResult Buscador()
        {
            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Buscador(int SegmentoId)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario; //obtengo usuario logueado
            if (usuarioLogueado == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var listaActividadPorSegmento = actividadServicio.GetAllActividadBySegmentoId(SegmentoId); //busco las actividades por ese segmento
                if (listaActividadPorSegmento.Count == 0)//si no encontre deberia mostrar un mensaje
                {
                    var segmento = segmentoServicio.Get(SegmentoId).Descripcion;

                    ViewBag.SegmentoNoEncontrado = "No se encontro actividades por " + segmento;
                    //Por alguna razon no muestra los mensajes :( 
                    return RedirectToAction("Buscador", "Home");
                }
                else
                {//si encontro ENTRA ACA
                 //SE CREAN LISTA PARA ALMACENAR LAS ACTIVIDADES QUE TIENEN EN COMUN CON EL USUARIO
                    var listaPorLocalidad = new List<Actividad>();
                    var listaPorInterese = new List<Actividad>();
                    var listaMasPopulares = new List<Actividad>();
                    var categoriasDelUsuario = categoriaServicio.GetAllCategoriasDelUsuario(usuarioLogueado);//obtenemos la lista de categorias por el usuario
                    foreach (var actividad in listaActividadPorSegmento) //recorremos las lista obtenidas por el segmento elegido
                    {
                        foreach (var cate in categoriasDelUsuario)//recorremos las categorias del usuario
                        {
                            if (actividad.CategoriaId == cate.Id)//comparamos el id de la categoria que tiene el usuario con la de la actividad
                            {
                                listaPorInterese.Add(actividad);//agregamos a la lista de intereses esa actividad
                            }
                        }
                        if (actividad.LocalidadId == usuarioLogueado.LocalidadId)//comparamos la localidad del usuario y de la actividad
                        {
                            listaPorLocalidad.Add(actividad);//agregamos a la lista de localidad
                        }

                        //if (listaActividadPorSegmento == popular) hay que plantearlo bien
                        //{
                        //listaMasPopulares.Add(actividad);
                        //}

                    }
                    if (listaPorLocalidad.Count != 0)//verificamos que cada lista tenga valor para agregar a los viewBag
                    {
                        ViewBag.ListaPorLocalidad = listaPorLocalidad;
                    }
                    if (listaPorInterese.Count != 0)
                    {
                        ViewBag.ListaPorInterese = listaPorInterese;
                    }
                    if (listaMasPopulares.Count != 0)
                    {
                        ViewBag.ListaMasPopulares = listaMasPopulares;
                    }
                    return RedirectToAction("Buscador", "Home", listaActividadPorSegmento);//igual le pasamos todas las actividades por el segmento
                }

            }
        }
    }
}