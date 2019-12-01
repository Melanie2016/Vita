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
    
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            this.FechaActividad = new HashSet<FechaActividad>();
            this.FormularioDinamico = new HashSet<FormularioDinamico>();
            this.Respuesta = new HashSet<Respuesta>();
            this.MotivoRechazoFormDinamico = new HashSet<MotivoRechazoFormDinamico>();
            this.ActividadSegmento = new HashSet<ActividadSegmento>();
            this.UsuarioInscriptoActividad = new HashSet<UsuarioInscriptoActividad>();
            this.Domicilio = new HashSet<Domicilio>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int EdadMinima { get; set; }
        public Nullable<int> EdadMaxima { get; set; }
        public Nullable<int> Precio { get; set; }
        public int CantidadCupo { get; set; }
        public int CategoriaId { get; set; }
        public int SubcategoriaId { get; set; }
        public int LocalidadId { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public string Foto { get; set; }
        public string Url { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public Nullable<bool> ConUsuarioPendiente { get; set; }
        public int EstadoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FechaActividad> FechaActividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormularioDinamico> FormularioDinamico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuesta> Respuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MotivoRechazoFormDinamico> MotivoRechazoFormDinamico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActividadSegmento> ActividadSegmento { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioInscriptoActividad> UsuarioInscriptoActividad { get; set; }
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Domicilio> Domicilio { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Localidad Localidad { get; set; }
    }
}
