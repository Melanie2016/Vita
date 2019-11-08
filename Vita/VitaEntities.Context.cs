﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VitaEntities : DbContext
    {
        public VitaEntities()
            : base("name=VitaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<ActividadSegmento> ActividadSegmento { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Consigna> Consigna { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<FechasActividad> FechasActividad { get; set; }
        public virtual DbSet<FormularioDinamico> FormularioDinamico { get; set; }
        public virtual DbSet<FormularioLleno> FormularioLleno { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Opcion> Opcion { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<RespuestaConOpcion> RespuestaConOpcion { get; set; }
        public virtual DbSet<RespuestasInput> RespuestasInput { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Segmento> Segmento { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<TipoDatoIngresado> TipoDatoIngresado { get; set; }
        public virtual DbSet<TipoPregunta> TipoPregunta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioCategoriaElegida> UsuarioCategoriaElegida { get; set; }
        public virtual DbSet<UsuarioEstadoHistorico> UsuarioEstadoHistorico { get; set; }
        public virtual DbSet<UsuarioInscriptoActividad> UsuarioInscriptoActividad { get; set; }
        public virtual DbSet<UsuarioSegmento> UsuarioSegmento { get; set; }
    }
}
