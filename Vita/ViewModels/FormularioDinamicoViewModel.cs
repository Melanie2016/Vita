using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class FormularioDinamicoViewModel
    {
        public string TituloFormulario { get; set; }
        public string DescripcionFormulario { get; set; }
        public int TipoPreguntaId { get; set; }
        public List<ConsignaViewModel> consignas {get; set;}
    }
}