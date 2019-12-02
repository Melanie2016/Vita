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
		   ,[Url]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt]
           ,[ConUsuarioPendiente] 
		   ,[EstadoId])
     VALUES
           ('Clases de Crossfit'
           ,'El crossfit es una disciplina deportiva que se basa en ejercicios intensos para mejorar la condición física. Al tratarse de un entrenamiento funcional, se basa en movimientos multiarticulares o compuestos, muy diferentes a los típicos que se hacen en un gimnasio tradicional, que se concentran en un músculo o grupo muscular concreto. Es un programa de acondicionamiento físico basado en un entrenamiento constantemente variado de movimientos funcionales, y que se desarrolla con una alta intensidad”.'
           ,18
           ,45
           ,200
           ,30
           ,3
           ,15
           ,552
           ,1 /*UsuarioId*/
		   ,'~/Content/images/crossfit.png'
           ,'https://www.youtube.com/watch?v=VeEQw2o8F5w'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL  /*TieneFormularioDinamico*/
		   ,7)
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (8 /*ActividadId*/
           ,2 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
GO

INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (8 /*ActividadId*/
           ,3 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
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
           ,8 /*ActividadId*/
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
           (2 /*Martes*/
           ,'2019-11-08'
           ,'2019-12-30'
           ,'10:30:00'
           ,'11:30:00'
           ,8) /*ActividadId*/
GO

INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (4 /*Jueves*/
           ,'2019-11-08'
           ,'2019-12-30'
           ,'20:00:00'
           ,'21:00:00'
           ,8) /*ActividadId*/
GO