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
           ,'Zumba al aire libre y gratuito. Actividad f�sica de bajo impacto con la combinaci�n de baile y gimnasia localizada que combate el estr�s y mejora la salud. La clase de zumba est� pensada para todo el mundo, mam�s, pap�s y ni�os. El principal objetivo de esta clase aparte de quemar calor�as, es que vengamos todos y en esa hora que asistamos, seamos felices; as� que la invitaci�n est� abierta para todos los que deseen sumarse'
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
           ('Bartolom� Mitre'
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
