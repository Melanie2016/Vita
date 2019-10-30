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
           ('Clases de teatro'
           ,'En las clases de teatro el alumno tiene la posibilidad de explorar una nueva forma de ver el mundo y de relacionarse con él, sobre el escenario y debajo de él.'
           ,10
           ,30
           ,300
           ,'2019-11-07'
           ,'2019-11-07'
           ,1
           ,20
           ,5
           ,22
           ,570
           ,1
           ,NULL
           ,'2019-10-29'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\melan\source\repos\Vita\Vita\Content\images\teatro.jpg', Single_Blob) as img)
--FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\teatro.jpg', Single_Blob) as img)
where Id=7

