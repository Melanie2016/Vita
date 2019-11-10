using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class FormularioDinamicoViewModel
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int ActividadId { get; set; }
        public int EntidadId { get; set; }
        public List<CampoViewModel> Campos {get; set;}

    }
}