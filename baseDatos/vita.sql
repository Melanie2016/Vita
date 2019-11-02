use master
GO
Create Database Vita
GO
USE Vita
GO

create table Provincia(
Id int identity(1,1) primary key,
Descripcion varchar(100)
);
create table Departamento(
Id int identity(1,1) primary key,
Descripcion varchar(300),
ProvinciaId int,
CONSTRAINT ProvinciaDepartamentoId FOREIGN KEY(ProvinciaId)
REFERENCES Provincia (Id));

create table Localidad(
Id int identity(1,1) primary key,
Descripcion varchar(100),
DepartamentoId int,
CONSTRAINT LocalidadDepartamentoId FOREIGN KEY(DepartamentoId)
REFERENCES Departamento (Id)
);


create table Estado(
Id int identity(1,1) primary key,
Descripcion varchar(50)
);

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
Id int identity(1,1) primary key,
UsuarioId int, 
CategoriaId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT UsuarioCategoriaId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT CategoriaUsuarioId FOREIGN KEY(CategoriaId)
REFERENCES Categoria (Id));

create table UsuarioSegmento(
Id int identity(1,1) primary key,
UsuarioId int,
SegmentoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT UsuarioSegmentoId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT SegmentoUsuarioId FOREIGN KEY(SegmentoId)
REFERENCES Segmento (Id));

CREATE Table SubCategoria(
Id int identity(1,1) primary key,
Descripcion varchar(200),
CategoriaId int,
CONSTRAINT SubcategoriaCategoriaId FOREIGN KEY(CategoriaId)
REFERENCES Categoria (Id));

create Table Actividad(
Id int identity(1,1) primary key,
Titulo varchar(100) not null,
Descripcion varchar(1000) not null,
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
Compleja bit null,
CONSTRAINT CategoriaActividadId FOREIGN KEY(categoriaId)
REFERENCES Categoria (id),
CONSTRAINT LocalidadActividadId FOREIGN KEY(localidadId)
REFERENCES Localidad (id),
CONSTRAINT ActividadUsuarioId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (id),
CONSTRAINT ActividadSubcategoriaId FOREIGN KEY(subcategoriaId)
REFERENCES SubCategoria (id)
);

create Table Domicilio(
Id int identity(1,1) primary key,
NombreCalle varchar(100),
NumeroCalle int,
NumeroPiso int,
NumeroDepartamento int,
CodigoPostal varchar(14),
LocalidadId int,
UsuarioId int,
ActividadId int,
FechaRegistroEnDb Date,
CONSTRAINT DomicilioUsuarioId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT DomicilioLocalidadId FOREIGN KEY(LocalidadId)
REFERENCES Localidad (Id),
CONSTRAINT DomicilioActividadId FOREIGN KEY(ActividadId)
REFERENCES Actividad (Id));
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


create Table UsuarioInscriptoActividad(
Id int identity(1,1) primary key,
ActividadId int,
UsuarioId int, 
EstadoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT ActividadUsuarioInsId FOREIGN KEY(ActividadId)
REFERENCES Actividad (Id),
CONSTRAINT UsuarioActividadInsId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT UsuarioActividadEstadoInsId FOREIGN KEY(EstadoId)
REFERENCES Estado (Id));

create Table UsuarioEstadoHistorico(
Id int identity(1,1) primary key,
UsuarioId int,
EstadoId int,
CreatedAt Date null,
UpdatedAt Date null, 
DeletedAt Date null, 
CONSTRAINT UsuarioEstadoId FOREIGN KEY(UsuarioId)
REFERENCES Usuario (Id),
CONSTRAINT EstadoUsuarioId FOREIGN KEY(EstadoId)
REFERENCES Estado (Id));








