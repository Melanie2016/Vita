use master
GO
Create Database Vita
GO
USE Vita
GO

create table Localidad(
Id int identity(1,1) primary key,
Descripcion varchar(100)
);

--create table Provincia(
--Id int primary key,
--Descripcion varchar(100)
--);

--create table PartidoDepartamento(
--Id int primary key,
--Descripcion varchar(300),
--ProvinciaId int, 
--CONSTRAINT provinciaId FOREIGN KEY(ProvinciaId)
--REFERENCES Provincia (id)
--);

create Table Categoria(
Id int identity(1,1) primary key,
Descripcion varchar(100)
);
create table Rol(
Id int identity(1,1) primary key,
Descripcion varchar(100)
);

create table Segmento(
Id int identity(1,1) primary key,
Descripcion varchar(100)
);
create Table Sexo(
Id int identity(1,1) primary key,
Descripcion varchar(50)
);

create Table Usuario(
Id int identity(1,1) primary key,
Nombre varchar(50) not null,
Apellido varchar(50) null,
FechaNacimiento Date null, 
SexoId int null,
Dni int null,
Email varchar(100) null,
LocalidadId int,
Celular int null,
Telefono int null,
UsuarioName varchar(100) not null,
Pass varchar(10) not null,
SitioWeb varchar(200) null,
SobreMi varchar (500) null,
RolId int,
Foto image,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT sexoUsuarioId FOREIGN KEY(SexoId)
REFERENCES Sexo(Id),
CONSTRAINT localidadUsuarioId FOREIGN KEY(LocalidadId)
REFERENCES Localidad (Id),
CONSTRAINT usuarioRolId FOREIGN KEY(RolId)
REFERENCES Rol (Id)
);

CREATE TABLE UsuarioCategoriaElegida(
UsuarioId int, 
CategoriaId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT UsuarioCategoriaId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT CategoriaUsuarioId FOREIGN KEY(CategoriaId)
REFERENCES Categoria (Id),
primary key(UsuarioId, CategoriaId));

--create table UsuarioPerfil(
--UsuarioId int,
--PerfilId int,
--FechaCreacion Date,
--CONSTRAINT UsuarioPerfilId FOREIGN KEY(UsuarioId)
--REFERENCES Usuario (Id),
--CONSTRAINT PerfilUsuarioId FOREIGN KEY(PerfilId)
--REFERENCES Perfil (Id),
--primary key(UsuarioId, PerfilId));
--);
create table UsuarioSegmento(
UsuarioId int,
SegmentoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT UsuarioSegmentoId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT SegmentoUsuarioId FOREIGN KEY(SegmentoId)
REFERENCES Segmento (Id),
primary key(UsuarioId, SegmentoId));

CREATE Table SubCategoria(
Id int identity(1,1) primary key,
Descripcion varchar(200),
CategoriaId int,
CONSTRAINT SubcategoriaCategoriaId FOREIGN KEY(CategoriaId)
REFERENCES Categoria (Id));

create Table Evento(
Id int identity(1,1) primary key,
Titulo varchar(100) not null,
Descripcion varchar(200),
UsuarioId int,
Precio int,
FechaDesde date, 
FechaHasta date,
CantidadDias int,
CantidadCupo int, 
LocalidadId int,
Foto image,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT EventoUsuarioId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT EventoLocalidadId FOREIGN KEY(LocalidadId)
REFERENCES Localidad (id)
);

create Table EventoSegmento(
EventoId int,
SegmentoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT EventoSegmentoId FOREIGN KEY(EventoId)
REFERENCES Evento (Id),
CONSTRAINT SegmentoEventoId FOREIGN KEY(SegmentoId)
REFERENCES Segmento (Id),
primary key(EventoId, SegmentoId));

create Table Actividad(
Id int identity(1,1) primary key,
Titulo varchar(100) not null,
Descripcion varchar(200) not null,
EdadMinima int not null,
EdadMaxima int,
Precio int null,
FechaDesde date not null, 
FechaHasta date not null,
CantidadDias int null,
CantidadCupo int not null,
CategoriaId int not null,
SubcategoriaId int not null,
LocalidadId int not null,
UsuarioId int,
Foto image,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT CategoriaActividadId FOREIGN KEY(categoriaId)
REFERENCES Categoria (id),
CONSTRAINT LocalidadActividadId FOREIGN KEY(localidadId)
REFERENCES Localidad (id),
CONSTRAINT ActividadUsuarioId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (id),
CONSTRAINT ActividadSubcategoriaId FOREIGN KEY(subcategoriaId)
REFERENCES SubCategoria (id)
);
create Table ActividadSegmento(
ActividadId int,
SegmentoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT ActividadSegmentoId FOREIGN KEY(ActividadId)
REFERENCES Actividad (Id),
CONSTRAINT SegmentoActividadId FOREIGN KEY(SegmentoId)
REFERENCES Segmento (Id),
primary key(ActividadId, SegmentoId));

CREATE TABLE TipoNecesidad(
Id int identity(1,1) primary key,
Descripcion varchar(100),
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null
);

create Table EventoActividad(
ActividadId int,
EventoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
primary key(ActividadId, EventoId),
CONSTRAINT ActividadEventoId FOREIGN KEY(ActividadId)
REFERENCES Actividad (Id),
CONSTRAINT EventoActividadId FOREIGN KEY(EventoId)
REFERENCES Evento (Id));

create Table UsuarioInscriptoActividad(
ActividadId int,
UsuarioId int, 
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
primary key(ActividadId,UsuarioId),
CONSTRAINT ActividadUsuarioInsId FOREIGN KEY(ActividadId)
REFERENCES Actividad (Id),
CONSTRAINT UsuarioActividadInsId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id));

create Table UsuarioInscriptoEvento(
EventoId int,
UsuarioId int, 
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
primary key(EventoId,UsuarioId),
CONSTRAINT EventoUsuarioInsId FOREIGN KEY(EventoId)
REFERENCES Evento (Id),
CONSTRAINT UsuarioEventoInsId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id));




