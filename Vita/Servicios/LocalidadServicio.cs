using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vita.Servicios
{
    public class LocalidadServicio
    {
        private VitaEntities myDbContext = new VitaEntities();

        public Localidad GetLocalidadById(int localidadId)
        {
            return myDbContext.Localidad.Where(x => x.Id == localidadId).FirstOrDefault();
        }
        public List<Localidad> GetAllLocalidades()
        {
            return myDbContext.Localidad.OrderBy(x => x.Descripcion).ToList();
        }
        public List<Provincia> GetAllProvincias()
        {
            return myDbContext.Provincia.OrderBy(x => x.Descripcion).ToList();
        }
        public List<Departamento> GetDepartamentosByProvinciaId(int ? provinciaId)
        {
            return myDbContext.Departamento.OrderBy(x => x.Descripcion).Where(x=>x.ProvinciaId== provinciaId).ToList();
        }
        public List<Localidad> GetLocalidadesByDepartamentoId(int? departamentoId)
        {
            return myDbContext.Localidad.OrderBy(x => x.Descripcion).Where(x => x.DepartamentoId == departamentoId).ToList();
        }
        public Domicilio GetDomicilioByActividadId(int actividadId)
        {
            return myDbContext.Domicilio.Where(x => x.ActividadId == actividadId).FirstOrDefault();
        }
    }
}