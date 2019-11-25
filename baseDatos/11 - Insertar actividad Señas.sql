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
		   ,[Url]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt]
           ,[ConUsuarioPendiente] 
		   ,[EstadoId])
     VALUES
           ('Curso de Lengua de Señas'
           ,'ULSA dicta Lengua de Señas Argentina en tres niveles, inicial, intermedio y avanzado y seminarios de perfeccionamiento para intérpretes. La modalidad de cursada es presencial, de alto nivel formativo, dirigida a personas oyentes con o sin conocimientos previos de lengua de señas: docentes, profesionales, estudiantes universitarios, terciarios y de últimos años del secundario, auxiliares de la salud y para público en general que desee aprender esta rica lengua llegando a ser parte de acciones concretas en su lugar de desempeño. También pueden participar personas Sordas o hipoacúsicas y sus familiares, quienes estarán en contacto directo con los instructores y docentes Sordos. El curso será durante el mes de diciembre con un costo de $1000'
           ,7
           ,60
           ,1000
           ,20
           ,4
           ,17
           ,600 /*LocalidadId*/
           ,7 /*UsuarioId*/
           ,'~/Content/images/actividad_ulsa.jpg'
		   ,'https://www.youtube.com/watch?v=OXa4y4wMuqg&feature=emb_logo'
           ,'2019-11-23'
           ,NULL
           ,NULL
           ,1  /*TieneFormularioDinamico*/
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
           (7 /*ActividadId*/
           ,1 /*Segmento*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (7 /*ActividadId*/
           ,2 /*Segmento*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[ActividadSegmento]
           ([ActividadId]
           ,[SegmentoId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           (7 /*ActividadId*/
           ,3 /*Segmento*/
           ,'2019-11-23'
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
           ('Hipólito Yrigoyen'
           ,1961
           ,null
           ,null
           ,'B7600'
           ,600 /*LocalidadId*/
           ,7 /*UsuarioId*/
           ,7 /*ActividadId*/
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
           ,'2019-12-09'
           ,'2019-12-30'
           ,'09:00:00'
           ,'11:00:00'
           ,7) /*ActividadId*/
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
           ,'2019-12-09'
           ,'2019-12-30'
           ,'15:00:00'
           ,'16:00:00'
           ,7) /*ActividadId*/
GO

/*FORMULARIO DINAMICO*/
INSERT INTO [dbo].[FormularioDinamico]
           ([Titulo]
           ,[Descripcion]
           ,[ActividadId]
           ,[EntidadId]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Ficha de Inscripción'
           ,'Ficha de inscripción para el curso de Lengua de señas'
           ,7 /*ActividadId*/
           ,7 /*EntidadId*/
           ,'2019-11-23'
           ,null
           ,null)
GO

/*CAMPOS*/
INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Nombre completo'
           ,1 /*FormularioDinamicoId*/
           ,1 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Edad'
           ,1 /*FormularioDinamicoId*/
           ,3 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('D.N.I'
           ,1 /*FormularioDinamicoId*/
           ,3 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('E-mail'
           ,1 /*FormularioDinamicoId*/
           ,1 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Teléfono/WhatsApp'
           ,1 /*FormularioDinamicoId*/
           ,3 /*TipoDato*/
           ,0 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('¿Por qué querés estudiar LSA, o seguir estudiando LSA?'
           ,1 /*FormularioDinamicoId*/
           ,2 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Indicar nivel en el que se inscribe (INICIAL - INTERMEDIO - AVANZADO)'
           ,1 /*FormularioDinamicoId*/
           ,1 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Adjuntar Copia del DNI (Foto)'
           ,1 /*FormularioDinamicoId*/
           ,5 /*TipoDato*/
           ,1 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO

INSERT INTO [dbo].[Campos]
           ([Nombre]
           ,[FormularioDinamicoId]
           ,[TipoDatoCampoId]
           ,[Obligatorio]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[DeletedAt])
     VALUES
           ('Si ya has cursado en ULSA, adjunta la copia (Foto) del último certificado de cursada aprobada (solo en caso de haber cursado anteriormente).'
           ,1 /*FormularioDinamicoId*/
           ,5 /*TipoDato*/
           ,0 /*Obligatorio*/
           ,'2019-11-23'
           ,null
           ,null)
GO
