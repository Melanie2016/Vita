using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class ActividadViewModel
    {
        public int Id { get; set;}
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public int Precio { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int CantidadDias { get; set; }
        public int CantidadCupo { get; set; }
        public int CategoriaId { get; set; }
        public int SubCategoriaId { get; set; }
        public int LocalidadId { get; set; }
        public int UsuarioId { get; set; }
        public byte[] Foto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool Compleja { get; set; }
        public int IdDomicilio { get; set; }
        public string NombreCalle { get; set; }
        public int NumeroCalle { get; set; }
        public int NumeroDepartamento { get; set; }
        public int NumeroPiso { get; set; }
        public string CodigoPostal { get; set; }
        public int DomicilioLocalidadId { get; set; }
        public int DomicilioUsuarioId { get; set; }
        public int DomicilioActividadId { get; set; }
        public DateTime FechaRegistroEnDb { get; set; }
    }
}