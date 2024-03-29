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
    
    public partial class Domicilio
    {
        public int Id { get; set; }
        public string NombreCalle { get; set; }
        public Nullable<int> NumeroCalle { get; set; }
        public Nullable<int> NumeroPiso { get; set; }
        public Nullable<int> NumeroDepartamento { get; set; }
        public string CodigoPostal { get; set; }
        public Nullable<int> LocalidadId { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<int> ActividadId { get; set; }
        public Nullable<System.DateTime> FechaRegistroEnDb { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual Actividad Actividad { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
