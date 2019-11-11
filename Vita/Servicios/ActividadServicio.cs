﻿using System;
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
                    // FechaDesde = aux.Actividad.FechasActividad,      //  LO COMENTO PORQUE ME DA ERROR VALE
                    //  FechaHasta = aux.Actividad.FechaHasta

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
                LocalidadId = actividadViewModel.LocalidadId,
                UsuarioId = usuario.Id,
                // Foto= actividad.Foto una actividad puede tener varias fotos
                CreatedAt = DateTime.Now,
                Compleja = actividadViewModel.Compleja,
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
                LocalidadId = actividadViewModel.LocalidadId,
                UsuarioId = usuario.Id,
                ActividadId = actividadNueva.Id,
                FechaRegistroEnDb = DateTime.Now
            };

            myDbContext.Domicilio.Add(domicilioNuevo);
            myDbContext.SaveChanges();
            this.CrearSegmentoActividad(actividadNueva.Id, selectedSegmento);

            //Tiene una fecha de inicio y fin
            if (actividadViewModel.InicioEvento != null)
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
            else
            {
                //Tiene varios dias a la semana con horarios

                //Tiene Lunes
                if (actividadViewModel.HoraInicioLunes != null)
                {
                    FechaActividad fechasActividadLunes = new FechaActividad
                    {
                        DiaSemanaId = 1,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioLunes),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinLunes),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadLunes);
                    myDbContext.SaveChanges();
                }

                //Tiene Martes
                if (actividadViewModel.HoraInicioMartes != null)
                {
                    FechaActividad fechasActividadMartes = new FechaActividad
                    {
                        DiaSemanaId = 2,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioMartes),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinMartes),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadMartes);
                    myDbContext.SaveChanges();
                }

                //Tiene Miércoles
                if (actividadViewModel.HoraInicioMiercoles != null)
                {
                    FechaActividad fechasActividadMiercoles = new FechaActividad
                    {
                        DiaSemanaId = 3,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioMiercoles),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinMiercoles),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadMiercoles);
                    myDbContext.SaveChanges();
                }

                //Tiene Jueves
                if (actividadViewModel.HoraInicioJueves != null)
                {
                    FechaActividad fechasActividadJueves = new FechaActividad
                    {
                        DiaSemanaId = 4,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioJueves),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinJueves),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadJueves);
                    myDbContext.SaveChanges();
                }

                //Tiene Viernes
                if (actividadViewModel.HoraInicioViernes != null)
                {
                    FechaActividad fechasActividadViernes = new FechaActividad
                    {
                        DiaSemanaId = 5,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioViernes),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinViernes),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadViernes);
                    myDbContext.SaveChanges();
                }

                //Tiene Sábado
                if (actividadViewModel.HoraInicioSabado != null)
                {
                    FechaActividad fechasActividadSabado = new FechaActividad
                    {
                        DiaSemanaId = 6,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioSabado),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinSabado),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadSabado);
                    myDbContext.SaveChanges();
                }

                //Tiene Domingo
                if (actividadViewModel.HoraInicioDomingo != null)
                {
                    FechaActividad fechasActividadDomingo = new FechaActividad
                    {
                        DiaSemanaId = 7,
                        HoraInicio = TimeSpan.Parse(actividadViewModel.HoraInicioDomingo),
                        HoraFin = TimeSpan.Parse(actividadViewModel.HoraFinDomingo),
                        ActividadId = actividadNueva.Id
                    };

                    myDbContext.FechaActividad.Add(fechasActividadDomingo);
                    myDbContext.SaveChanges();
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

        public List<Actividad> GetBusquedaAvanzada(string textoIngresado)
        {
            var listaVali = new List<Actividad>();
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

            foreach (var act in lista)
            {
                var actividadValidad = GetActividad(act.Id);
                listaVali.Add(actividadValidad);
            }
            return listaVali;
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
                lista2.Add(act);
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
                lista2.Add(act);
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

        public List<Actividad> GetByEstadoId(int estadoId, int actividadId)
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

        public bool BuscarUsuarioInscriptoEnActividad (int usuarioId, int actividadId)
        {
            var usuarioInscriptoActividad = myDbContext.UsuarioInscriptoActividad.Where(x => x.ActividadId == actividadId && x.UsuarioId == usuarioId).FirstOrDefault();
           bool inscripto = false; 

           if (usuarioInscriptoActividad != null)
            {
                inscripto = true;
            }

            return inscripto;

        }

        public void CambiarEstadoUsuarioInscripto(bool estado, int usuarioId, int actividadId)
        {
            var usuarioIns=myDbContext.UsuarioInscriptoActividad.Where(x => x.UsuarioId == usuarioId && x.ActividadId == actividadId).FirstOrDefault();
             if(estado== true)
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
    }
}