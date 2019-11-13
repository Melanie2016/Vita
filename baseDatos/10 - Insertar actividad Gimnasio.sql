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
           ('Clases de Crossfit'
           ,'El crossfit es una disciplina deportiva que se basa en ejercicios intensos para mejorar la condición física. Al tratarse de un entrenamiento funcional, se basa en movimientos multiarticulares o compuestos, muy diferentes a los típicos que se hacen en un gimnasio tradicional, que se concentran en un músculo o grupo muscular concreto. Es un programa de acondicionamiento físico basado en un entrenamiento constantemente variado de movimientos funcionales, y que se desarrolla con una alta intensidad”.'
           ,18
           ,45
           ,200
           ,30
           ,3
           ,3
           ,552
           ,1 /*UsuarioId*/
           ,'~/Content/images/crossfit.png'
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL)
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
           ('Luzuriaga'
           ,15
           ,null
           ,null
           ,'B1836'
           ,552 /*LocalidadId*/
           ,1 /*UsuarioId*/
           ,3 /*ActividadId*/
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
           (2 /*Martes*/
           ,null
           ,null
           ,'10:30:00'
           ,'11:30:00'
           ,3) /*ActividadId*/
GO

INSERT INTO [dbo].[FechaActividad]
           ([DiaSemanaId] 
           ,[InicioEvento]
           ,[FinEvento]
           ,[HoraInicio]
           ,[HoraFin]
           ,[ActividadId])
     VALUES
           (4 /*Jueves*/
           ,null
           ,null
           ,'20:00:00'
           ,'21:00:00'
           ,3) /*ActividadId*/
GO