﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class ActividadServicio
    {
        private VitaEntities myDbContext = new VitaEntities();
        public Actividad GetActividad(int ActividadId)//por id de actividad
        {
            return myDbContext.Actividad.Find(ActividadId);
        }
        public List<Actividad> GetAllActividadByRolEntidadId(int usuarioId) //lista de activiades por entidad id
        {
            return myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId).ToList();
        }
        public List<Actividad> GetAllActividadByRolUsuarioId(int usuarioId) //lista de activiades por usuario inscripto id
        {
            var listaActividad = new List<Actividad>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId).ToList();

            foreach (var actividadInscriptoUser in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(myDbContext.Actividad.Where(x => x.Id == actividadInscriptoUser.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }
        public List<Usuario> GetAllActividadUsuarioInscriptoByActividadId(int actividadId) //lista de activiades por usuario inscripto id
        {
            var listaActividad = new List<Usuario>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId).ToList();

            foreach (var actividadInscriptoUser in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(myDbContext.Usuario.Where(x => x.Id == actividadInscriptoUser.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }

        public List<Actividad> GetAllActividadBySegmentoId(long id)
        {
            var listaActividad = new List<Actividad>();
            var ListaActividadSegmento = myDbContext.ActividadSegmento.Where(x => x.SegmentoId == id).ToList();

            foreach (var actividadsegmento in ListaActividadSegmento)
            {
                listaActividad.Add(myDbContext.Actividad.Where(x => x.Id == actividadsegmento.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }
        public void CrearActividad(Actividad actividad, Usuario usuario, int[] selectedSegmento)
        {
            Actividad actividadNueva = new Actividad
            {
                Titulo = actividad.Titulo,
                Descripcion = actividad.Descripcion,
                EdadMinima = actividad.EdadMinima,
                EdadMaxima = actividad.EdadMaxima,
                Precio = actividad.Precio,
                FechaDesde = actividad.FechaDesde,
                FechaHasta = actividad.FechaHasta,
                CantidadDias = actividad.CantidadDias,
                CantidadCupo = actividad.CantidadCupo,
                CategoriaId = actividad.CategoriaId,
                SubcategoriaId = actividad.SubcategoriaId,
                LocalidadId = actividad.LocalidadId,
                UsuarioId = usuario.Id,
                // Foto= actividad.Foto una actividad puede tener varias fotos
                CreatedAt = DateTime.Now
            };
            myDbContext.Actividad.Add(actividadNueva);
            myDbContext.SaveChanges();
            this.CrearSegmentoActividad(actividadNueva.Id, selectedSegmento);
           
        }
        public void CrearSegmentoActividad(int actividadId, int[] selectedSegmento)
        {
            foreach (var segmento in selectedSegmento)
            {
                var actvidadSegmento = new ActividadSegmento
                {
                    ActividadId = actividadId,
                    SegmentoId = segmento,
                    CreatedAt = DateTime.Now
                };
                myDbContext.ActividadSegmento.Add(actvidadSegmento);
                myDbContext.SaveChanges();
            }
        }

        public List<Actividad> GetBusquedaAvanzada(string textoIngresado)
        {
            var lista = new List<Actividad>();
            lista = myDbContext.Actividad.Where(x => x.Titulo.Contains(textoIngresado) || (x.Descripcion.Contains(textoIngresado))).ToList();
            return lista;
        }
    }
}