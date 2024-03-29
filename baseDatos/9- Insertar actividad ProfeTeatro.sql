USE [Vita]
GO

INSERT INTO [dbo].[Actividad]
           ([Titulo]
           ,[Descripcion]
           ,[EdadMinima]
           ,[EdadMaxima]
           ,[Precio]
           ,[CantidadCupo]
           ,[CategoriaId]
           ,[SubcategoriaId]
           ,[LocalidadId]
           ,[UsuarioId]
           ,[Foto]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt]
           ,[ConUsuarioPendiente]
		   ,[EstadoId])
     VALUES
           ('Clases de teatro'
           ,'En las clases de teatro el alumno tiene la posibilidad de explorar una nueva forma de ver el mundo y de relacionarse con �l, sobre el escenario y debajo de �l. La clase se divide en dos partes.

Primera parte:
Se trabaja en forma individual o grupal seg�n la clase.

Individual:
ejercicios del actor sobre s� mismo. Etapa fundamental para que cada uno reconozca sus dificultades y potencialidades, en tanto aprende a distanciar el trabajo de s� mismo para adentrarse en los personajes y los textos ajenos.

Grupal:
Ejercicios del actor con los otros. Etapa fundamental para que tomen conciencia del trabajo en grupo, sin el cual no es posible el hecho teatral.

Segunda parte:
Se trabaja en subgrupos.

Subgrupos:
Ejercicios en d�os, tr�os � cuartetos. Aqu� es donde entra a tallar el armado de escenas teatrales a partir de textos y/o improvisaciones, seg�n el nivel y el inter�s de cada uno. Tambi�n es posible trabajar mon�logos o cuentos en forma individual.

Fundamentos
Para el armado del taller me baso en mi experiencia como actriz y docente. A lo largo de estos a�os he ido seleccionado los t�picos que me parecen fundamentales para introducir en el arte de la actuaci�n a quien tenga la inquietud. Entiendo que es muy importante el trabajo del alumno sobre s� mismo en el marco del aprendizaje teatral. Desde ya que siempre estoy abierta a escuchar las particularidades de cada nuevo curso y adaptar, impulsar � detener lo que sea necesario seg�n los requerimientos del grupo.'
           ,18
           ,40
           ,500
           ,20
           ,5
           ,32
           ,570
           ,5 /*UsuarioId*/
           ,'~/Content/images/teatro.jpg'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL  /*TieneFormularioDinamico*/
		   ,7) /*EstadoId*/
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (5 /*ActividadId*/
           ,2 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
GO

/*SEGMENTO*/
INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (5 /*ActividadId*/
           ,3 /*Segmento*/
           ,'2019-11-08'
           ,null
           ,null)
GO

/*DOMICILIO*/
INSERT INTO [dbo].[Domicilio]
           ([NombreCalle]
           ,[NumeroCalle]
           ,[NumeroPiso]
           ,[NumeroDepartamento]
           ,[CodigoPostal]
           ,[LocalidadId]
           ,[UsuarioId]
           ,[ActividadId]
           ,[FechaRegistroEnDb])
     VALUES
           ('Av. Pres. Hip�lito Yrigoyen'
           ,9437
           ,null
           ,null
           ,'B1828'
           ,570
           ,5 /*UsuarioId*/
           ,5 /*ActividadId*/
           ,null)
GO



/*FECHAS*/
INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (1 /*Lunes*/
           ,'2019-11-08'
		   ,'2019-12-30'
           ,'09:00:00'
           ,'11:00:00'
           ,5) /*ActividadId*/
GO

INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (3 /*Miercoles*/
           ,'2019-11-08'
		   ,'2019-12-30'
           ,'13:00:00'
           ,'15:00:00'
           ,5) /*ActividadId*/
GO

INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (5 /*Viernes*/
           ,'2019-11-08'
		   ,'2019-12-30'
           ,'09:00:00'
           ,'11:00:00'
           ,5) /*ActividadId*/
GO