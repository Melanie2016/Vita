﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vita.Servicios;

namespace Vita.Controllers
{
    public class EventoController: Controller
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private VitaEntities myDbContext = new VitaEntities();

        [HttpGet]
        public ActionResult CrearEvento()
        {
            var buscarUsuarioLogueado = Session["Usuario"] as Usuario; //obtengo usuario logueado
            if(buscarUsuarioLogueado == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                return View(buscarUsuarioLogueado);

            }
        }
        [HttpPost]
        public ActionResult CreacionEvento(Evento evento)
        {
            //obtengo usuario logueado
            if (!(Session["Usuario"] is Usuario buscarUsuarioLogueado))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                buscarUsuarioLogueado = usuarioServicio.GetUsuarioById(buscarUsuarioLogueado.Id);
                return RedirectToAction("PerfilEntidad", "Usuario", buscarUsuarioLogueado);

            }
        }


        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult ModificarEvento()
        {
            return View();
        }
        public ActionResult ListaEventos()
        {
            return View();
        }
        public ActionResult FichaEvento()
        {
            return View();
        }
    }
}