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
           ('Profesora de Arte'
           ,null
           ,null
           ,null
           ,null
           ,'clasesDeArte@gmail.com'
           ,5475 /*IdLocalidad Villa Devoto*/
           ,1112344567
           ,null
           ,'ProfeArte'
           ,'1234'
           ,null
           ,'Profesora con más de 10 años de experiencia dando clases de arte y dibujo para todas las edades'
           ,2
           ,null
           ,'2019-11-08'
           ,null
           ,null)
GO

/*FOTO*/
Update Usuario set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\person_5.jpg', Single_Blob) as img)
/*FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\person_5.jpg', Single_Blob) as img) Para Angie*/
where Id=3 /*UsuarioId*/

