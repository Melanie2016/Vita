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
           ('Torneo de truco'
           ,'Habrá premios para los tríos que finalicen en el primer, segundo y tercer lugar del torneo. Será para recaudar fondos para el hospital de niños'
           ,28
		   ,70
           ,200
           ,'2019-11-02'
           ,'2019-11-02'
           ,1
           ,60
           ,2
           ,9
           ,256
           ,1
           ,NULL
           ,'2019-10-29'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
<<<<<<< HEAD
FROM Openrowset( Bulk 'C:\Users\melan\source\repos\Vita\Vita\Content\images\truco.jpg', Single_Blob) as img)
--FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\truco.jpg', Single_Blob) as img)
=======
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\truco.jpg', Single_Blob) as img)
>>>>>>> 879b8cca0edaf12be423c96c3e6f076d9f70373d
where Id=8

