using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class UsuarioServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Usuario GetUsuarioById(long id)
        {
            return myDbContext.Usuario.Find(id);
        }

        public void CrearUsuario(Usuario usuario)
        {
            //falta validar tooodo
            //usuario.Categoria.ToList();
            Usuario usuarioNuevo = usuario;
            myDbContext.Usuario.Add(usuarioNuevo);
            myDbContext.SaveChanges();
        }

    }
}