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
INSERT INTO Categoria(Id, Descripcion) VALUES (4, 'Talleres /Capacitaciones /Cursos');
INSERT INTO Categoria(Id, Descripcion) VALUES (5, 'Actividades de interés cultural');
INSERT INTO Categoria(Id, Descripcion) VALUES (6, 'Excursiones');
SET IDENTITY_INSERT Categoria OFF

/*SubCategoria*/
SET IDENTITY_INSERT SubCategoria ON
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (1,'Caminata',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (2,'Gimnasia de mantenimiento',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (3,'Zumba al aire libre',1);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (4,'Excursión',1);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (5,'Dominó',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (6,'Ajedrez',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (7,'Damas',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (8,'Chinchón',2);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (9,'Truco',2);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (10,'AquaGym',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (11,'Yoga',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (12,'Gimnasia',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (13,'Baile, tango, zumba',3);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (14,'Pilates',3);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (15,'Manualidades, dibujo, pintura',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (17,'Idiomas',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (18,'Música, folclore, coros',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (19,'Reciclado',4);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (20,'Jardinería',4);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (21,'Museo',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (22,'Teatro',5);
INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (23,'Cine',5);
INSERT INTO SubCategoria(id, Descripcion, CategoriaId) Values (24,'Leer cuentos/ escribir/ cantar',5);

INSERT INTO SubCategoria(Id, Descripcion, CategoriaId) Values (25,'Excursión',6);
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
INSERT INTO Estado(Id, Descripcion) Values (2,'Pendiente');
INSERT INTO Estado(Id, Descripcion) Values (3,'Cancelado');
INSERT INTO Estado(Id, Descripcion) Values (4,'Rechazado');
INSERT INTO Estado(Id, Descripcion) Values (5,'Finalizado');
SET IDENTITY_INSERT Estado OFF


/********************************************************/
/*TIPOPREGUNTA*/
SET IDENTITY_INSERT TipoPregunta ON
INSERT INTO TipoPregunta(Id, Titulo, Descripcion) VALUES (1,'Consigna con texto a ingresar', 'Es para que la persona ingrese la respuesta escrita.');
INSERT INTO TipoPregunta(Id, Titulo, Descripcion) VALUES (2,'Consigna con elección de una sola opción', 'Usted creará varias opciones (mínimo 3 y máximo 10) y la persona que reciba el formulario, deberá elegir sola una.');
INSERT INTO TipoPregunta(Id, Titulo, Descripcion) VALUES (3,'Consigna con elección de una a varias opciones', 'Usted creará varias opciones (mínimo 3 y máximo 10) y la persona que reciba el formulario deberá elegir una o más opciones.');
INSERT INTO TipoPregunta(Id, Titulo, Descripcion) VALUES (4,'Consigna para la elección obligatoria entre dos opciones', 'Usted creará dos opciones de las cuales la persona que lo complete, deberá seleccionar si o si una de ellas, ejemplo "si o no".');
INSERT INTO TipoPregunta(Id, Titulo, Descripcion) VALUES (5,'Consigna para ingresar archivo', 'La persona deberá subir el archivo que usted requiera, ejemplo fotocopia del DNI.');
SET IDENTITY_INSERT TipoPregunta OFF


/*TIPOPREGUNTA*/
SET IDENTITY_INSERT TipoDatoIngresado ON
INSERT INTO TipoDatoIngresado(Id, Descripcion) VALUES (1,'Texto');
INSERT INTO TipoDatoIngresado(Id, Descripcion) VALUES (2,'Número');
INSERT INTO TipoDatoIngresado(Id, Descripcion) VALUES (3,'Fecha');
SET IDENTITY_INSERT TipoDatoIngresado ON

/*DIASEMANA*/
SET IDENTITY_INSERT DiaSemana ON
INSERT INTO DiaSemana(Id, Descripcion) Values (1,'Lunes');
INSERT INTO DiaSemana(Id, Descripcion) Values (2,'Martes');
INSERT INTO DiaSemana(Id, Descripcion) Values (3,'Miércoles');
INSERT INTO DiaSemana(Id, Descripcion) Values (4,'Jueves');
INSERT INTO DiaSemana(Id, Descripcion) Values (5,'Viernes');
INSERT INTO DiaSemana(Id, Descripcion) Values (6,'Sábado');
INSERT INTO DiaSemana(Id, Descripcion) Values (7,'Domingo');
SET IDENTITY_INSERT DiaSemana OFF
