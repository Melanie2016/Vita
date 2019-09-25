using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class EntidadServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

  
        public void CrearEmpresa(Entidad entidad)
        {
            //falta validar tooodo
            Entidad entidadNueva = entidad;
            myDbContext.Entidad.Add(entidadNueva);
            myDbContext.SaveChanges();
        }

    }
}