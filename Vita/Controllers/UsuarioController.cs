﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vita.Servicios;

namespace Vita.Controllers
{
    public class UsuarioController: Controller
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private VitaEntities myDbContext = new VitaEntities();
       
         [HttpGet]
        public ActionResult Registro()
        {
            List<Sexo> sexos = sexoServicio.GetAllSexo();
            ViewBag.ListaSexo = new MultiSelectList(sexos, "id", "descripcion");

            List<Segmento> segmentos = segmentoServicio.GetAllSegmento();
            ViewBag.ListaSegmentos = new MultiSelectList(segmentos, "id", "descripcion");

            List<Localidad> localidades = localidadServicio.GetAllLocalidades();
            ViewBag.ListaLocalidades = new MultiSelectList(localidades, "id", "descripcion");

            List<Categoria> rubros = categoriaServicio.GetAllCategorias();
            ViewBag.ListaRubro = new MultiSelectList(rubros, "id", "descripcion");

            List<Categoria> intereses = categoriaServicio.GetAllCategorias();
            ViewBag.ListaIntereses = new MultiSelectList(intereses, "id", "descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario, int[] selectedSegmento, int[] selectedCategoria)
        {
            var nombreDeUsuarioExiste=usuarioServicio.VerificarExistenciaUsuarioNombre(usuario);
            var existeElUsuario = usuarioServicio.VerificarExistenciaDelUsuario(usuario);
            if (nombreDeUsuarioExiste != null)
            {
                //ACA DEBERIA DECIR, SU El nombre de usuario ya existe ingrese otro nombre de usuario  
                return RedirectToAction("Login", "Login");
            }
            else if(existeElUsuario !=null)
            {
                //ACA DEBERIA DECIR, su usuario ya existe 
                return RedirectToAction("Login", "Login");
            }
            else {
                usuarioServicio.CrearUsuario(usuario);
                if (usuario.RolId == 1)
                {
                    usuarioServicio.CrearUsuarioSegmento(usuario.Id, selectedSegmento);
                    usuarioServicio.CrearUsuarioCategoriaElegida(usuario.Id, selectedCategoria);
                    return RedirectToAction("PerfilUsuario", "Usuario", usuario);
                }
                else
                {
                    return RedirectToAction("PerfilEntidad", "Usuario", usuario);
                }
            }
 
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
                    return View(buscarUsuarioLogueado);
                }
                
            }
            else
            {
                return View(usuarioLogueado);
            }


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
                    return View(buscarUsuarioLogueado);
                }

            }
            else
            {
                return View(usuarioLogueado);
            }
        }
    }
}