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
           ('Visita guiada por Buenos Aires'
           ,'En este tour recorreremos Buenos Aires al completo, disfrutando de los principales barrios, avenidas y monumentos de la ciudad. Esta visita es la forma ideal de comenzar a conocer la Ciudad del Tango. el primer lugar del recorrido ser� la Avenida 9 de Julio, la m�s importante de Buenos Aires, donde veremos el Teatro Col�n y el Obelisco, el monumento m�s emblem�tico de la ciudad.

Llegando a la Plaza de Mayo, epicentro hist�rico, pol�tico y funcional, veremos tres de los edificios m�s importantes de Buenos Aires, la Catedral Metropolitana, la Casa Rosada y el Cabildo.

Continuando hacia el sur cruzaremos el Barrio de San Telmo y, pasando por el Parque Lezama, llegaremos a La Boca. En La Boca veremos el estadio del Boca Juniors y pararemos en el Caminito, la calle m�s colorista y m�gica de la ciudad.

Cruzando la ciudad de punta a punta atravesaremos Puerto Madero (la zona m�s nueva de la ciudad) y Retiro (y la plaza de San Mart�n) hasta llegar a Palermo, una de las zonas m�s exclusivas de Buenos Aires. Esta zona acoge naturaleza, vida nocturna, embajadas, museos y monumentos.

En seguida, circularemos por el sofisticado barrio de La Recoleta, una zona de elegantes caf�s, tiendas y restaurantes. El tour finalizar� en la zona c�ntrica de Buenos Aires, en la Avenida C�rdoba.'
           ,18
           ,70
           ,1100
           ,60
           ,6
           ,25
           ,5467 /*Recoleta*/
           ,4 /*UsuarioId*/
           ,'~/Content/images/casa-rosada.jpg'
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
           (4 /*ActividadId*/
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
           (4 /*ActividadId*/
           ,3 /*Segmento*/
           ,'2019-11-08'
           ,null
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
           (null
           ,'2019-12-08'
           ,'2019-12-08'
           ,'13:00:00'
           ,'17:00:00'
           ,4) /*ActividadId*/
GO