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
           ('Tour Buenos Aires'
           ,null
           ,null
           ,null
           ,null
           ,'infoToursBsAs@gmail.com'
           ,5467 /*Recoleta*/
           ,null
           ,50309100
           ,'TourBsAs'
           ,'1234'
           ,'www.tourbuenosaires.com/'
           ,'Ofrecemos visitas guiadas por distintos lugares de la ciudad de Bs As. Las posibilidades incluyen tanto a los atractivos tradicionales a los que acostumbramos a llamar �cl�sicos� como as� tambi�n a los rincones menos transitados de la ciudad, aquellos que guardan un particular encanto que los hace �nicos. Sencillamente, �eleg� el que m�s te guste y descubr� Buenos Aires!'
           ,2
           ,'~/Content/images/bsas.jpg'
           ,'2019-11-11'
           ,null
           ,null)
GO

