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
           ,[Compleja])
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
           ,NULL
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL)
GO

/*FOTO*/
Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\Zumba-aire-libre.jpg', Single_Blob) as img)*/ /*PARA VALE*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\Zumba-aire-libre.jpg', Single_Blob) as img) /*PARA ANGIE*/
where Id=4 /*ActividadId*/

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
           ,4 /*ActividadId*/
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
           ,'2019-11-29'
           ,'2019-11-29'
           ,'09:00:00'
           ,'11:00:00'
           ,4) /*ActividadId*/
GO
