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
    }
}