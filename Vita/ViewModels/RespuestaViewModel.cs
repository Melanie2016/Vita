using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class RespuestaViewModel
    {
        public int CamposId { get; set; }
        public int UsuarioId { get; set; }

        public DateTime RespuestaDate { get; set; }
        public string RespuestaTexto { get; set; }

        public int RespuestaNumero { get; set; }
    }
}