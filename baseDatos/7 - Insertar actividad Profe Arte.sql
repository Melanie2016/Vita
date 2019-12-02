/*Insertar actividad Profe Arte--------------------------------------------------------------------------------*/
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
           ('Taller de Arte'
           ,'Pintura-Dibujo-Chicos-Adultos. Un espacio pensado y equipado para disfrutar, jugar, explorar y experimentar con ideas, objetos y situaciones.'
           ,11
           ,70
           ,150
           ,20
           ,4
           ,23
           ,5475 /*LocalidadId Villa Devoto*/
           ,3 /*UsuarioId*/
           ,'~/Content/images/taller_arte.jpg'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL /*TieneFormularioDinamico*/
		   ,7) /*EstadoId*/
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (3 /*ActividadId*/
           ,1 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (3 /*ActividadId*/
           ,2 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (3 /*ActividadId*/
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
           ('Av. Lincoln'
           ,1986
           ,null
           ,null
           ,null
           ,5475
           ,3 /*UsuarioId*/
           ,3 /*ActividadId*/
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
           ,'15:00:00'
           ,'16:00:00'
           ,3) /*ActividadId*/
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
           (5 /*Viernes*/
           ,'2019-11-08'
           ,'2019-12-30'
           ,'11:00:00'
           ,'12:00:00'
           ,3) /*ActividadId*/
GO