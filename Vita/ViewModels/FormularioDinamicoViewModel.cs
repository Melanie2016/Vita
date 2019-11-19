using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class FormularioDinamicoViewModel
    {


        public FormularioDinamicoViewModel()
        {
            CamposVm = new List<CampoViewModel>();
        }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int ActividadId { get; set; }
        public int EntidadId { get; set; }
        public List<CampoViewModel> CamposVm { get; set; }
        public bool publicar { get; set; }


       

        //public string Nombre { get; set; }
        //public int FormularioDinamicoId { get; set; }
        //public int TipoDatoCampoId { get; set; }
        //public bool Obligatorio { get; set; }

     //   public List<Campos> Camposvi { get; set; }

       


    }
}






