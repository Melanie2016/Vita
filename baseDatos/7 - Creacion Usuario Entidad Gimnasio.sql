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
           ('Oxigeno Gym'
           ,null
           ,null
           ,null
           ,null
           ,'oxyGymLlavalol@gmail.com'
           ,552
           ,1142986171
           ,null
           ,'OxiGym'
           ,'1234'
           ,'www.facebook.com/llavalloloxigenogym/'
           ,'Ofrece el desarrollo de actividades físicas que proporcionan placer, satisfacción y bienestar. Intentando cumplir los objetivos, expectativas y necesidades de nuestros clientes.'
           ,2
           ,null
           ,'2019-11-08'
           ,null
           ,null)
GO

Update Usuario set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\gym_llavallol.jpg', Single_Blob) as img)
/*FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\gym_llavallol.jpg', Single_Blob) as img) Para Angie*/
where Id=1 /*UsuarioId*/

