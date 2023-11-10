CREATE DATABASE DB_ProyectoFinal
GO
USE DB_ProyectoFinal
GO

CREATE TABLE Coberturas(
idCoberturas bigint not null  identity(1,1) primary key,
nombreCobertura varchar(50)
) 

GO

CREATE TABLE Usuarios(
idUsuario bigint not null  identity(1,1) primary key, 
dni bigint not null unique,
apellido varchar(50) not null,
nombre varchar(50) not null,
fechaNac  date not null ,
idCobertura bigint not null ,
nroAfiliado bigint not null,
telefono bigint not null,
mail varchar(50) not null unique ,
contrase�a varchar(50) not null,
estado bit not null,
foreign key (idCobertura) references Coberturas(IdCoberturas)
)

GO

CREATE TABLE Sede ( 
idSede bigint not null  identity(1,1) primary key,
nombreSede varchar(50) not null
)

GO

CREATE TABLE Especialidades(
idEspecialidad bigint not null   identity(1,1) primary key,
nombreEspecialidad varchar(50) not null
)

GO

CREATE TABLE  Profesionales ( 
legajo bigint not null primary key identity(1,1),
nombre varchar(50) not null ,
apellido varchar(50) not null,
idEspecialidad bigint not null,
idSede bigint not null, 
Contrase�a varchar(30) not null,
estado bit not null,
foreign key (idSede) references Sede(idSede),
foreign key (idEspecialidad) references especialidades(idEspecialidad)
)

GO
CREATE TABLE Consultas(
idConsultas  bigint not null  identity(1,1) primary key,
nombreConsultas varchar(50) not null
)
GO

CREATE TABLE Turnos( 
idturno bigint not null  identity(1,1) primary key ,
idUsuario bigint not null, 
Idprofesional bigint not null,
fechaTurno int not null,
idSede bigint not null,
idConsulta bigint not null,
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

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Juan', 'Perez', 1, 1, 'contrasena123', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Marta', 'Gomez', 2, 2, 'contrasena456', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Pedro', 'Sanchez', 3, 1, 'contrasena789', 1);

INSERT INTO Profesionales ( nombre,apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Ana', 'Martinez', 4, 1, 'contrasenaabc', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Luis', 'Rodriguez', 5, 2, 'contrasenaXYZ', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Laura', 'Lopez', 1, 3, 'contrasena789', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Carlos', 'Gonzalez', 2, 1, 'contrasena123', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Elena', 'Fernandez', 3, 2, 'contrasena456', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Miguel', 'Ramos', 4, 1, 'contrasena999', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Isabel', 'Jimenez', 5, 3, 'contrasena456', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Juan', 'Garcia', 1, 2, 'contrasena777', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Maria', 'Hernandez', 2, 3, 'contrasena888', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Pedro', 'Lopez', 3, 2, 'contrasena333', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Ana', 'Martinez', 4, 1, 'contrasena444', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Luis', 'Gomez', 5, 3, 'contrasena555', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES  ('Laura', 'Perez', 1, 1, 'contrasena111', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ( 'Carlos', 'Sanchez', 2, 2, 'contrasena222', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ('Elena', 'Rodriguez', 3, 3, 'contrasena777', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ('Miguel', 'Martinez', 4, 1, 'contrasena333', 1);

INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, Contrase�a, estado)
VALUES ('Isabel', 'Garcia', 5, 2, 'contrasena444', 1);