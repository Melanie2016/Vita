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
           ,'~/Content/images/gym_llavallol.jpg'
           ,'2019-11-08'
           ,null
           ,null)
GO

