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
           ,[Compleja])
     VALUES
           ('Clases de teatro'
           ,'En las clases de teatro el alumno tiene la posibilidad de explorar una nueva forma de ver el mundo y de relacionarse con él, sobre el escenario y debajo de él. La clase se divide en dos partes.

Primera parte:
Se trabaja en forma individual o grupal según la clase.

Individual:
ejercicios del actor sobre sí mismo. Etapa fundamental para que cada uno reconozca sus dificultades y potencialidades, en tanto aprende a distanciar el trabajo de sí mismo para adentrarse en los personajes y los textos ajenos.

Grupal:
Ejercicios del actor con los otros. Etapa fundamental para que tomen conciencia del trabajo en grupo, sin el cual no es posible el hecho teatral.

Segunda parte:
Se trabaja en subgrupos.

Subgrupos:
Ejercicios en dúos, tríos ó cuartetos. Aquí es donde entra a tallar el armado de escenas teatrales a partir de textos y/o improvisaciones, según el nivel y el interés de cada uno. También es posible trabajar monólogos o cuentos en forma individual.

Fundamentos
Para el armado del taller me baso en mi experiencia como actriz y docente. A lo largo de estos años he ido seleccionado los tópicos que me parecen fundamentales para introducir en el arte de la actuación a quien tenga la inquietud. Entiendo que es muy importante el trabajo del alumno sobre sí mismo en el marco del aprendizaje teatral. Desde ya que siempre estoy abierta a escuchar las particularidades de cada nuevo curso y adaptar, impulsar ó detener lo que sea necesario según los requerimientos del grupo.'
           ,18
           ,40
           ,500
           ,20
           ,5
           ,22
           ,570
           ,5 /*UsuarioId*/
           ,NULL
           ,'2019-11-11'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\teatro.jpg', Single_Blob) as img)
where Id=7 /*ActividadId*/


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
           ('Av. Pres. Hipólito Yrigoyen'
           ,9437
           ,null
           ,null
           ,'B1828'
           ,570
           ,5 /*UsuarioId*/
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
           (1
           ,null
           ,null
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
           (3
           ,null
           ,null
           ,'13:00:00'
           ,'15:00:00'
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
           (5
           ,null
           ,null
           ,'09:00:00'
           ,'11:00:00'
           ,7) /*ActividadId*/
GO