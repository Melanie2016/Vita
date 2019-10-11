﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class UsuarioServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Usuario GetUsuarioById(long id)
        {
            return myDbContext.Usuario.Find(id);
        }

        public void CrearUsuario(Usuario usuario)
        {
            //falta validar tooodo
            Usuario usuarioNuevo = usuario;
            myDbContext.Usuario.Add(usuarioNuevo);
            myDbContext.SaveChanges();
        }
        public Usuario GetById(int id)
        {
            return myDbContext.Usuario.FirstOrDefault(x => x.Id == id);
        }
        public Usuario VerificarLogin(Usuario u)
        {
         
                if (u.Email != null)
                {
                    var user = myDbContext.Usuario.Where((us => us.Email.Equals(u.Email) && us.Pass.Equals(u.Pass))).FirstOrDefault();
                    return user;
                }
                else
                {
                    var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName) && us.Pass.Equals(u.Pass)).FirstOrDefault();
                    return user;
                }     
        }

        public Usuario VerificarExistenciaUsuarioNombre(Usuario u)
        {
            var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName)).FirstOrDefault();
            return user;
        }

        public Usuario VerificarExistenciaDelUsuario(Usuario u)
        {
            if (u.Dni.HasValue)//en caso de ser un usuario
            {
                var user = myDbContext.Usuario.Where(us => us.Dni ==u.Dni).FirstOrDefault();
                return user;
            }
            else
            {
                var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName) && us.SitioWeb.Equals(u.SitioWeb)).FirstOrDefault();
                return user;
            }
        }

        public void CrearUsuarioSegmento(int usuarioId, int[] selectedSegmento)
        {

            foreach (var segmento in selectedSegmento)
            {
                var usuarioSegmento = new UsuarioSegmento
                {
                    UsuarioId = usuarioId,
                    SegmentoId = segmento,
                    FechaCreacion = DateTime.Now
                };
                myDbContext.UsuarioSegmento.Add(usuarioSegmento);
                myDbContext.SaveChanges();
            }
        }
        public void CrearUsuarioCategoriaElegida(int usuarioId, int[] selectedCategoria)
        {
            foreach (var categoria in selectedCategoria)
            {
                var usuarioCategoriaElegida = new UsuarioCategoria
                {
                    UsuarioId = usuarioId,
                    CategoriaId = categoria 
                };
                myDbContext.UsuarioCategoria.Add(usuarioCategoriaElegida);
                myDbContext.SaveChanges();
            }
        }
      
    }
}