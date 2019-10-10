Use Vita 

SET IDENTITY_INSERT Sexo ON
INSERT INTO Sexo(Id, Descripcion) VALUES (1, 'Femenino');
INSERT INTO Sexo(Id, Descripcion) VALUES (2, 'Masculino');
INSERT INTO Sexo(Id, Descripcion) VALUES (3, 'No quiero definirlo');
SET IDENTITY_INSERT Sexo OFF

/*categoria*/
SET IDENTITY_INSERT Categoria ON
INSERT INTO Categoria(Id, Descripcion) VALUES (1, 'Actividades al aire libre');
INSERT INTO Categoria(Id, Descripcion) VALUES (2, 'Campeonatos/Torneos de juegos de mesa');
INSERT INTO Categoria(Id, Descripcion) VALUES (3, 'Deportes');
INSERT INTO Categoria(Id, Descripcion) VALUES (4, 'Talleres/Capacitaciones/Cursos');
INSERT INTO Categoria(Id, Descripcion) VALUES (5, 'Actividades de inter�s cultural');
SET IDENTITY_INSERT Categoria OFF

/*SubCategoria*/
SET IDENTITY_INSERT SubCategoria ON
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (1,'Caminata',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (2,'Gimnasia de mantenimiento (de bajo impacto)',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (3,'Zumba al aire libre',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (4,'Excursi�n',1);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (5,'Domin�',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (6,'Ajedrez',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (7,'Damas',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (8,'Chinch�n',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (9,'Truco',2);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (10,'AquaGym',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (11,'Yoga',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (12,'Gimnasia',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (13,'Baile, tango, zumba',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (14,'Pilates',3);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (15,'Taller de manualidades, dibujo, pintura',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (17,'Idiomas',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (18,'M�sica, folclore, coros',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (19,'Reciclado',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (20,'Jardiner�a',4);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (21,'Museo',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (22,'Teatro',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (23,'Cine',5);
INSERT INTO SubCategoria(id, Descripcion, CategoriaId) Values (24,'Leer cuentos/ escribir/ cantar',5);

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
INSERT INTO Segmento(Id, Descripcion) Values (1,'Ni�os');
INSERT INTO Segmento(Id, Descripcion) Values (2,'Jovenes');
INSERT INTO Segmento(Id, Descripcion) Values (3,'Adultos');
INSERT INTO Segmento(Id, Descripcion) Values (4,'Adultos mayores');
SET IDENTITY_INSERT Segmento OFF


/***********************************************/
/*TIPONECESIDAD*/
SET IDENTITY_INSERT TipoNecesidad ON
INSERT INTO TipoNecesidad(Id, Descripcion) Values (1,'Monetaria');
INSERT INTO TipoNecesidad(Id, Descripcion) Values (2,'Log�stica');
INSERT INTO TipoNecesidad(Id, Descripcion) Values (3,'Servicio');
SET IDENTITY_INSERT TipoNecesidad OFF

