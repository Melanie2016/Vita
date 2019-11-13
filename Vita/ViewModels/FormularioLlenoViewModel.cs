using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class FormularioLlenoViewModel
    {
        public FormularioLlenoViewModel()
        {
            CamposVm = new List<RespuestaViewModel>();
        }
        public List<RespuestaViewModel> CamposVm { get; set; }


    }
}