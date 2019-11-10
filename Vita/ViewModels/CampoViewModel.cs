using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class CampoViewModel
    {
        public string Nombre { get; set; }
        public int FormularioDinamicoId { get; set; }
        public int TipoDatoCampoId { get; set; }
        public bool Obligatorio { get; set; }
    }
}