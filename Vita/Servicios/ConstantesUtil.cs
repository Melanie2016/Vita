using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class ConstantesUtil
    {
        // ESTADOS 
        public const int ESTADO_APROBADO = 1;
        public const int ESTADO_PENDIENTE = 2;
        public const int ESTADO_CANCELADO = 3;
        public const int ESTADO_RECHAZADO = 4;
        public const int ESTADO_ACTIVIDAD_FINALIZADA = 5;
        public const int ESTADO_ACTIVIDAD_CREADA = 6;
        public const int ESTADO_ACTIVIDAD_PUBLICADA = 7;


        //EXTRAS
        public const int ESTADISTICA_CATEGORIA = 1;
        public const int ESTADISTICA_SEMANA = 2;
    }

}