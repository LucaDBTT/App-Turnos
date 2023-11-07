CREATE DATABASE DB_ProyectoFinal
GO
USE DB_ProyectoFinal
GO

CREATE TABLE Coberturas(
idCoberturas int identity(1,1) primary key,
nombreCobertura varchar(50)
) 

GO

CREATE TABLE Usuarios(
idUsuario int identity(1,1) primary key, 
dni bigint not null unique,
apellido varchar(50) not null,
nombre varchar(50) not null,
fechaNac  date not null ,
idCobertura int not null ,
nroAfiliado bigint not null,
telefono bigint not null,
mail varchar(50) not null unique ,
contraseña varchar(50) not null,
estado bit not null,
foreign key (idCobertura) references Coberturas(IdCoberturas)
)

GO

CREATE TABLE Sede ( 
idSede int identity(1,1) primary key,
nombreSede varchar(50) not null
)

GO

CREATE TABLE Especialidades(
idEspecialidad int identity primary key,
nombreEspecialidad varchar(50) not null
)

GO

CREATE TABLE  Profesionales ( 
legajo bigint not null primary key,
nombre varchar(50) not null ,
apellido varchar(50) not null,
idEspecialidad int not null,
idSede int not null, 
Contraseña varchar(30) not null,
estado bit not null,
foreign key (idSede) references Sede(idSede),
foreign key (idEspecialidad) references especialidades(idEspecialidad)
)

GO
CREATE TABLE Consultas(
idConsultas int identity primary key,
nombreConsultas varchar(50) not null
)
GO

CREATE TABLE Turnos( 
idturno int identity(1,1) primary key ,
idUsuario int not null, 
Idprofesional bigint not null,
fechaTurno int not null,
idSede int not null,
idConsulta int not null,
Estado bit not null,
foreign key(idUsuario) references usuarios(idUsuario),
foreign key(Idprofesional) references profesionales(legajo),
foreign key(idSede) references Sede(idSede),
foreign key(idConsulta) references Consultas(idConsultas)
)

GO

INSERT INTO Especialidades (nombreEspecialidad)
VALUES ('Cardiologia');

INSERT INTO Especialidades (nombreEspecialidad)
VALUES ('Dermatologia');

INSERT INTO Especialidades (nombreEspecialidad)
VALUES ('Ginecologia');

INSERT INTO Especialidades (nombreEspecialidad)
VALUES ('Ortopedia');

INSERT INTO Especialidades (nombreEspecialidad)
VALUES ('Urologia');

INSERT INTO Sede (nombreSede)
VALUES ('Hospital Central');

INSERT INTO Sede (nombreSede)
VALUES ('Clinica San Martin');

INSERT INTO Sede (nombreSede)
VALUES ('Centro Medico ABC');

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (1, 'Juan', 'Perez', 1, 1, 'contrasena123', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (2, 'Marta', 'Gomez', 2, 2, 'contrasena456', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (3, 'Pedro', 'Sanchez', 3, 1, 'contrasena789', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (4, 'Ana', 'Martinez', 4, 1, 'contrasenaabc', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (5, 'Luis', 'Rodriguez', 5, 2, 'contrasenaXYZ', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (6, 'Laura', 'Lopez', 1, 3, 'contrasena789', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (7, 'Carlos', 'Gonzalez', 2, 1, 'contrasena123', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (8, 'Elena', 'Fernandez', 3, 2, 'contrasena456', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (9, 'Miguel', 'Ramos', 4, 1, 'contrasena999', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (10, 'Isabel', 'Jimenez', 5, 3, 'contrasena456', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (11, 'Juan', 'Garcia', 1, 2, 'contrasena777', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (12, 'Maria', 'Hernandez', 2, 3, 'contrasena888', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (13, 'Pedro', 'Lopez', 3, 2, 'contrasena333', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (14, 'Ana', 'Martinez', 4, 1, 'contrasena444', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (15, 'Luis', 'Gomez', 5, 3, 'contrasena555', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (16, 'Laura', 'Perez', 1, 1, 'contrasena111', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (17, 'Carlos', 'Sanchez', 2, 2, 'contrasena222', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (18, 'Elena', 'Rodriguez', 3, 3, 'contrasena777', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (19, 'Miguel', 'Martinez', 4, 1, 'contrasena333', 1);

INSERT INTO Profesionales (legajo, nombre, apellido, idEspecialidad, idSede, Contraseña, estado)
VALUES (20, 'Isabel', 'Garcia', 5, 2, 'contrasena444', 1);