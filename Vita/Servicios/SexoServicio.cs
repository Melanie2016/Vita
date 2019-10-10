using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class SexoServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public List<Sexo> GetAllSexo()
        {
            return myDbContext.Sexo.OrderBy(x => x.Id).ToList();

        }
    }
}