using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class ActividadFechaViewModel
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Descripcion { get; set; }
    }
}