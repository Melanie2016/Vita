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
           ,'Cada maestro tiene su enfoque personal respecto del trabajo con el futuro actor. No hay una "�nica manera" de guiar al otro en el camino de la actuaci�n, por eso quiz�s lo m�s importante sea lo que cada alumno "trae a la clase" y la fuerza de su deseo. Mi objetivo es lograr que cada cual se encuentre con sus potencialidades y logre crear, con ellas, en la escena. Para esto conf�o en cuatro aspectos que estimulo y trabajo en mis clases: sabidur�a,capacidad,sensibilidad y fuerza de la acci�n'
           ,2
           ,null
           ,'2019-11-11'
           ,null
           ,null)
GO

Update Usuario set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\carla.jpg', Single_Blob) as img)
/*FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\gym_llavallol.jpg', Single_Blob) as img) Para Angie*/
where Id=5 /*UsuarioId*/

