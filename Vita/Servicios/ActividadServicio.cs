using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Vita.ViewModels;


namespace Vita.Servicios
{
    public class ActividadServicio
    {
        private CategoriaServicio categoriaServicio = new CategoriaServicio();
        private LocalidadServicio localidadServicio = new LocalidadServicio();
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private VitaEntities myDbContext = new VitaEntities();
        public Actividad GetActividad(int ActividadId)//por id de actividad
        {
            var act = myDbContext.Actividad.Find(ActividadId);
            if (act.Localidad == null)
            {
                act.Localidad = localidadServicio.GetLocalidadById(act.LocalidadId);
            }
            if (act.Categoria == null)
            {
                act.Categoria = categoriaServicio.GetCategoriaById(act.CategoriaId);
            }
            if (act.SubCategoria == null)
            {
                act.SubCategoria = categoriaServicio.GetSubCategoriaById(act.SubcategoriaId);
            }
            if (act.Usuario == null)
            {
                act.Usuario = usuarioServicio.GetById(act.UsuarioId.Value);
            }
            if (act.Domicilio == null || act.Domicilio.Count == 0)
            {
                var domi = localidadServicio.GetDomicilioByActividadId(act.Id);
                act.Domicilio.Add(domi);
            }
            return act;
        }

        public List<EstadisticasDonutViewModel> GetEstadisticasDonutCategoria()
        {
            var categorias = myDbContext.Categoria.ToList();
            var listaCantiQuery = new List<EstadisticasDonutViewModel>();
            foreach (var c in categorias)
            {
                var estadistica = new EstadisticasDonutViewModel();
                estadistica.label = c.DescCorta;
                estadistica.value = myDbContext.Actividad.Where(a => a.CategoriaId == c.Id).Count();
                listaCantiQuery.Add(estadistica);
            }
            return listaCantiQuery;
        }

        public List<EstadisticasDonutViewModel> GetEstadisticasDonutSemana()
        {
            var diasSemana = myDbContext.DiaSemana.ToList();
            var listaCantiQuery = new List<EstadisticasDonutViewModel>();
            foreach (var d in diasSemana)
            {
                var estadistica = new EstadisticasDonutViewModel();
                estadistica.label = d.Descripcion;
                estadistica.value = myDbContext.InscripcionFecha.Where(x => x.FechaActividad.DiaSemanaId == d.Id).Count();
                listaCantiQuery.Add(estadistica);
            }
            return listaCantiQuery;
        }

        public List<EstadisticasBarViewModel> GetEstadisticasBarCategoria()
        {
            var diasSemana = myDbContext.DiaSemana.ToList();
            var listaCantiQuery = new List<EstadisticasBarViewModel>();
            foreach (var d in diasSemana)
            {
                var estadistica = new EstadisticasBarViewModel();
                estadistica.y = d.Descripcion;
                estadistica.a = myDbContext.InscripcionFecha.Where(x => x.FechaActividad.DiaSemanaId == d.Id).Count();
                listaCantiQuery.Add(estadistica);
            }
            return listaCantiQuery;
        }

        //va a devolver una lista del viewMoDEL que cree (que solo tiene fecha desde, fecha hasta y descripcion de la actividad)
        public List<ActividadFechaViewModel> GetAllActividadByUsuario(Usuario usuario) //lista de activiades , solo la descripcion y fecha, MOMENTANEA
        {
            //hago una lista para las actividades de ese usuario

            List<InscripcionFecha> listaActividadDelUsuario = myDbContext.InscripcionFecha.Where(x => x.UsuarioInscriptoActividad.UsuarioId == usuario.Id).ToList();
            /*
            var listaActividadDelUsuario = (from ua in myDbContext.UsuarioInscriptoActividad
                                            join a in myDbContext.Actividad
                                             on ua.ActividadId equals a.Id
                                            join u in myDbContext.Usuario
                                             on ua.UsuarioId equals idUsuario
                                            select ua).ToList();*/


            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();

            //hago una lista del view model para guardar los datos que necesito de la otra lista
            var lista = new List<ActividadFechaViewModel>();
            TimeSpan ts = new TimeSpan();
            DateTime date = new DateTime();
            //recorro la primera lista
            foreach (var aux in listaActividadDelUsuario)
            {
                //creo un objeto del tipo de viewModel
                var actividadFechaViewModel = new ActividadFechaViewModel()
                {
                    //y a cada atributo del viewModel lo lleno con el atributo que necesito de actividad
                    ActividadId = aux.UsuarioInscriptoActividad.Actividad.Id,
                    Titulo = aux.UsuarioInscriptoActividad.Actividad.Titulo,
                    Descripcion = aux.UsuarioInscriptoActividad.Actividad.Descripcion,
                    DiaSemana = aux.FechaActividad.DiaSemanaId != null ? aux.FechaActividad.DiaSemana.Id : -1,
                    //     InicioEvento = (aux.FechaActividad.InicioEvento + ts.Add(aux.FechaActividad.HoraInicio)).ToString(),
                    //     FinEvento = (aux.FechaActividad.FinEvento + ts.Add(aux.FechaActividad.HoraFin)).ToString(),
                    InicioEvento = aux.FechaActividad.InicioEvento != null ? aux.FechaActividad.InicioEvento.Value : date,
                    FinEvento = aux.FechaActividad.FinEvento != null ? aux.FechaActividad.FinEvento.Value : date,
                    HoraInicio = aux.FechaActividad.HoraInicio.ToString(),
                    HoraFin = aux.FechaActividad.HoraFin.ToString()

                };
                //luego lo agrego a la lista del vieewModel
                lista.Add(actividadFechaViewModel);
            }
            //y devuelvo la lista de viewModel
            return lista;
        }

        public List<Actividad> GetAllActividadByRolEntidadId(int usuarioId) //lista de activiades por entidad id
        {
            var actividades = myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId).ToList();

            /*
            var estadosPorActividad = (from e in myDbContext.Estado
                                            join ua in myDbContext.UsuarioInscriptoActividad
                                             on e.Id equals ua.EstadoId
                                            join a in myDbContext.Actividad
                                             on ua.ActividadId equals a.Id
                                             group e by e.Descripcion into grupo
                                            select new
                                            {key = grupo.Key, cnt = grupo.Count()
                                            }).ToList();
*/
            /*
                        var pl = from r in info
                                 orderby r.metric
                                 group r by r.metric into grp
                                 select new { key = grp.Key, cnt = grp.Count() };

            */
            /*
            Select e.Descripcion, count(e.Descripcion) Cantidad
            from UsuarioInscriptoActividad ua join actividad a on ua.ActividadId = a.Id join Estado e on ua.EstadoId = e.Id
            where a.UsuarioId = 1
            group by e.Descripcion
            */

            var actividadConTodo = new List<Actividad>();
            foreach (var act in actividades)
            {
                if (act.Localidad == null)
                {
                    act.Localidad = localidadServicio.GetLocalidadById(act.LocalidadId);
                }
                if (act.Categoria == null)
                {
                    act.Categoria = categoriaServicio.GetCategoriaById(act.CategoriaId);
                }
                if (act.SubCategoria == null)
                {
                    act.SubCategoria = categoriaServicio.GetSubCategoriaById(act.SubcategoriaId);
                }
                if (act.Usuario == null)
                {
                    act.Usuario = usuarioServicio.GetById(act.UsuarioId.Value);
                }
                if (act.Domicilio == null)
                {
                    var domi = localidadServicio.GetDomicilioByActividadId(act.Id);
                    act.Domicilio.Add(domi);
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
        public Actividad GetUltimaActividadPorUsuarioCreadaId(long usuarioId)
        {
            var actividad = myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId).OrderByDescending(x => x.Id).FirstOrDefault();
            return actividad;
        }

        public void CrearFormularioDinamico(FormularioDinamicoViewModel formViewModel, Actividad actividad)
        {
            FormularioDinamico formularioDinamicoNuevo = new FormularioDinamico
            {
                Titulo = formViewModel.Titulo,
                Descripcion = formViewModel.Descripcion,
                ActividadId = actividad.Id,
                EntidadId = actividad.UsuarioId,
                CreatedAt = DateTime.Now
            };
            myDbContext.FormularioDinamico.Add(formularioDinamicoNuevo);
            myDbContext.SaveChanges();


            foreach (var ca in formViewModel.CamposVm)
            {

                Campos camposNuevo = new Campos
                {
                    Nombre = ca.Nombre,
                    FormularioDinamicoId = formularioDinamicoNuevo.Id,
                    TipoDatoCampoId = ca.TipoDatoCampoId,
                    Obligatorio = ca.Obligatorio,
                    CreatedAt = DateTime.Now
                };
                myDbContext.Campos.Add(camposNuevo);
                myDbContext.SaveChanges();

            }
        }


        public void CrearActividad(ActividadViewModel actividadViewModel, Usuario usuario, int[] selectedSegmento)
        {
            Actividad actividadNueva = new Actividad
            {
                Titulo = actividadViewModel.Titulo,
                Descripcion = actividadViewModel.Descripcion,
                EdadMinima = actividadViewModel.EdadMinima,
                EdadMaxima = actividadViewModel.EdadMaxima,
                Precio = actividadViewModel.Precio,
                CantidadCupo = actividadViewModel.CantidadCupo,
                CategoriaId = actividadViewModel.CategoriaId,
                SubcategoriaId = actividadViewModel.SubCategoriaId,
                Foto = actividadViewModel.Foto,
                Url = actividadViewModel.Url,
                LocalidadId = actividadViewModel.LocalidadId,
                UsuarioId = usuario.Id,
                CreatedAt = DateTime.Now,
                ConUsuarioPendiente = actividadViewModel.ConUsuarioPendiente,
                EstadoId = 6 //creada
            };

            myDbContext.Actividad.Add(actividadNueva);
            var resultado = myDbContext.SaveChanges();

            if (resultado == 1) //Se creó la actividad
            {
                Domicilio domicilioNuevo = new Domicilio
                {
                    NombreCalle = actividadViewModel.NombreCalle,
                    NumeroCalle = actividadViewModel.NumeroCalle,
                    NumeroPiso = actividadViewModel.NumeroPiso,
                    NumeroDepartamento = actividadViewModel.NumeroDepartamento,
                    CodigoPostal = actividadViewModel.CodigoPostal,
                    LocalidadId = actividadViewModel.LocalidadId,
                    UsuarioId = usuario.Id,
                    ActividadId = actividadNueva.Id,
                    FechaRegistroEnDb = DateTime.Now
                };

                myDbContext.Domicilio.Add(domicilioNuevo);
                myDbContext.SaveChanges();
                this.CrearSegmentoActividad(actividadNueva.Id, selectedSegmento);

                //Tiene una fecha de inicio y fin solamente
                if (actividadViewModel.InicioEvento != null && actividadViewModel.HoraInicioLunes == null && actividadViewModel.HoraInicioMartes == null
                    && actividadViewModel.HoraInicioMiercoles == null && actividadViewModel.HoraInicioJueves == null && actividadViewModel.HoraInicioViernes == null
                    && actividadViewModel.HoraInicioSabado == null && actividadViewModel.HoraInicioDomingo == null)
                {
                    FechaActividad fechasActividadNuevo = new FechaActividad
                    {
                        InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento),
                        FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento),
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicio),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFin),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadNuevo);
                    myDbContext.SaveChanges();
                }
                else //Tiene varios dias a la semana con horarios
                {

                    //LUNES
                    if (actividadViewModel.HoraInicioLunes != null)
                    {
                        FechaActividad fechasActividadLunes = new FechaActividad
                        {
                            DiaSemanaId = 1,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioLunes),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinLunes),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadLunes);
                        myDbContext.SaveChanges();
                    }

                    //MARTES
                    if (actividadViewModel.HoraInicioMartes != null)
                    {
                        FechaActividad fechasActividadMartes = new FechaActividad
                        {
                            DiaSemanaId = 2,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioMartes),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinMartes),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadMartes);
                        myDbContext.SaveChanges();
                    }



                    //MIERCOLES
                    //Tiene el mismo horario que otros dias
                    if (actividadViewModel.HoraInicioMiercoles != null)
                    {
                        FechaActividad fechasActividadMiercoles = new FechaActividad
                        {
                            DiaSemanaId = 3,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioMiercoles),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinMiercoles),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadMiercoles);
                        myDbContext.SaveChanges();
                    }

                    //JUEVES
                    if (actividadViewModel.HoraInicioJueves != null)
                    {
                        FechaActividad fechasActividadJueves = new FechaActividad
                        {
                            DiaSemanaId = 4,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioJueves),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinJueves),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadJueves);
                        myDbContext.SaveChanges();
                    }

                    //VIERNES
                    if (actividadViewModel.HoraInicioViernes != null)
                    {
                        FechaActividad fechasActividadViernes = new FechaActividad
                        {
                            DiaSemanaId = 5,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioViernes),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinViernes),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadViernes);
                        myDbContext.SaveChanges();
                    }

                    //SABADO
                    if (actividadViewModel.HoraInicioSabado != null)
                    {
                        FechaActividad fechasActividadSabado = new FechaActividad
                        {
                            DiaSemanaId = 6,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioSabado),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinSabado),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadSabado);
                        myDbContext.SaveChanges();
                    }

                    //DOMINGO
                    if (actividadViewModel.HoraInicioDomingo != null)
                    {
                        FechaActividad fechasActividadDomingo = new FechaActividad
                        {
                            DiaSemanaId = 0,
                            InicioEvento = Convert.ToDateTime(actividadViewModel.InicioEvento + " " + actividadViewModel.HoraInicio),
                            FinEvento = Convert.ToDateTime(actividadViewModel.FinEvento + " " + actividadViewModel.HoraFin),
                            HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioDomingo),
                            HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinDomingo),
                            ActividadId = actividadNueva.Id
                        };

                        myDbContext.FechaActividad.Add(fechasActividadDomingo);
                        myDbContext.SaveChanges();
                    }

                }
            }

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


        public List<Actividad> GetActividadesFiltradasPorUsuario( string titulo, int idUsuario ,int? idCategoria, int? idEstado, DateTime? fechaDesde)
        {

            var actividadesFiltradas = new List<Actividad>();

            var listaResultadoDeMentis = new List<Actividad>();
            

            if(titulo != "" && titulo != null) 
            {
                if (idCategoria != null) 
                {
                    if(idEstado != null) 
                    {
                        if (fechaDesde != null) // si filtra por categoria, titulo, estado , fechas 
                        {
                            
                                //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();
                            var fechasFiltradas = myDbContext.FechaActividad.Include("Actividad").Where(x => x.InicioEvento >= fechaDesde && x.Actividad.UsuarioId == idUsuario).ToList();
                            foreach (var i in fechasFiltradas)
                            {
                                
                                var actividad = myDbContext.Actividad.Where(x => x.Id == i.ActividadId && x.CategoriaId == idCategoria && i.Actividad.Titulo.Contains(titulo) && i.Actividad.EstadoId == idEstado).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                            }

                            return actividadesFiltradas;
                        }
                        else // por categoria, titulo y estado
                        {
                                var actvidiadesFiltradasPorCategoria = myDbContext.Actividad.Where(x => x.CategoriaId == idCategoria && x.UsuarioId == idUsuario && x.Titulo.Contains(titulo) && x.EstadoId == idEstado).ToList();
                                return actvidiadesFiltradasPorCategoria;
                        }
                    }
                    else // si filtro por categoria y titulo 
                    {
                        var actvidiadesFiltradasPorCategoria = myDbContext.Actividad.Where(x => x.CategoriaId == idCategoria && x.UsuarioId == idUsuario && x.Titulo.Contains(titulo)).ToList();
                        return actvidiadesFiltradasPorCategoria;
                    }

                }
                else // SOLO POR TITULO
                {
                    var actvidiadesFiltradasPorCategoria = myDbContext.Actividad.Where(x => x.Titulo.Contains(titulo) && x.UsuarioId == idUsuario).ToList();
                    return actvidiadesFiltradasPorCategoria;
                      
                }
            }
            else
            {
                if (idCategoria != null)
                {

                    if (fechaDesde != null)
                    {

                        if (idEstado != null) // si filtra por categoria, fechas y estado
                        {

                            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();
                            var fechasFiltradas = myDbContext.FechaActividad.Include("Actividad").Where(x => x.InicioEvento >= fechaDesde && x.Actividad.UsuarioId == idUsuario).ToList();
                            foreach (var i in fechasFiltradas)
                            {
                                var actividad = myDbContext.Actividad.Where(x => x.Id == i.ActividadId && x.CategoriaId == idCategoria && x.EstadoId == idEstado).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                            }

                            return actividadesFiltradas;
                        }
                        else // si filtra por categoria y fechas
                        {

                            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();
                            var fechasFiltradas = myDbContext.FechaActividad.Include("Actividad").Where(x => x.InicioEvento >= fechaDesde && x.Actividad.UsuarioId == idUsuario).ToList();
                            foreach (var i in fechasFiltradas)
                            {
                                var actividad = myDbContext.Actividad.Where(x => x.Id == i.ActividadId && x.CategoriaId == idCategoria).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                            }

                            return actividadesFiltradas;
                        }

                    }
                    else // si solo filtro por categoria y estado 
                    {
                        if (idEstado != null)
                        {
                            var actvidiadesFiltradasPorCategoria = myDbContext.Actividad.Where(x => x.CategoriaId == idCategoria && x.UsuarioId == idUsuario && x.EstadoId == idEstado).ToList();
                            return actvidiadesFiltradasPorCategoria;
                        }
                        else //SOLO POR CATEGORIA 
                        {
                            var actvidiadesFiltradasPorCategoria = myDbContext.Actividad.Where(x => x.CategoriaId == idCategoria && x.UsuarioId == idUsuario).ToList();
                            return actvidiadesFiltradasPorCategoria;
                        }
                    }

                }
                else
                {
                    if (fechaDesde != null) // si solo filtro por fechas
                    {
                        if (idEstado != null)// si solo filtro por fechas y estados
                        {

                            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();
                            var fechasFiltradas = myDbContext.FechaActividad.Include("Actividad").Where(x => x.InicioEvento >= fechaDesde && x.Actividad.UsuarioId == idUsuario).ToList();

                            foreach (var i in fechasFiltradas)
                            {
                                var actividad = myDbContext.Actividad.Where(x => x.Id == i.ActividadId && x.EstadoId == idEstado).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                            }

                            return actividadesFiltradas;
                        }
                        else // SOLO POR FECHA
                        {

                            //  List<UsuarioInscriptoActividad> listaActividadDelUsuario = myDbContext.UsuarioInscriptoActividad.Include("Actividad").Where(x => x.UsuarioId.Equals(idUsuario)).ToList();
                            var fechasFiltradas = myDbContext.FechaActividad.Include("Actividad").Where(x => x.InicioEvento >= fechaDesde && x.Actividad.UsuarioId == idUsuario).ToList();
                            foreach (var i in fechasFiltradas)
                            {
                                var actividad = myDbContext.Actividad.Where(x => x.Id == i.ActividadId).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                            }

                            return actividadesFiltradas;
                        }
                    }
                    else
                    {

                        if (idEstado != null)
                        {
                            if (titulo != null)
                            {

                                var actividad = myDbContext.Actividad.Where(x => x.Titulo.Contains(titulo) && x.EstadoId == idEstado).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                                return actividadesFiltradas;
                            }
                            else
                            {
                                var actividad = myDbContext.Actividad.Where(x => x.EstadoId == idEstado).FirstOrDefault();

                                if (actividad != null)
                                {
                                    actividadesFiltradas.Add(actividad);
                                }
                                return actividadesFiltradas;
                            }

                        }
                        else
                        {
                            return listaResultadoDeMentis;
                        }
                    }
                }
            }
           

        }

        public List<Actividad> GetBusquedaAvanzada(string textoIngresado, int? categoriaId, int? subCategoriaId, int? segmentoId, int? provinciaId, int? departamentoId, int? localidadId, string precio)
        {
            var listaVali = new List<Actividad>();
            var lista = new List<Actividad>();
            var listaFinal = new List<Actividad>();
            var listaFiltroPrecio = new List<Actividad>();

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

            //filtro por provincia, departamento y localidad
            foreach (var act in lista)
            {
                var actividadValidad = GetActividad(act.Id);

                //Me fijo si la fecha actual es menor a la fecha de fin de la actividad y el estado es publicada, entonces muestro la actividad
                if (DateTime.Now < act.FechaActividad.FirstOrDefault().FinEvento && act.EstadoId == 7)
                {
                    if (provinciaId != null) //busco por provincia
                    {
                        if (act.Localidad.Departamento.ProvinciaId == provinciaId)
                        {
                            if (departamentoId != null) //busco por departamento
                            {
                                if (act.Localidad.DepartamentoId == departamentoId)
                                {
                                    if (localidadId != null) //busco por localidad
                                    {
                                        if (act.LocalidadId == localidadId)
                                        {
                                            listaVali.Add(actividadValidad);
                                        }
                                    }
                                    else
                                    {
                                        listaVali.Add(actividadValidad);
                                    }
                                }
                            }
                            else
                            {
                                listaVali.Add(actividadValidad);
                            }
                        }
                    }
                    else
                    {
                        listaVali.Add(actividadValidad);
                    }
                }
            }


            //Fitro por categoria, subcategoria y segmento
            foreach (var item in listaVali)
            {
                if (categoriaId != null)
                {
                    if (item.CategoriaId == categoriaId) //busco por categoria
                    {
                        if (subCategoriaId != null)
                        {
                            if (item.SubcategoriaId == subCategoriaId) //busco por subcategoria
                            {
                                listaFinal.Add(item);
                            }
                        }
                        else
                        {
                            if (segmentoId != null)
                            {
                                foreach (var seg in item.ActividadSegmento) //una actividad puede tener muchos segmentos
                                {
                                    if (seg.SegmentoId == segmentoId) //busco por segmento
                                    {
                                        listaFinal.Add(item);
                                    }
                                }
                            }
                            else
                            {
                                listaFinal.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    if (segmentoId != null)
                    {
                        foreach (var seg in item.ActividadSegmento) //una actividad puede tener muchos segmentos
                        {
                            if (seg.SegmentoId == segmentoId) //busco por segmento
                            {
                                listaFinal.Add(item);
                            }
                        }
                    }
                }
            }


            if (categoriaId != null || subCategoriaId != null || segmentoId != null)
            {
                //filtro por precio
                foreach (var item in listaFinal)
                {
                    if (precio != null) //busco por precio
                    {
                        if (item.Precio != null && precio == "pagas")
                        {
                            listaFiltroPrecio.Add(item);
                        }

                        if (item.Precio == null && precio == "gratuitas")
                        {
                            listaFiltroPrecio.Add(item);
                        }
                    }
                }

                if (precio != null && precio != "")
                {
                    return listaFiltroPrecio;
                }
                else
                {
                    return listaFinal;
                }
            }
            else
            {
                //filtro por precio
                foreach (var item in listaVali)
                {
                    if (precio != null && precio != "") //busco por precio
                    {
                        if (item.Precio != null && precio == "pagas")
                        {
                            listaFiltroPrecio.Add(item);
                        }

                        if (item.Precio == null && precio == "gratuitas")
                        {
                            listaFiltroPrecio.Add(item);
                        }
                    }
                }

                if (precio != null && precio != "")
                {
                    return listaFiltroPrecio;
                }
                else
                {
                    return listaVali;
                }
            }
        }

        public List<Actividad> GetBusquedaPorIdCategoria(string categoriaId)
        {
            int id = int.Parse(categoriaId);
            var lista2 = new List<Actividad>();
            var lista = myDbContext.Actividad.Where(x => x.CategoriaId == id).ToList();
            foreach (var act in lista)
            {
                if (act.Localidad == null)
                {
                    act.Localidad = localidadServicio.GetLocalidadById(act.LocalidadId);
                }
                if (act.Categoria == null)
                {
                    act.Categoria = categoriaServicio.GetCategoriaById(act.CategoriaId);
                }
                if (act.SubCategoria == null)
                {
                    act.SubCategoria = categoriaServicio.GetSubCategoriaById(act.SubcategoriaId);
                }
                if (act.Usuario == null)
                {
                    act.Usuario = usuarioServicio.GetById(act.UsuarioId.Value);
                }
                if (act.Domicilio == null)
                {
                    var domi = localidadServicio.GetDomicilioByActividadId(act.Id);
                    act.Domicilio.Add(domi);
                }

                //Me fijo si la fecha actual es menor a la fecha de fin de la actividad y el estado es publicada, entonces muestro la actividad
                if (DateTime.Now < act.FechaActividad.FirstOrDefault().FinEvento && act.EstadoId == 7)
                {
                    lista2.Add(act);
                }
            }

            return lista2;
        }

        public List<Actividad> GetAllActividades()
        {
            var lista2 = new List<Actividad>();
            var lista = myDbContext.Actividad.ToList();

            foreach (var act in lista)
            {
                if (act.Localidad == null)
                {
                    act.Localidad = localidadServicio.GetLocalidadById(act.LocalidadId);
                }
                if (act.Categoria == null)
                {
                    act.Categoria = categoriaServicio.GetCategoriaById(act.CategoriaId);
                }
                if (act.SubCategoria == null)
                {
                    act.SubCategoria = categoriaServicio.GetSubCategoriaById(act.SubcategoriaId);
                }
                if (act.Usuario == null)
                {
                    act.Usuario = usuarioServicio.GetById(act.UsuarioId.Value);
                }
                if (act.Domicilio == null)
                {
                    var domi = localidadServicio.GetDomicilioByActividadId(act.Id);
                    act.Domicilio.Add(domi);
                }

                //Me fijo si la fecha actual es menor a la fecha de fin de la actividad y el estado es publicada, entonces muestro la actividad
                if (DateTime.Now < act.FechaActividad.FirstOrDefault().FinEvento && act.EstadoId == 7)
                {
                    lista2.Add(act);
                }
            }


            return lista2;
        }

        public int InscribirUsuarioEnActividad(Usuario usuario, string actividadId, string estadoId, int[] FechaActividadId)
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

            if (resultado == 1) //Inscribo al usuario a la actividad
            {
                //Ahora incribo al usuario en las fechas de la actividad
                foreach (var item in FechaActividadId)
                {
                    InscripcionFecha inscripcionFecha = new InscripcionFecha
                    {
                        UsuarioInscriptoActividadId = usuarioActividad.Id,
                        FechaActividadId = item,
                        CreatedAt = DateTime.UtcNow,
                        FechaActividad = myDbContext.FechaActividad.Find(item),
                        UsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Find(usuarioActividad.Id)
                    };

                    myDbContext.InscripcionFecha.Add(inscripcionFecha);
                    myDbContext.SaveChanges();
                }
            }

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

        public Estado GetByEstadoId(int estadoId)
        {
            var estado = myDbContext.Estado.Where(x => x.Id == estadoId).FirstOrDefault();
            return estado;
        }
        public List<Estado> GetEstadosActividad()
        {
            var searchIds = new List<int> { ConstantesUtil.ESTADO_ACTIVIDAD_FINALIZADA, ConstantesUtil.ESTADO_ACTIVIDAD_CREADA, ConstantesUtil.ESTADO_ACTIVIDAD_PUBLICADA };
            var estados = (from e in myDbContext.Estado
                           where searchIds.Contains(e.Id)
                           select e).Distinct().ToList();
            foreach (var e in estados)
            {
                if (e.Id == ConstantesUtil.ESTADO_ACTIVIDAD_FINALIZADA)
                {
                    e.Descripcion = "Actividades vencidas";
                }
                else
                {
                    if (e.Id == ConstantesUtil.ESTADO_ACTIVIDAD_CREADA)
                    {
                        e.Descripcion = "Pendientes de publicación";
                    }
                    else
                    {
                        e.Descripcion = "Actividades publicadas";
                    }
                }
               
            }
                return estados;
        }

        public List<Actividad> GetAllActividadByestadoIdAndActividadId(int estadoId, int actividadId)
        {
            var listaActividad = new List<Actividad>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId && x.EstadoId == estadoId).ToList();
            foreach (var li in listaUsuarioInscriptoActividad)
            {
                listaActividad.Add(li.Actividad);
            }

            return listaActividad;
        }
        public List<Usuario> GetUsuariosByEstadoId(int estadoId, int actividadId)
        {
            var listaUsuarios = new List<Usuario>();
            var listaUsuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId && x.EstadoId == estadoId).ToList();
            foreach (var li in listaUsuarioInscriptoActividad)
            {
                listaUsuarios.Add(li.Usuario);
            }

            return listaUsuarios;
        }
        public List<TipoDatoCampo> GetAllTipoDatoCampo()
        {
            return myDbContext.TipoDatoCampo.OrderBy(x => x.Descripcion).ToList();
        }

        public bool BuscarUsuarioInscriptoEnActividad(int usuarioId, int actividadId)
        {
            var usuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId && x.UsuarioId == usuarioId && x.EstadoId != 3).FirstOrDefault(); //el cancelado se puede volver a inscribir
            bool inscripto = false;

            if (usuarioInscriptoActividad != null)
            {
                inscripto = true;
            }

            return inscripto;

        }

        public void CambiarEstadoUsuarioInscripto(bool estado, int usuarioId, int actividadId)
        {
            var usuarioIns = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId && x.ActividadId == actividadId).FirstOrDefault();
            if (estado == true)
            {
                usuarioIns.EstadoId = 1;//aceptado
            }
            else
            {
                usuarioIns.EstadoId = 4;//rechazado
            }
            usuarioIns.UpdatedAt = DateTime.Now;
            myDbContext.SaveChanges();
        }
        public void CambiarEstadoUsuarioInscriptoGeneral(int estadoId, int usuarioId, int actividadId)
        {
            var usuarioIns = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId && x.ActividadId == actividadId).FirstOrDefault();

            usuarioIns.EstadoId = estadoId;

            usuarioIns.UpdatedAt = DateTime.Now;
            myDbContext.SaveChanges();
        }
        public FormularioDinamico GetFormularioDinamicoByActividadId(int actividadId)
        {
            var formu = myDbContext.FormularioDinamico.Where(x => x.ActividadId == actividadId).FirstOrDefault();
            var campos = myDbContext.Campos.Where(x => x.FormularioDinamicoId == formu.Id).ToList();
            formu.Campos = campos;
            return formu;
        }
        public void GuardarFormularioUsuario(FormularioLlenoViewModel formu)
        {
            DateTime fecha = new DateTime(978361200);//esto es fecha null

            foreach (var f in formu.CamposVm)
            {
                Respuesta respuestaNueva = new Respuesta();
                respuestaNueva.CamposId = f.CamposId;
                respuestaNueva.UsuarioId = f.UsuarioId;
                respuestaNueva.FormularioDinamicoId = f.FormularioDinamicoId;
                respuestaNueva.ActividadId = f.ActividadId;
                if (f.RespuestaTextoCorto != null)
                {
                    respuestaNueva.Respuesta1 = f.RespuestaTextoCorto;
                }
                if (f.RespuestaTextoLargo != null)
                {
                    respuestaNueva.Respuesta1 = f.RespuestaTextoLargo;
                }

                if (f.RespuestaTextoCorto == null && f.RespuestaDate.Date != fecha.Date && f.RespuestaTextoLargo == null)
                {
                    respuestaNueva.Respuesta1 = f.RespuestaDate.ToString();
                }

                if (f.RespuestaTextoCorto == null && f.RespuestaDate.Date == fecha.Date && f.RespuestaTextoLargo == null)
                {
                    respuestaNueva.Respuesta1 = f.RespuestaNumero.ToString();
                }

                if (f.RespuestaFoto != null && f.RespuestaDate.Date == fecha.Date)
                {
                    respuestaNueva.Respuesta1 = f.RespuestaFoto.ToString();

                }
                respuestaNueva.CreatedAt = DateTime.Now;
                myDbContext.Respuesta.Add(respuestaNueva);
                myDbContext.SaveChanges();
            }
        }
        public void PublicarActividad(int idActividad)
        {
            var actividadBD = myDbContext.Actividad.Where(x => x.Id == idActividad).FirstOrDefault();

            actividadBD.EstadoId = ConstantesUtil.ESTADO_ACTIVIDAD_PUBLICADA;
            myDbContext.SaveChanges();
        }
        public List<Respuesta> GetRespuestasByUsuarioIdandActividadId(int usuarioId, int actividadId)
        {
            var respuestas = myDbContext.Respuesta.Where(x => x.UsuarioId == usuarioId && x.ActividadId == actividadId).ToList();
            return respuestas;
        }
        public List<Respuesta> GetRespuestasByUsuarioId(int usuarioId)
        {
            var respuestas = myDbContext.Respuesta.Where(x => x.UsuarioId == usuarioId).ToList();
            return respuestas;
        }

        public Respuesta GetRespuestaById(int respuestaId)
        {
            var respuesta = myDbContext.Respuesta.Where(x => x.Id == respuestaId).FirstOrDefault();
            return respuesta;
        }
        public void ActualizarRespuestas(List<RespuestaViewModel> respuestaViewModels)
        {
            foreach (var r in respuestaViewModels)
            {
                var respuestaVieja = myDbContext.Respuesta.Find(r.Id);
                respuestaVieja.UpdatedAt = DateTime.UtcNow;

                DateTime fecha = new DateTime(978361200);//esto es fecha null

                if (r.RespuestaTextoCorto != null)
                {
                    respuestaVieja.Respuesta1 = r.RespuestaTextoCorto;
                }
                if (r.RespuestaTextoLargo != null)
                {
                    respuestaVieja.Respuesta1 = r.RespuestaTextoLargo;
                }

                if (r.RespuestaTextoCorto == null && r.RespuestaDate.Date != fecha.Date && r.RespuestaTextoLargo == null)
                {
                    respuestaVieja.Respuesta1 = r.RespuestaDate.ToString();
                }

                if (r.RespuestaTextoCorto == null && r.RespuestaDate.Date == fecha.Date && r.RespuestaTextoLargo == null)
                {
                    respuestaVieja.Respuesta1 = r.RespuestaNumero.ToString();
                }

                if (r.RespuestaFoto != null && r.RespuestaDate.Date == fecha.Date)
                {
                    respuestaVieja.Respuesta1 = r.RespuestaFoto.ToString();

                }
                //Le cambio el estado
                this.CambiarEstadoUsuarioInscriptoGeneral(9, respuestaVieja.UsuarioId.Value, respuestaVieja.ActividadId.Value);
                myDbContext.SaveChanges();
            }


        }
        public void DarseDeBajaActividad(int actividadId, int usuarioId)
        {
            var usuario = myDbContext.Usuario.Where(x => x.Id == usuarioId).FirstOrDefault();

            if (usuario.RolId == 1)//usuario cliente
            {
                var usuarioInscrip = myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId && x.ActividadId == actividadId).FirstOrDefault();
                var inscripFecha = myDbContext.InscripcionFecha.Where(x => x.UsuarioInscriptoActividadId == usuarioInscrip.Id).ToList();
                foreach (var f in inscripFecha)
                {
                    f.DeletedAt = DateTime.UtcNow;
                }
                usuarioInscrip.DeletedAt = DateTime.UtcNow;
                usuarioInscrip.EstadoId = 3;
                myDbContext.SaveChanges();
            }
            else//usuario entidad
            {
               
                    var actividad = myDbContext.Actividad.Where(x => x.Id == actividadId).FirstOrDefault();
                    var domicilio = myDbContext.Domicilio.Where(x => x.ActividadId == actividadId).FirstOrDefault();
                    var fechaActividades = myDbContext.FechaActividad.Where(x => x.ActividadId == actividadId).ToList();
                    var formularioDinamico = myDbContext.FormularioDinamico.Where(x => x.ActividadId == actividadId).FirstOrDefault();
                    if (formularioDinamico != null)
                    {
                        formularioDinamico.DeletedAt = DateTime.UtcNow;
                        var campos = myDbContext.Campos.Where(x => x.FormularioDinamicoId == formularioDinamico.Id).ToList();
                        foreach(var cam in campos)
                        {
                            cam.DeletedAt = DateTime.UtcNow;
                        }
                    }
                    foreach (var fechaActivida in fechaActividades)
                    {
                        fechaActivida.DeletedAt = DateTime.UtcNow;
                    }

                    domicilio.DeletedAt = DateTime.UtcNow;
                    actividad.DeletedAt = DateTime.UtcNow;
                    actividad.EstadoId = 10; //cancelado osea eliminado
                    myDbContext.SaveChanges();
                
               
               

            }
       
            
        }
        public void MandarRehacerFormuDinamico(RehacerFormuDinamico form)
        {
            MotivoRechazoFormDinamico motivoNuevo = new MotivoRechazoFormDinamico();
            List<CampoRechazado> campoRechazados = new List<CampoRechazado>();

            motivoNuevo.ActividadId = form.ActividadId;
            motivoNuevo.CreatedAt = DateTime.UtcNow;
            motivoNuevo.DescripcionMotivo = form.DescripcionMotivo;
            motivoNuevo.UsuarioId = form.UsuarioId;
            motivoNuevo.EntidadId = form.EntidadId;
            motivoNuevo.FormularioDinamicoId = form.FormularioDinamicoId;
            myDbContext.MotivoRechazoFormDinamico.Add(motivoNuevo);
            myDbContext.SaveChanges();

            CampoRechazado campoRechazadosNuevo = new CampoRechazado();
            foreach(var cam in form.CamposRehacer)
            {
                campoRechazadosNuevo.MotivoRechazoFormDinamicoId = motivoNuevo.Id;
                campoRechazadosNuevo.CampoRechazadoId = cam.Id;                
                campoRechazados.Add(campoRechazadosNuevo);


            }
            this.CambiarEstadoUsuarioInscriptoGeneral(8, motivoNuevo.UsuarioId.Value, motivoNuevo.ActividadId.Value);
           
            myDbContext.CampoRechazado.AddRange(campoRechazados);
            myDbContext.SaveChanges();


        }
        /*Lista de actividades por entidad*/

        /*Eliminadas*/
        public List<Actividad> GetAllActividadesEliminadasByEntidadId(int usuarioId)
        {
            DateTime fechaNull = new DateTime(978361200);//esto es fecha null

            var actividadesEliminadas = myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId &&  x.DeletedAt != fechaNull).ToList();
            return actividadesEliminadas;
        }

        /*Vigentes fecha a un dia de que se empiece*/
        public List<Actividad> GetAllActividadesVigentesByEntidadId(int usuarioId)
        {
            DateTime fechaNull = new DateTime(978361200);//esto es fecha null
           // var fechaActual = new TimeSpan(DateTime.UtcNow.Day, DateTime.UtcNow.Month, DateTime.UtcNow.Year);
            var fecha = DateTime.UtcNow;
            List<Actividad> listaActividades = new List<Actividad>();

            var actividadesSinEliminar = myDbContext.Actividad.Where(x => x.UsuarioId == usuarioId && (x.DeletedAt == fechaNull || x.DeletedAt == null)).ToList();
            if (actividadesSinEliminar.Any())
            {
                foreach (var ac in actividadesSinEliminar)
                {
                    var fechasActividades = myDbContext.FechaActividad.Where(x => x.ActividadId == ac.Id).FirstOrDefault();
                    var fechaInicio = (DateTime)fechasActividades.InicioEvento;
                    if (fechaInicio.Date > fecha.Date.AddDays(1))//ACA ES DONDE TENGO QUE VALIDAR LA FECHA 
                    {
                        var actividad = myDbContext.Actividad.Where(x => x.Id == fechasActividades.ActividadId).FirstOrDefault();
                        listaActividades.Add(actividad);
                    }
                        
                }
            }
            
            return listaActividades;
        }


    }
}
