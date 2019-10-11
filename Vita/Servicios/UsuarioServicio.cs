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
        public Usuario VerificarLogin(Usuario u)
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

        public Usuario VerificarExistenciaUsuarioNombre(Usuario u)
        {
            var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName)).FirstOrDefault();
            return user;
        }

        public Usuario VerificarExistenciaDelUsuario(Usuario u)
        {
            if (u.Dni.HasValue)//en caso de ser un usuario
            {
                // var user = myDbContext.Usuario.Where(us => us.Dni.HasValue.Equals(u.Dni.HasValue)).FirstOrDefault();
                var user = myDbContext.Usuario.Where(us => us.Dni ==u.Dni).FirstOrDefault();

                return user;

            }
            else
            {
                var user = myDbContext.Usuario.Where(us => us.UsuarioName.Equals(u.UsuarioName) && us.SitioWeb.Equals(u.SitioWeb)).FirstOrDefault();
                return user;

            }

        }


        //public void CrearUsuarioCategoriaId(List<Categoria> categorias, long usuarioId)
        //{
        //    //falta validar tooodo
        //    List<UsuarioCategoriaElegida> ListaUsuarioCategoriaElegidas = new List<UsuarioCategoriaElegida>();
        //    foreach(var categoria in categorias)
        //    {
        //        var usuarioCategoriaElegida = new UsuarioCategoriaElegida();
        //        usuarioCategoriaElegida.UsuarioId = usuarioId;
        //        usuarioCategoriaElegida.CategoriaId = categoria.Id;
        //        ListaUsuarioCategoriaElegidas.Add(usuarioCategoriaElegida);

        //    }

        //    myDbContext.UsuarioCategoriaElegida.Add(ListaUsuarioCategoriaElegidas);
        //    myDbContext.SaveChanges();
        //}
        public void CrearUsuarioSegmento(int segmentoId, int usuarioId)
        {
         

            var usuarioSegmento = new UsuarioSegmento();
            usuarioSegmento.UsuarioId = usuarioId;
            usuarioSegmento.SegmentoId = segmentoId;
 
            myDbContext.UsuarioSegmento.Add(usuarioSegmento);
            myDbContext.SaveChanges();


            //List<UsuarioSegmento> ListaUsuarioSegmento = new List<UsuarioSegmento>();
            //foreach (var segmento in segmentos)
            //{
            //    var usuarioSegmento = new UsuarioSegmento();
            //    usuarioSegmento.UsuarioId = usuarioId;
            //    usuarioSegmento.SegmentoId = segmento.Id;
            //    ListaUsuarioSegmento.Add(usuarioSegmento);
            //    myDbContext.UsuarioSegmento.Add(usuarioSegmento);
            //    myDbContext.SaveChanges();
            //}


        }
    }
}