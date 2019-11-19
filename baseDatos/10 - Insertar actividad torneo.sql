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
           ('Torneo de truco'
           ,'Habrá premios para los tríos que finalicen en el primer, segundo y tercer lugar del torneo. Será para recaudar fondos para el hospital de niños'
           ,28
		   ,70
           ,200
           ,40
           ,2
           ,9
           ,896 /*IdLocalidad Tigre*/
           ,6 /*UsuarioId*/
           ,'~/Content/images/truco.jpg'
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
           ('Gral. Bartolomé Mitre'
           ,226
           ,null
           ,null
           ,null
           ,896 /*IdLocalidad Tigre*/
           ,6 /*UsuarioId*/
           ,6 /*ActividadId*/
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
           ,'2019-12-06'
           ,'2019-12-06'
           ,'10:00:00'
           ,'14:00:00'
           ,6) /*ActividadId*/
GO
