using System;

namespace Vita.ViewModels
{
    public class ActividadViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public int SubCategoriaId { get; set; }
        public string InicioEvento { get; set; }
        public string HoraInicio { get; set; }
        public string FinEvento { get; set; }
        public string HoraFin { get; set; }
        public string HoraInicioLunes { get; set; }
        public string HoraFinLunes { get; set; }
        public string HoraInicioMartes { get; set; }
        public string HoraFinMartes { get; set; }
        public string HoraInicioMiercoles { get; set; }
        public string HoraFinMiercoles { get; set; }
        public string HoraInicioJueves { get; set; }
        public string HoraFinJueves { get; set; }
        public string HoraInicioViernes { get; set; }
        public string HoraFinViernes { get; set; }
        public string HoraInicioSabado { get; set; }
        public string HoraFinSabado { get; set; }
        public string HoraInicioDomingo { get; set; }
        public string HoraFinDomingo { get; set; }
        public int CantidadCupo { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public int Precio { get; set; }
        public string NombreCalle { get; set; }
        public int NumeroCalle { get; set; }
        public int NumeroDepartamento { get; set; }
        public int NumeroPiso { get; set; }
        public string CodigoPostal { get; set; }
        public int ProvinciaId { get; set; }
        public int DepartamentoId { get; set; }
        public int LocalidadId { get; set; }
        public int UsuarioId { get; set; }
        public string Foto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool ConUsuarioPendiente { get; set; }
    }
}