using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class CategoriaServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Categoria GetCategoriaById(int categoriaId)
        {
            var cate= myDbContext.Categoria.Where(x => x.Id == categoriaId).FirstOrDefault();
            return cate;
        }
        public List<Categoria> GetAllCategorias()
        {
            return myDbContext.Categoria.OrderBy(x=>x.Id).ToList();
        }
        public List<SubCategoria> GetAllSubCategoriasByCategoriaId(int? categoriaId)
        {
            return myDbContext.SubCategoria.Where(x => x.CategoriaId == categoriaId).ToList();
        }
        public List<SubCategoria> GetAllSubCategorias()
        {
            return myDbContext.SubCategoria.OrderBy(x => x.Id).ToList();
        }
        public List<Categoria> GetAllCategoriasDelUsuario(Usuario usuario)
        {
            var categorias = new List<Categoria>();
            if (usuario != null)
            {
                var listUsuarioCategoria = myDbContext.UsuarioCategoriaElegida.Where(x => x.UsuarioId == usuario.Id).ToArray();
                
                foreach (var usercate in listUsuarioCategoria)
                {

                    categorias.AddRange(myDbContext.Categoria.Where(x => x.Id == usercate.CategoriaId).ToList());

                }
            }
          
            return categorias;
        }

    }
    
      
}