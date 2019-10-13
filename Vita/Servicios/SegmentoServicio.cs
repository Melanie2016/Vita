using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class SegmentoServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Segmento Get(int segmentoId)
        {
            return myDbContext.Segmento.Find(segmentoId);

        }
        public List<Segmento> GetAllSegmento()
        {
            return myDbContext.Segmento.OrderBy(x => x.Id).ToList();
        }
        public List<Segmento> GetAllSegmentosDelUsuario(Usuario usuario)
        {
            var segmentos = new List<Segmento>();
            if (usuario != null)
            {
                var listUsuarioSegmento = myDbContext.UsuarioSegmento.Where(x => x.UsuarioId == usuario.Id).ToArray();

                foreach (var userseg in listUsuarioSegmento)
                {

                    segmentos.AddRange(myDbContext.Segmento.Where(x => x.Id == userseg.SegmentoId).ToList());

                }
            }

            return segmentos;
        }
    }
}