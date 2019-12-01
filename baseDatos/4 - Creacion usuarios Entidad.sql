/*Creacion usuario ENTIDAD GIMNASIO*/

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
           ,'Ofrecemos el desarrollo de actividades f�sicas que proporcionan placer, satisfacci�n y bienestar. Intentando cumplir los objetivos, expectativas y necesidades de nuestros clientes.'
           ,2
           ,'~/Content/images/gym_llavallol.jpg'
           ,'2019-11-08'
           ,null
           ,null)

GO

/*USUARIO ENTIDAD RAMOS*/
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
           ('Direcci�n de Deporte y Recreaci�n Ramos Mejia'
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
           ,'La actividad f�sica saludable no se detiene en la Direcci�n de Deporte y Recreaci�n Ramos Mejia'
           ,2
           ,'~/Content/images/ramos-mejia.jpg'
           ,'2019-11-08'
           ,null
           ,null)
GO

/*USUARIO ENTIDAD PROFE ARTE*/
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
           ,'Profesora con m�s de 10 a�os de experiencia dando clases de arte y dibujo para todas las edades'
           ,2
           ,'~/Content/images/person_5.jpg'
           ,'2019-11-08'
           ,null
           ,null)
GO

/*Creacion Usuario Entidad Tour BsAs*/
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

/*Creacion Usuario Entidad ProfeTeatro*/
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
           ,'~/Content/images/carla.jpg'
           ,'2019-11-11'
           ,null
           ,null)
GO

/*Creacion Usuario Entidad torneo*/
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
           ,'El Buenos Aires Rowing es un club de familias o de personas solas a las que les guste la vida sana, que amen la naturaleza y cultiven la amistad en un marco de tradici�n y mesura.'
           ,2
           ,'~/Content/images/club.jpg'
           ,'2019-11-11'
           ,null
           ,null)
GO

/*ULSA*/
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
           ('Ulsa'
           ,null
           ,null
           ,null
           ,null
           ,'info@ulsa.com.ar'
           ,600 /*LocalidadId*/
           ,1127814553
           ,null
           ,'Ulsa'
           ,'1234'
           ,'www.ulsa.com.ar'
           ,'Somos ULSA, una Fundaci�n sin fines de lucro conformada por un equipo multidisciplinario de profesionales universitarios, terciarios y estudiantes avanzados comprometidos con la tem�tica diversidad y derechos humanos, usuarios de Lengua de Se�as Argentina, LSA.'
           ,2
           ,'~/Content/images/ulsa.png'
           ,'2019-11-23'
           ,null
           ,null)

GO