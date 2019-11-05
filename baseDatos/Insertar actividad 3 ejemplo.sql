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
           ('Zumba'
           ,'Dejá que te mueva! Zumba es una disciplina de baile muy divertida, que pueden practicar tanto hombres como mujeres. Incrementa tu energía y bienestar'
           ,18
           ,40
           ,100
           ,'2019-10-27'
           ,'2019-11-27'
           ,3
           ,20
           ,3
           ,3
           ,5176
           ,1 /*UsuarioId*/
           ,NULL
           ,'2019-10-26'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\Zumba-adultos.jpg', Single_Blob) as img)*/ /*PARA VALE*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\Zumba-adultos.jpg', Single_Blob) as img) /*PARA ANGIE*/
where Id=3 /*ActividadId*/

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
           ('Rincón'
           ,3170
           ,null
           ,null
           ,'B1754'
           ,5176
           ,1 /*UsuarioId*/
           ,3 /*ActividadId*/
           ,null)
GO