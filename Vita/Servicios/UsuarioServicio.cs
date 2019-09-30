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
        public Usuario GetById(int id)
        {
            return myDbContext.Usuario.FirstOrDefault(x => x.Id == id);
        }
        public Usuario VerificarExistenciaUsuario(Usuario u)
        {
         
                if (u.Email != null)
                {
                    var user = myDbContext.Usuario.Where((us => us.Email.Equals(u.Email) && us.Pass.Equals(u.Pass))).FirstOrDefault();
                    return user;
                }
                else
                {
                    var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName) && us.Pass.Equals(u.Pass)).FirstOrDefault();
                    return user;
                }     
        }
    }
}