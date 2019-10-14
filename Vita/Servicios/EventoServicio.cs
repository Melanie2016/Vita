using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class EventoServicio
    {
        private VitaEntities myDbContext = new VitaEntities();
        public Evento GetEvento(int eventoId)//por id de evento
        {
            return myDbContext.Evento.Find(eventoId);
        }
        public List<Evento> GetAllEventoByRolEntidadId(int usuarioId) //lista de evento por entidad id
        {
            return myDbContext.Evento.Where(x => x.UsuarioId == usuarioId).ToList();
        }
        public List<Evento> GetAllEventoByRolUsuarioId(int usuarioId) //lista de activiades por usuario inscripto id
        {
            var listaEvento = new List<Evento>();
            var listaUsuarioInscriptoEvento = myDbContext.UsuarioInscriptoEvento.Where(x => x.UsuarioId == usuarioId).ToList();

            foreach (var eventoInscriptoUser in listaUsuarioInscriptoEvento)
            {
                listaEvento.Add(myDbContext.Evento.Where(x => x.Id == eventoInscriptoUser.EventoId).FirstOrDefault());
            }
            return listaEvento;
        }
        public List<Evento> GetAllEventoBySegmentoId(long segmentoId)
        {
            var listaEvento = new List<Evento>();
            var listaEventoSegmento = myDbContext.EventoSegmento.Where(x => x.SegmentoId == segmentoId).ToList();

            foreach (var eventosegmento in listaEventoSegmento)
            {
                listaEvento.Add(myDbContext.Evento.Where(x => x.Id == eventosegmento.EventoId).FirstOrDefault());
            }
            return listaEvento;
        }
        public void CrearEvento(Evento evento, Usuario usuario)
        {
            Evento eventoNuevo = new Evento
            {
                Titulo = evento.Titulo,
                Descripcion = evento.Descripcion,
                UsuarioId = usuario.Id,
                Precio = evento.Precio,
                FechaDesde = evento.FechaDesde,
                FechaHasta = evento.FechaHasta,
                CantidadDias = evento.CantidadDias,
                CantidadCupo = evento.CantidadCupo,
                LocalidadId = evento.LocalidadId,
                // Foto= actividad.Foto una actividad puede tener varias fotos
                CreatedAt = DateTime.Now
                //EdadMinima = evento.EdadMinima,
                //EdadMaxima = evento.EdadMinima,
                //CategoriaId = evento.CategoriaId,
                //SubcategoriaId = evento.SubcategoriaId,
            };
            myDbContext.Evento.Add(eventoNuevo);
            myDbContext.SaveChanges();
        }
    }
}