//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vita
{
    using System;
    using System.Collections.Generic;
    
    public partial class InscripcionFecha
    {
        public int Id { get; set; }
        public Nullable<int> UsuarioInscriptoActividadId { get; set; }
        public Nullable<int> FechaActividadId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual FechaActividad FechaActividad { get; set; }
        public virtual UsuarioInscriptoActividad UsuarioInscriptoActividad { get; set; }
    }
}
