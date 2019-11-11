USE [Vita]
GO

INSERT INTO [dbo].[Usuario]
           ([Nombre]
           ,[Apellido]
           ,[FechaNacimiento]
           ,[SexoId]
           ,[Dni]
           ,[Email]
           ,[LocalidadId]
           ,[Celular]
           ,[Telefono]
           ,[UsuarioName]
           ,[Pass]
           ,[SitioWeb]
           ,[SobreMi]
           ,[RolId]
           ,[Foto]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Dirección de Deporte y Recreación Ramos Mejia'
           ,null
           ,null
           ,null
           ,null
           ,'info@ramosmejia.com'
           ,764 /*IdLocalidad*/
           ,1144693091
           ,null
           ,'Ramos'
           ,'1234'
           ,'www.ramosmejia.com/'
           ,'La actividad física saludable no se detiene en la Dirección de Deporte y Recreación Ramos Mejia'
           ,2
           ,null
           ,'2019-11-08'
           ,null
           ,null)
GO

Update Usuario set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\ramos-mejia.jpg', Single_Blob) as img)
/*FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\ramos-mejia.jpg', Single_Blob) as img) Para Angie*/
where Id=2 /*UsuarioId*/

