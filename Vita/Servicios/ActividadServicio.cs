using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Vita.ViewModels;

namespace Vita.Servicios
{
    public class ActividadServicio
    {
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private VitaEntities myDbContext = new VitaEntities();
        public Actividad GetActividad(int ActividadId)//por id de actividad
        {
            return myDbContext.Actividad.Find(ActividadId);
        }

        //va a devolver una lista del viewMoDEL que cree (que solo tiene fecha desde, fecha hasta y descripcion de la actividad)
        public List<ActividadFechaViewModel> GetAllActividadByUsuario() //lista de activiades , solo la descripcion y fecha, MOMENTANEA
        {
            var idUsuario = 1;
            //hago una lista para las actividades de ese usuario

            var listaActividadDelUsuario = (from ua in myDbContext.UsuarioInscriptoActividad
                         join a in myDbContext.Actividad
                          on ua.ActividadId equals a.Id
                         join u in myDbContext.Usuario
                          on ua.UsuarioId equals idUsuario
                          select ua).ToList();


            /*
            var qryPrl = (from prl in _db.prc_PR_Lines
                          join prlLink in _db.prc_Requirement_PR_Line_Link
                          on prl.PRLineID equals prlLink.PRLineID
                          where prlLink.ReqID.Equals(id)
                          where prl.PRID.Equals(idfield)
                          select prl).ToList<prc_PR_Lines>();*/

            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();

            //hago una lista del view model para guardar los datos que necesito de la otra lista
            var lista = new List<ActividadFechaViewModel>();

            //recorro la primera lista
            foreach (var aux in listaActividadDelUsuario)
            {
                //creo un objeto del tipo de viewModel
                var actividadFechaViewModel = new ActividadFechaViewModel()
                {
                    //y a cada atributo del viewModel lo lleno con el atributo que necesito de actividad
                    ActividadId = aux.Actividad.Id,
                    Titulo = aux.Actividad.Titulo,
                    Descripcion = aux.Actividad.Titulo,
                    FechaDesde = aux.Actividad.FechaDesde,
                    FechaHasta = aux.Actividad.FechaHasta

                };
                //luego lo agrego a la lista del vieewModel
                lista.Add(actividadFechaViewModel);
            }
            //y devuelvo la lista de viewModel
            return lista;
        }

        public List<Actividad> GetAllActividadByRolEntidadId(int usuarioId) //lista de activiades por entidad id
        {
            var actividades= myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId).ToList();
            var actividadConTodo = new List<Actividad>();
           foreach(var act in actividades)
           {
                if(act.Localidad == null)
                {
                    act.Localidad = localidadServicio.GetLocalidadById(act.LocalidadId);
                }
                if(act.Categoria == null)
                {
                    act.Categoria = categoriaServicio.GetCategoriaById(act.CategoriaId);
                }
                if(act.SubCategoria == null)
                {
                    act.SubCategoria = categoriaServicio.GetSubCategoriaById(act.SubcategoriaId);
                }
                
                actividadConTodo.Add(act);

            }

            return actividadConTodo;

        }
        public List<Actividad> GetAllActividadByRolUsuarioId(int usuarioId) //lista de activiades por usuario inscripto id
        {
            var listaActividad = new List<Actividad>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId).ToList();

            foreach (var actividadInscriptoUser in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(myDbContext.Actividad.Where(x => x.Id == actividadInscriptoUser.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }
        public List<Usuario> GetAllActividadUsuarioInscriptoByActividadId(int actividadId) //lista de activiades por usuario inscripto id
        {
            var listaActividad = new List<Usuario>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId).ToList();

            foreach (var actividadInscriptoUser in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(myDbContext.Usuario.Where(x => x.Id == actividadInscriptoUser.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }

        public List<Actividad> GetAllActividadBySegmentoId(long SegmentoId)
        {
            var listaActividad = new List<Actividad>();
            var ListaActividadSegmento = myDbContext.ActividadSegmento.Where(x => x.SegmentoId == SegmentoId).ToList();

            foreach (var actividadsegmento in ListaActividadSegmento)
            {
                listaActividad.Add(myDbContext.Actividad.Where(x => x.Id == actividadsegmento.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }
        public void CrearActividad(ActividadViewModel actividadViewModel, Usuario usuario, int[] selectedSegmento)
        {
            if(actividadViewModel.SubCategoriaId == 0) //por ahora
            {
                actividadViewModel.SubCategoriaId = 3;
            }
            Actividad actividadNueva = new Actividad
            {
                Titulo = actividadViewModel.Titulo,
                Descripcion = actividadViewModel.Descripcion,
                EdadMinima = actividadViewModel.EdadMinima,
                EdadMaxima = actividadViewModel.EdadMaxima,
                Precio = actividadViewModel.Precio,
                FechaDesde = actividadViewModel.RangoFecha,
                FechaHasta = actividadViewModel.RangoFecha,
                CantidadDias = actividadViewModel.CantidadDias,
                CantidadCupo = actividadViewModel.CantidadCupo,
                CategoriaId = actividadViewModel.CategoriaId,
                SubcategoriaId = actividadViewModel.SubCategoriaId,
                LocalidadId = actividadViewModel.DomicilioLocalidadId,
                Compleja = actividadViewModel.Compleja,
                UsuarioId = usuario.Id,

                // Foto= actividad.Foto una actividad puede tener varias fotos
                CreatedAt = DateTime.Now
            };

            myDbContext.Actividad.Add(actividadNueva);
            myDbContext.SaveChanges();
            Domicilio domicilioNuevo = new Domicilio
            {
                NombreCalle = actividadViewModel.NombreCalle,
                NumeroCalle = actividadViewModel.NumeroCalle,
                NumeroPiso = actividadViewModel.NumeroPiso,
                NumeroDepartamento = actividadViewModel.NumeroDepartamento,
                CodigoPostal = actividadViewModel.CodigoPostal,
                LocalidadId = actividadViewModel.DomicilioLocalidadId,
                UsuarioId = usuario.Id,
                ActividadId = actividadNueva.Id,
                FechaRegistroEnDb = DateTime.Now
            };
           
            myDbContext.Domicilio.Add(domicilioNuevo);
            myDbContext.SaveChanges();
            this.CrearSegmentoActividad(actividadNueva.Id, selectedSegmento);

        }
        public void CrearSegmentoActividad(int actividadId, int[] selectedSegmento)
        {
            foreach (var segmento in selectedSegmento)
            {
                var actvidadSegmento = new ActividadSegmento
                {
                    ActividadId = actividadId,
                    SegmentoId = segmento,
                    CreatedAt = DateTime.Now
                };
                myDbContext.ActividadSegmento.Add(actvidadSegmento);
                myDbContext.SaveChanges();
            }
        }

        public List<Actividad> GetBusquedaAvanzada(string textoIngresado)
        {
            var lista = new List<Actividad>();
            var edadOprecio = 0;
            Exception excepcion = null;
            try
            {
                edadOprecio = Convert.ToInt32(textoIngresado);
            }
            catch (Exception e) // si tiene una excepcion quiere decir que no es un numero solo 
            {
                excepcion = e;
                var listaActividadesPorSegmento = new List<Actividad>();
                var listaPorOtrasCosas = new List<Actividad>();
                var listaSegmento = new List<Segmento>();

                listaSegmento = myDbContext.Segmento.Where(x => x.Descripcion.Contains(textoIngresado)).ToList();
                foreach (var li in listaSegmento)
                {
                    listaActividadesPorSegmento = GetAllActividadBySegmentoId(li.Id);
                }

                lista.AddRange(listaActividadesPorSegmento);

                listaPorOtrasCosas = myDbContext.Actividad.Where(
                    x => x.Titulo.Contains(textoIngresado) ||
                    (x.Descripcion.Contains(textoIngresado)) ||
                    (x.Categoria.Descripcion.Contains(textoIngresado)) ||
                    (x.SubCategoria.Descripcion.Contains(textoIngresado)) ||
                    (x.Localidad.Descripcion.Contains(textoIngresado))
                    ).ToList();
                lista.AddRange(listaPorOtrasCosas);
            }
            if (excepcion == null || excepcion == null) //quiere decir que es un numero solo
            {
                var listaPrecio = new List<Actividad>();
                var listaEdad = new List<Actividad>();

                listaPrecio = myDbContext.Actividad.Where(x => x.Precio == edadOprecio).ToList();
                listaEdad = myDbContext.Actividad.Where(x => x.EdadMaxima >= edadOprecio && x.EdadMinima <= edadOprecio).ToList();
                lista.AddRange(listaPrecio);//agrego a la lista las que coinciden, tuve que hacerlo separado porque no quiere el where todo junto :(
                lista.AddRange(listaEdad);
            }
            return lista;
        }

        public List<Actividad> GetBusquedaPorIdCategoria(string categoriaId)
        {
            int id = int.Parse(categoriaId);
            var lista2 = new List<Actividad>();
            var lista = myDbContext.Actividad.Where(x => x.CategoriaId == id).ToList();
            foreach(var li in lista)
            {
                if(li.Localidad == null)
                {
                    li.Localidad = localidadServicio.GetLocalidadById(li.LocalidadId);

                }
                if(li.Categoria == null)
                {
                    li.Categoria = categoriaServicio.GetCategoriaById(li.CategoriaId);
                }
                lista2.Add(li);
            }

            return lista2;
        }

        public List<Actividad> GetAllActividades()
        {
            var lista2 = new List<Actividad>();
            var lista = myDbContext.Actividad.ToList();
            foreach (var li in lista)
            {
                if (li.Localidad == null)
                {
                    li.Localidad = localidadServicio.GetLocalidadById(li.LocalidadId);

                }
                if (li.Categoria == null)
                {
                    li.Categoria = categoriaServicio.GetCategoriaById(li.CategoriaId);
                }
                lista2.Add(li);
            }

            return lista2;
        }

        public int InscribirUsuarioEnActividad(Usuario usuario, string actividadId, string estadoId)
        {
            UsuarioInscriptoActividad usuarioActividad = new UsuarioInscriptoActividad
            {
                ActividadId = int.Parse(actividadId),
                UsuarioId = usuario.Id,
                EstadoId = int.Parse(estadoId),
                CreatedAt = DateTime.Now
            };
            myDbContext.UsuarioInscriptoActividad.Add(usuarioActividad);
            var resultado = myDbContext.SaveChanges();

            return resultado;
        }


        // falta hacer query 
        public List<Actividad> GetActividadesConDescripcionYFechaSegunUsuario(int usuarioId) 
        {
            var listaActividad = new List<Actividad>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId).ToList();

            foreach (var actividadInscriptoUser in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(myDbContext.Actividad.Where(x => x.Id == actividadInscriptoUser.ActividadId).FirstOrDefault());
            }
            return listaActividad;
        }



    }
}