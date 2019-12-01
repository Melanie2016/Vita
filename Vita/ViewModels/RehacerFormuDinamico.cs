using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class RehacerFormuDinamico
    {
        public RehacerFormuDinamico()
        {
            CamposRehacer = new List<CampoRehacerViewModel>();
        }
        public List<CampoRehacerViewModel> CamposRehacer { get; set; }

        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int UsuarioId { get; set; }
        public int FormularioDinamicoId { get; set; }
        public int ActividadId { get; set; }
        public string DescripcionMotivo { get; set; }



    }
}