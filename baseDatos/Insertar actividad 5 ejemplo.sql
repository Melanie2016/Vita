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
           ('Taller de Arte'
           ,'Pintura-Dibujo-Chicos-Adultos. Un espacio pensado y equipado para disfrutar, jugar, explorar y experimentar con ideas, objetos y situaciones.'
           ,18
           ,70
           ,100
           ,'2019-10-29'
           ,'2019-10-30'
           ,2
           ,25
           ,4
           ,15
           ,5475
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
--FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\taller_arte.jpg', Single_Blob) as img)
FROM Openrowset( Bulk 'C:\Users\melan\source\repos\Vita\Vita\Content\images\taller_arte.jpg', Single_Blob) as img)
=======
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\taller_arte.jpg', Single_Blob) as img)
>>>>>>> 879b8cca0edaf12be423c96c3e6f076d9f70373d
where Id=5

