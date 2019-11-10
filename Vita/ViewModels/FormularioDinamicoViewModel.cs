using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class FormularioDinamicoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int ActividadId { get; set; }
        public int EntidadId { get; set; }

        public string Nombre { get; set; }
        public int FormularioDinamicoId { get; set; }
        public int TipoDatoCampoId { get; set; }
        public bool Obligatorio { get; set; }

     //   public List<CampoViewModel> Campo { get; set; }

       


    }
}