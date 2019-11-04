USE [Vita]
GO

INSERT INTO [dbo].[Actividad]
           ([Titulo]
           ,[Descripcion]
           ,[EdadMinima]
           ,[EdadMaxima]
           ,[Precio]
           ,[FechaDesde]
           ,[FechaHasta]
           ,[CantidadDias]
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
           ,'Zumba al aire libre y gratuito. Actividad f�sica de bajo impacto con la combinaci�n de baile y gimnasia localizada que combate el estr�s y mejora la salud'
           ,18
           ,70
           ,NULL
           ,'2019-10-27'
           ,'2019-11-27'
           ,3
           ,20
           ,1
           ,3
           ,764
           ,1 /*UsuarioId*/
           ,NULL
           ,'2019-10-26'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\Zumba-aire-libre.jpg', Single_Blob) as img)*/ /*PARA VALE*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\Zumba-aire-libre.jpg', Single_Blob) as img) /*PARA ANGIE*/
where Id=2 /*ActividadId*/

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
           ,1 /*UsuarioId*/
           ,2 /*ActividadId*/
           ,null)
GO