using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class ActividadFechaViewModel
    {
        public int ActividadId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int DiaSemana { get; set; }
        public string InicioEvento { get; set; }
        public string FinEvento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

    }
}