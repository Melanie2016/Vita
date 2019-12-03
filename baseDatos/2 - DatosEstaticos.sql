Use Vita 

SET IDENTITY_INSERT Sexo ON
INSERT INTO Sexo(Id, Descripcion) VALUES (1, 'Femenino');
INSERT INTO Sexo(Id, Descripcion) VALUES (2, 'Masculino');
INSERT INTO Sexo(Id, Descripcion) VALUES (3, 'No quiero definirlo');
SET IDENTITY_INSERT Sexo OFF

/*categoria*/
/*categoria*/
SET IDENTITY_INSERT Categoria ON
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (1, 'Actividades al aire libre', 'Al aire libre');
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (2, 'Campeonatos/Torneos de juegos de mesa', 'Torneos');
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (3, 'Deportes', 'Deportes');
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (4, 'Talleres /Capacitaciones /Cursos', 'Talleres');
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (5, 'Actividades de interés cultural', 'Culturales');
INSERT INTO Categoria(Id, Descripcion, DescCorta) VALUES (6, 'Excursiones', 'Excursiones');
SET IDENTITY_INSERT Categoria OFF

/*SubCategoria*/
SET IDENTITY_INSERT SubCategoria ON
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (1,'Caminata',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (2,'Gimnasia de mantenimiento',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (3,'Zumba al aire libre',1);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (4,'Dominó',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (5,'Ajedrez',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (6,'Damas',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (7,'Chinchón',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (8,'Truco',2);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (9,'AquaGym',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (10,'Yoga',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (11,'Gimnasia',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (12,'Baile, tango, zumba',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (13,'Pilates',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (14,'Spinning',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (15,'Crossfit',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (16,'Funcional',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (17,'Natación',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (18,'Hockey',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (19,'Futboll',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (20,'Voley',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (21,'Basketball',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (22,'Patin artístico',3);


INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (23,'Manualidades, dibujo, pintura',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (24,'Idiomas',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (25,'Música, folclore, coros',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (26,'Reciclado',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (27,'Jardinería',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (28,'Workshop',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (29,'Gastronomia',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (30,'Salud',4);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (31,'Museo',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (32,'Teatro',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (33,'Cine',5);
INSERT INTO SubCategoria(id, Descripcion, CategoriaId) Values (34,'Leer cuentos/ escribir/ cantar',5);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (35,'Visitas guiadas',6);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (36,'Atracciones turísticas',6);
SET IDENTITY_INSERT SubCategoria OFF

/***********************************************/
/*PERFIL*/
SET IDENTITY_INSERT Rol ON
INSERT INTO Rol(Id, Descripcion) Values (1,'Usuario');
INSERT INTO Rol(Id, Descripcion) Values (2,'Entidad');
SET IDENTITY_INSERT Rol OFF

/***********************************************/
/*SEGMENTO*/
SET IDENTITY_INSERT Segmento ON
INSERT INTO Segmento(Id, Descripcion) Values (1,'Niños');
INSERT INTO Segmento(Id, Descripcion) Values (2,'Jovenes');
INSERT INTO Segmento(Id, Descripcion) Values (3,'Adultos');
INSERT INTO Segmento(Id, Descripcion) Values (4,'Adultos mayores');
SET IDENTITY_INSERT Segmento OFF

/********************************************************/
/*ESTADO*/
SET IDENTITY_INSERT Estado ON
INSERT INTO Estado(Id, Descripcion) Values (1,'Aprobado');
INSERT INTO Estado(Id, Descripcion) Values (2,'Pendiente de aprobación');
INSERT INTO Estado(Id, Descripcion) Values (3,'Cancelado');
INSERT INTO Estado(Id, Descripcion) Values (4,'Rechazado');
INSERT INTO Estado(Id, Descripcion) Values (5,'Finalizado');
INSERT INTO Estado(Id, Descripcion) Values (6,'Creada');
INSERT INTO Estado(Id, Descripcion) Values (7,'Publicada');
INSERT INTO Estado(Id, Descripcion) Values (8,'Rehacer formulario');
INSERT INTO Estado(Id, Descripcion) Values (9,'Rehizó el formulario, a la espera de la aprobación');
INSERT INTO Estado(Id, Descripcion) Values (10,'Actividad eliminada');




SET IDENTITY_INSERT Estado OFF


/********************************************************/


/*TIPODATOCAMPO*/
SET IDENTITY_INSERT TipoDatoCampo ON
INSERT INTO TipoDatoCampo(Id, Descripcion) VALUES (1,'Texto Corto (menos de 50 caracteres)');
INSERT INTO TipoDatoCampo(Id, Descripcion) VALUES (2,'Texto Largo (más de 51 caracteres)');
INSERT INTO TipoDatoCampo(Id, Descripcion) VALUES (3,'Número');
INSERT INTO TipoDatoCampo(Id, Descripcion) VALUES (4,'Fecha');
INSERT INTO TipoDatoCampo(Id, Descripcion) VALUES (5,'Imagen');
SET IDENTITY_INSERT TipoDatoCampo Off

/*DIASEMANA*/
SET IDENTITY_INSERT DiaSemana ON
INSERT INTO DiaSemana(Id, Descripcion) Values (0,'Domingo');
INSERT INTO DiaSemana(Id, Descripcion) Values (1,'Lunes');
INSERT INTO DiaSemana(Id, Descripcion) Values (2,'Martes');
INSERT INTO DiaSemana(Id, Descripcion) Values (3,'Miércoles');
INSERT INTO DiaSemana(Id, Descripcion) Values (4,'Jueves');
INSERT INTO DiaSemana(Id, Descripcion) Values (5,'Viernes');
INSERT INTO DiaSemana(Id, Descripcion) Values (6,'Sábado');
SET IDENTITY_INSERT DiaSemana OFF