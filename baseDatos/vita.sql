use master
GO
Create Database Vita
GO
USE Vita
GO

create table Localidad(
id int primary key,
descripcion varchar(100)
);

create table Provincia(
id int primary key,
descripcion varchar(100)

);

create table PartidoDepartamento(
id int primary key,
descripcion varchar(100),
provinciaId int, 
CONSTRAINT provinciaId FOREIGN KEY(provinciaId)
REFERENCES Provincia (id)
);
create Table Usuario(
id int primary key,
nombre varchar(50),
apellido varchar(50),
fechaNacimiento Date, 
correoElectronico varchar(100),
localidadId int,
CONSTRAINT localidadId FOREIGN KEY(localidadId)
REFERENCES Localidad (id)
);

create Table Empresa(
id int primary key,
nombre varchar(50),
correoElectronico varchar(100),
localidadId int,
CONSTRAINT localidadIdEmpresa FOREIGN KEY(localidadId)
REFERENCES Localidad (id)
);

create Table Categoria(
id int primary key,
descripcion varchar(100)
);

create Table Habilidad(
id int primary key,
descripcion varchar(100)
);

create Table Colaborador(
id int primary key,
nombre varchar(50),
apellido varchar(50),
fechaNacimiento Date, 
correoElectronico varchar(100),
localidadId int,
CONSTRAINT localidadColaborador FOREIGN KEY(localidadId)
REFERENCES Localidad (id)
);

create Table HabilidadColaborador(
habilidadId int,
colaboradorId int,
CONSTRAINT HabilidadColaboradorid FOREIGN KEY(habilidadId)
REFERENCES Habilidad (id),
CONSTRAINT ColaboradorHabilidadid FOREIGN KEY(colaboradorId)
REFERENCES Colaborador (id),
primary key(habilidadId, colaboradorId)
);

create Table Evento(
id int primary key,
descripcion varchar(200),
empresaId int,
precio int,
fechaInicio date, 
fechaDesde date,
cantidadParticipantes int, 
localidadId int,
CONSTRAINT EventoEmpresaId FOREIGN KEY(empresaId)
REFERENCES Empresa (id),
CONSTRAINT EventoLocalidadId FOREIGN KEY(localidadId)
REFERENCES Localidad (id)
);
create Table Necesidad(
id int,
descripcion varchar(200),
eventoId int,
habilidadId int,
CONSTRAINT EventoNecesidadId FOREIGN KEY(eventoId)
REFERENCES Evento (id),
CONSTRAINT HabilidadNecesidadId FOREIGN KEY(habilidadId)
REFERENCES Habilidad (id),
primary key (id,eventoId,habilidadId)
);
CREATE Table SubCategoria(
id int primary key,
descripcion varchar(200),
categoriaId int,
CONSTRAINT SubcategoriaCategoriaId FOREIGN KEY(categoriaId)
REFERENCES Categoria (id));

create Table Actividad(
id int primary key,
descripcion varchar(200),
fechaCreacion date,
edadMinima int,
edadMaxima int,
fechaActividadComienzo date,
fechaActividadFin date,
cantidadDias int,
precio int,
cantidadParticipantes int,
categoriaId int,
subcategoriaId int,
localidadId int,
empresaId int,
CONSTRAINT CategoriaActividadId FOREIGN KEY(categoriaId)
REFERENCES Categoria (id),
CONSTRAINT LocalidadActividadId FOREIGN KEY(localidadId)
REFERENCES Localidad (id),
CONSTRAINT ActividadEmpresaId FOREIGN KEY(empresaId)
REFERENCES Empresa (id),
CONSTRAINT ActividadSubcategoriaId FOREIGN KEY(subcategoriaId)
REFERENCES SubCategoria (id)
);
create Table EventoActividad(
actividadId int,
eventoId int,
primary key(actividadId, eventoId),
CONSTRAINT ActividadEventoId FOREIGN KEY(actividadId)
REFERENCES Actividad (id),
CONSTRAINT EventoActividadId FOREIGN KEY(eventoId)
REFERENCES Evento (id));

create Table ActividadUsuarioAnotado(
actividadId int,
usuarioId int, 
fechaAsociado date,
primary key(actividadId,usuarioId),
CONSTRAINT ActividadUsuarioId FOREIGN KEY(actividadId)
REFERENCES Actividad (id),
CONSTRAINT UsuarioActividadId FOREIGN KEY(usuarioId)
REFERENCES Usuario (id));




