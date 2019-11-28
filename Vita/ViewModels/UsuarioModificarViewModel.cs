using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.ViewModels
{
    public class UsuarioModificarViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int SexoId { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int LocalidadId { get; set; }
        public int Celular { get; set; }
        public int Telefono { get; set; }
        public string UsuarioName { get; set; }
        public string Pass { get; set; }
        public string SitioWeb { get; set; }
        public string SobreMi { get; set; }
        public int RolId { get; set; }
        public string Foto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int[] selectedSegmento { get; set; }
        public int[] selectedCategoria { get; set; }

        public int ProvinciaId { get; set; }



    }
}