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
           ('Visita guiada por Buenos Aires'
           ,'En este tour recorreremos Buenos Aires al completo, disfrutando de los principales barrios, avenidas y monumentos de la ciudad. Esta visita es la forma ideal de comenzar a conocer la Ciudad del Tango.'
           ,18
           ,70
           ,700
           ,'2019-11-06'
           ,'2019-11-06'
           ,1
           ,40
           ,6
           ,25
           ,3358
           ,1
           ,NULL
           ,'2019-10-29'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\melan\source\repos\Vita\Vita\Content\images\casa-rosada.jpg', Single_Blob) as img)
--FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\casa-rosada.jpg', Single_Blob) as img)
where Id=6

