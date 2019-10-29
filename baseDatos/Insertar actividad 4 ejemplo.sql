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
           ('Clases de Crossfit'
           ,'El crossfit es una disciplina deportiva que se basa en ejercicios intensos para mejorar la condición física'
           ,18
           ,45
           ,100
           ,'2019-10-27'
           ,'2019-11-27'
           ,5
           ,30
           ,3
           ,3
           ,764
           ,1
           ,NULL
           ,'2019-10-26'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\crossfit.png', Single_Blob) as img)*/  /*PARA VALE*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\crossfit.png', Single_Blob) as img) /*PARA ANGIE*/

where Id=4

