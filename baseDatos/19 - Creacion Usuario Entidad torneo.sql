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
           ,'~/Content/images/club.jpg'
           ,'2019-11-11'
           ,null
           ,null)
GO
