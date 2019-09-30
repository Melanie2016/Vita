using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class LocalidadServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public List<Localidad> GetAllLocalidades()
        {
            return myDbContext.Localidad.OrderBy(x => x.Descripcion).ToList();

        }
    }
}