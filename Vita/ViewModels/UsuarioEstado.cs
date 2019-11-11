using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class UsuarioEstado
    {
        public UsuarioEstado()
        {
            Usuarios = new List<Usuario>();
        }
        public int UsuarioId { get; set; }
        public bool Estado { get; set; }
        public int ActividadId { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public int EstadoAnterior { get; set; }
    }
}