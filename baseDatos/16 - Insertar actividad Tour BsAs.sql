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
           ('Visita guiada por Buenos Aires'
           ,'En este tour recorreremos Buenos Aires al completo, disfrutando de los principales barrios, avenidas y monumentos de la ciudad. Esta visita es la forma ideal de comenzar a conocer la Ciudad del Tango. el primer lugar del recorrido será la Avenida 9 de Julio, la más importante de Buenos Aires, donde veremos el Teatro Colón y el Obelisco, el monumento más emblemático de la ciudad.

Llegando a la Plaza de Mayo, epicentro histórico, político y funcional, veremos tres de los edificios más importantes de Buenos Aires, la Catedral Metropolitana, la Casa Rosada y el Cabildo.

Continuando hacia el sur cruzaremos el Barrio de San Telmo y, pasando por el Parque Lezama, llegaremos a La Boca. En La Boca veremos el estadio del Boca Juniors y pararemos en el Caminito, la calle más colorista y mágica de la ciudad.

Cruzando la ciudad de punta a punta atravesaremos Puerto Madero (la zona más nueva de la ciudad) y Retiro (y la plaza de San Martín) hasta llegar a Palermo, una de las zonas más exclusivas de Buenos Aires. Esta zona acoge naturaleza, vida nocturna, embajadas, museos y monumentos.

En seguida, circularemos por el sofisticado barrio de La Recoleta, una zona de elegantes cafés, tiendas y restaurantes. El tour finalizará en la zona céntrica de Buenos Aires, en la Avenida Córdoba.'
           ,18
           ,70
           ,1100
           ,60
           ,6
           ,25
           ,5467 /*Recoleta*/
           ,4 /*UsuarioId*/
           ,NULL
           ,'2019-11-11'
           ,NULL
           ,NULL
           ,NULL)
GO

Update Actividad set Foto = 
(SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\A307508\Source\Repos\Vita\Vita\Content\images\casa-rosada.jpg', Single_Blob) as img)
where Id=6 /*ActividadId*/


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
           ,'2019-11-25'
           ,'2019-11-25'
           ,'13:00:00'
           ,'17:00:00'
           ,6) /*ActividadId*/
GO