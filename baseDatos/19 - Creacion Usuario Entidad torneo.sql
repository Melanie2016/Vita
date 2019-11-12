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
           ('BsAsRowing'
           ,null
           ,null
           ,null
           ,null
           ,'BsAsRowing@gmail.com'
           ,896 /*IdLocalidad Tigre*/
           ,1140820056
           ,null
           ,'BARowing'
           ,'1234'
           ,'www.buenosairesrowing.com.ar'
           ,'El Buenos Aires Rowing es un club de familias o de personas solas a las que les guste la vida sana, que amen la naturaleza y cultiven la amistad en un marco de tradición y mesura.'
           ,2
           ,null
           ,'2019-11-11'
           ,null
           ,null)
GO

Update Usuario set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\club.jpg', Single_Blob) as img)
/*FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\club.jpg', Single_Blob) as img) Para Angie*/
where Id=6 /*UsuarioId*/

