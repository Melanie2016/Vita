using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class RespuestaViewModel
    {
  
        public int ActividadId { get; set; }
        public int FormularioDinamicoId { get; set; }
        public int CamposId { get; set; }
        public int UsuarioId { get; set; }

        public DateTime RespuestaDate { get; set; }

        public string RespuestaTextoCorto { get; set; }
        public string RespuestaTextoLargo { get; set; }
        public int RespuestaNumero { get; set; }

        public string RespuestaFoto { get; set; }
        public HttpPostedFileBase Foto { get; set; }

    }

}