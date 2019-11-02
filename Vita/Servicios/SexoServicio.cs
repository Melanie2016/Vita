using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class SexoServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Sexo GetSexoId(int sexoId)
        {
           return myDbContext.Sexo.Where(x => x.Id == sexoId).FirstOrDefault();
        }
        public List<Sexo> GetAllSexo()
        {
            return myDbContext.Sexo.OrderBy(x => x.Id).ToList();

        }
    }
}