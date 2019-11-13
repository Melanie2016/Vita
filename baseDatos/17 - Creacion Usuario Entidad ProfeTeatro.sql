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
           ('Prof.Carla'
           ,null
           ,null
           ,null
           ,null
           ,'caractriz@gmail.com'
           ,570 /*Lomas de Zamora*/
           ,1123459867
           ,null
           ,'Carla'
           ,'1234'
           ,'www.tallerdeteatro.com.ar'
           ,'Cada maestro tiene su enfoque personal respecto del trabajo con el futuro actor. No hay una "única manera" de guiar al otro en el camino de la actuación, por eso quizás lo más importante sea lo que cada alumno "trae a la clase" y la fuerza de su deseo. Mi objetivo es lograr que cada cual se encuentre con sus potencialidades y logre crear, con ellas, en la escena. Para esto confío en cuatro aspectos que estimulo y trabajo en mis clases: sabiduría,capacidad,sensibilidad y fuerza de la acción'
           ,2
           ,'~/Content/images/carla.jpg'
           ,'2019-11-11'
           ,null
           ,null)
GO

