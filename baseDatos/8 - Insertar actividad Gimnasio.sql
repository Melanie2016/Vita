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
           ('Zumba'
           ,'Dej� que te mueva! Zumba es una disciplina de baile muy divertida, que pueden practicar tanto hombres como mujeres. Incrementa tu energ�a y bienestar. Fusionamos movimientos de alta y baja intensidad para que disfrutes de una fiesta de acondicionamiento f�sico con intervalos para quemar calor�as. Una vez que los ritmos latinos y de todo el mundo se apoderen de ti, entender�s por qu� se suele decir que las clases de Zumba" Fitness son un ejercicio disfrazado. �Gran efectividad? S�. �M�xima diversi�n? Tambi�n.'
           ,18
           ,40
           ,100
           ,20
           ,3
           ,3
           ,552 /*LocalidadId*/
           ,1 /*UsuarioId Gimnasio*/
           ,NULL
           ,'2019-11-08'
           ,NULL
           ,NULL
           ,NULL)
GO

/*FOTO*/
Update Actividad set Foto = 
(SELECT BulkColumn 
/*FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\Zumba-adultos.jpg', Single_Blob) as img)*/ /*PARA VALE*/
FROM Openrowset( Bulk 'C:\Proyecto final\tp final posta\Vita\Vita\Content\images\Zumba-adultos.jpg', Single_Blob) as img) /*PARA ANGIE*/
where Id=2 /*ActividadId*/

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
           ,2 /*ActividadId*/
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
           ,null
           ,null
           ,'10:00:00'
           ,'11:00:00'
           ,2) /*ActividadId*/
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
           ,'18:00:00'
           ,'19:00:00'
           ,2) /*ActividadId*/
GO