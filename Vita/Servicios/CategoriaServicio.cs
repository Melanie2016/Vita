using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class CategoriaServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public List<Categoria> GetAllCategorias()
        {
            return myDbContext.Categoria.OrderBy(x=>x.id).ToList();
        
        }

    }
    
      
}