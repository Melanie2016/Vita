/*Insertar actividad RAMOS---------------------------------------------------------------------------------*/

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
           ('Zumba al aire libre'
           ,'Zumba al aire libre y gratuito. Actividad física de bajo impacto con la combinación de baile y gimnasia localizada que combate el estrés y mejora la salud. La clase de zumba está pensada para todo el mundo, mamás, papás y niños. El principal objetivo de esta clase aparte de quemar calorías, es que vengamos todos y en esa hora que asistamos, seamos felices; así que la invitación está abierta para todos los que deseen sumarse'
           ,10
           ,70
           ,NULL
           ,60
           ,1
           ,3
           ,764 /*LocalidId*/
           ,2 /*UsuarioId*/
           ,'~/Content/images/Zumba-aire-libre.jpg'
		   ,'https://www.youtube.com/watch?v=AYS5vglBAjg'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL /*TieneFormularioDinamico*/
		   ,7)/*EstadoId*/
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (2 /*ActividadId*/
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
           ('Bartolomé Mitre'
           ,199
           ,null
           ,null
           ,'B1704'
           ,764
           ,2 /*UsuarioId*/
           ,2 /*ActividadId*/
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
           (null
           ,'2019-12-05'
           ,'2019-12-05'
           ,'09:00:00'
           ,'11:00:00'
           ,2) /*ActividadId*/
GO

/*1era---------------------------------------------------------------------------------*/