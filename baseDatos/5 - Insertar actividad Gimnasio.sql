USE [Vita]
GO

INSERT INTO [dbo].[Actividad]
           ([Titulo]
           ,[Descripcion]
           ,[EdadMinima]
           ,[EdadMaxima]
           ,[Precio]
           ,[CantidadCupo]
           ,[CategoriaId]
           ,[SubcategoriaId]
           ,[LocalidadId]
           ,[UsuarioId]
           ,[Foto]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt]
           ,[ConUsuarioPendiente] 
		   ,[EstadoId])
     VALUES
           ('Zumba Kids'
           ,'Las clases de Zumba® Kids ofrecen rutinas pensadas para niños sobre la base de las coreografías originales de Zumba®. Los pasos se aprenden poco a poco, y agregamos juegos, actividades y elementos de exploración cultural a la estructura de la clase. Ayuda a desarrollar un estilo de vida saludable e incorpora el ejercicio físico como una parte natural de la vida de los niños al hacer que el ejercicio sea divertido. Las clases incorporan elementos clave de desarrollo infantil como liderazgo, respeto, trabajo en equipo, confianza, autoestima, memoria, creatividad, coordinación, conciencia cultural.'
           ,7
           ,11
           ,100
           ,30
           ,3
           ,3
           ,552 /*LocalidadId*/
           ,1 /*UsuarioId*/
           ,'~/Content/images/Zumba-kids.jpg'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL  /*TieneFormularioDinamico*/
		   ,7) /*EstadoId*/
GO

/*DOMICILIO*/
INSERT INTO [dbo].[Domicilio]
           ([NombreCalle]
           ,[NumeroCalle]
           ,[NumeroPiso]
           ,[NumeroDepartamento]
           ,[CodigoPostal]
           ,[LocalidadId]
           ,[UsuarioId]
           ,[ActividadId]
           ,[FechaRegistroEnDb])
     VALUES
           ('Luzuriaga'
           ,15
           ,null
           ,null
           ,'B1836'
           ,552 /*LocalidadId*/
           ,1 /*UsuarioId*/
           ,1 /*ActividadId*/
           ,null)
GO

/*FECHAS*/
INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (1 /*Lunes*/
           ,'2019-11-08'
           ,'2019-12-30'
           ,'14:00:00'
           ,'15:00:00'
           ,1) /*ActividadId*/
GO

INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (3 /*Miercoles*/
           ,'2019-11-08'
           ,'2019-12-30'
           ,'14:00:00'
           ,'15:00:00'
           ,1) /*ActividadId*/
GO