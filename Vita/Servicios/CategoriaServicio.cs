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
            return myDbContext.Categoria.OrderBy(x=>x.Id).ToList();
        
        }
        public List<Categoria> GetAllCategoriasDelUsuario(Usuario usuario)
        {
            var categorias = new List<Categoria>();
            if (usuario != null)
            {
                var listUsuarioCategoria = myDbContext.UsuarioCategoria.Where(x => x.UsuarioId == usuario.Id).ToArray();
                
                foreach (var usercate in listUsuarioCategoria)
                {

                    categorias.AddRange(myDbContext.Categoria.Where(x => x.Id == usercate.CategoriaId).ToList());

                }
            }
          
            return categorias;
        }

    }
    
      
}