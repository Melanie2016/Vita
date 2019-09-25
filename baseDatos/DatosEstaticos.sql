/*categoria*/
SET IDENTITY_INSERT Categoria ON
INSERT INTO Categoria(id, descripcion) VALUES (1, 'Actividades al aire libre');
INSERT INTO Categoria(id, descripcion) VALUES (2, 'Campeonatos/Torneos de juegos de mesa');
INSERT INTO Categoria(id, descripcion) VALUES (3, 'Deportes');
INSERT INTO Categoria(id, descripcion) VALUES (4, 'Talleres/Capacitaciones/Cursos');
INSERT INTO Categoria(id, descripcion) VALUES (5, 'Actividades de interés cultural');
SET IDENTITY_INSERT Categoria OFF
/*SubCategoria*/

SET IDENTITY_INSERT SubCategoria ON
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (1,'Caminata',1);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (2,'Gimnasia de mantenimiento (de bajo impacto)',1);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (3,'Zumba al aire libre',1);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (4,'Excursión',1);

INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (5,'Dominó',2);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (6,'Ajedrez',2);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (7,'Damas',2);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (8,'Chinchón',2);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (9,'Truco',2);

INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (10,'AquaGym',3);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (11,'Yoga',3);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (12,'Gimnasia',3);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (13,'Baile, tango, zumba',3);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (14,'Pilates',3);

INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (15,'Taller de manualidades, dibujo, pintura',4);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (17,'Idiomas',4);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (18,'Música, folclore, coros',4);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (19,'Reciclado',4);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (20,'Jardinería',4);

INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (21,'Museo',5);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (22,'Teatro',5);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (23,'Cine',5);
INSERT INTO SubCategoria(id, descripcion, CategoriaId) Values (24,'Leer cuentos/ escribir/ cantar',5);

SET IDENTITY_INSERT SubCategoria OFF
