﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vita.ViewModels;

namespace Vita.Servicios
{
    public class UsuarioServicio
    {
        private VitaEntities myDbContext = new VitaEntities();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private SegmentoServicio segmentoServicio = new SegmentoServicio();
        private SexoServicio sexoServicio = new SexoServicio();
        public Usuario GetUsuarioById(long id)
        {
            return myDbContext.Usuario.Find(id);
        }
        

        public void CrearUsuario(Usuario usuario)
        {
            //falta validar tooodo
            if(usuario.LocalidadId== null)
            {
                usuario.LocalidadId = 3;
            }
            Usuario usuarioNuevo = usuario;
            usuarioNuevo.CreatedAt = DateTime.Now;
            myDbContext.Usuario.Add(usuarioNuevo);
            myDbContext.SaveChanges();
        }
        public Usuario GetById(int id)
        {
            var usuario= myDbContext.Usuario.FirstOrDefault(x => x.Id == id);
            
            if(usuario.Localidad == null)
            {
                usuario.Localidad = localidadServicio.GetLocalidadById(usuario.LocalidadId.Value);
            }
            if(usuario.Sexo == null && usuario.RolId == 1)
            {
                usuario.Sexo = sexoServicio.GetSexoId(usuario.SexoId.Value);
            }
            return usuario;
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
                    CreatedAt = DateTime.Now
                };
                myDbContext.UsuarioSegmento.Add(usuarioSegmento);
                myDbContext.SaveChanges();
            }
        }
        public void CrearUsuarioCategoriaElegida(int usuarioId, int[] selectedCategoria)
        {
            foreach (var categoria in selectedCategoria)
            {
                var usuarioCategoriaElegida = new UsuarioCategoriaElegida
                {
                    UsuarioId = usuarioId,
                    CategoriaId = categoria,
                    CreatedAt=DateTime.Now
                };
                myDbContext.UsuarioCategoriaElegida.Add(usuarioCategoriaElegida);
                myDbContext.SaveChanges();
            }
        }
        public void ModificarUsuario(UsuarioModificarViewModel us)
        {

            Usuario usuarioModificar = myDbContext.Usuario.Find(us.Id);
            usuarioModificar.Nombre = us.Nombre;
            usuarioModificar.Apellido = us.Apellido;
            usuarioModificar.Dni = us.Dni;
            usuarioModificar.UpdatedAt = DateTime.Now;
            usuarioModificar.SexoId = us.SexoId;
            usuarioModificar.SobreMi = us.SobreMi;
            usuarioModificar.UsuarioName = us.UsuarioName;
            usuarioModificar.Celular = us.Celular;
            usuarioModificar.FechaNacimiento = us.FechaNacimiento;
            usuarioModificar.Email = us.Email;
            usuarioModificar.LocalidadId = us.LocalidadId;
            usuarioModificar.Pass = us.Pass;
   

            var segmentousuario = myDbContext.UsuarioSegmento.Where(x => x.UsuarioId == us.Id).ToList();
            var listaUsuarioSegmento = new List<UsuarioSegmento>();
            foreach (var segmentoUser in segmentousuario)
            {
                foreach (var segmento in us.selectedSegmento)//la lista con los segmento elegidos actualizados
                {
                    if (!(segmentoUser.SegmentoId== segmento))
                    {
                        var usuariosegmentoNuevo = new UsuarioSegmento
                        {
                            SegmentoId = segmento,
                            UsuarioId = us.Id,
                            CreatedAt = DateTime.Now
                        };
                        listaUsuarioSegmento.Add(usuariosegmentoNuevo);


                    }
                }       
            }
            myDbContext.UsuarioSegmento.AddRange(listaUsuarioSegmento);
            myDbContext.SaveChanges();
        }


    }
}