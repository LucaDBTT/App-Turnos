CREATE DATABASE DB_ProyectoFinal;
GO

USE DB_ProyectoFinal;
GO

CREATE TABLE Coberturas (
    idCobertura bigint not null identity(1,1) primary key,
    nombreCobertura varchar(50) not null
);

CREATE TABLE Usuarios (
    idUsuario bigint not null identity(1,1) primary key, 
    dni bigint not null unique,
    apellido varchar(50) not null,
    nombre varchar(50) not null,
    fechaNac date not null,
    idCobertura bigint not null,
    nroAfiliado bigint not null,
    telefono bigint not null,
    mail varchar(50) not null unique,
    contraseña varchar(50) not null,
    estado bit not null,
    foreign key (idCobertura) references Coberturas(idCobertura)
);

CREATE TABLE Sede ( 
    idSede bigint not null  identity(1,1) primary key,
    nombreSede varchar(50) not null,
    estado bit not null
);

CREATE TABLE Especialidades(
    idEspecialidad bigint not null identity(1,1) primary key,
    nombreEspecialidad varchar(50) not null,
    estado bit not null,
);

CREATE TABLE Profesionales ( 
    legajo bigint not null primary key identity(1,1),
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    Contraseña varchar(30) not null,
    estado bit not null,
);

CREATE TABLE Consultas(
    idConsultas  bigint not null identity(1,1) primary key,
    nombreConsultas varchar(50) not null
);

CREATE TABLE Turnos (
    idTurno bigint not null identity(1,1) primary key,
    idUsuario bigint not null, 
    idProfesional bigint not null,
    fechaTurno date not null,
    idSede bigint not null,
    idConsulta bigint not null,
    Estado bit not null,
    foreign key (idUsuario) references Usuarios(idUsuario),
    foreign key (idProfesional) references Profesionales(legajo),
    foreign key (idSede) references Sede(idSede),
    foreign key (idConsulta) references Consultas(idConsultas)
);

CREATE TABLE HorarioLaboral (
    idHorario bigint not null identity(1,1) primary key,
    diaSemana varchar(15) not null,
    horaInicio time not null,
    horaFin time not null,
    CONSTRAINT UQ_HorarioLaboral UNIQUE (diaSemana, horaInicio, horaFin)
);
 
CREATE TABLE MedicoPorEspecialidad(
	id_MedicoPorEspecialidad bigint not null identity(1,1),
	legajo bigint not null,
	idEspecialidad bigint not null,
	idSede bigint not null,
	idHorario bigint not null,
	estado BIT NOT NULL,
	foreign key (idSede) references Sede(idSede),
	foreign key (legajo) references Profesionales(legajo),
	foreign key (idEspecialidad) references Especialidades(idEspecialidad),
	foreign key (idHorario) references HorarioLaboral (idHorario),
	primary key (id_MedicoPorEspecialidad, legajo, idEspecialidad )
);



/* INSERTS */

INSERT INTO Coberturas (nombreCobertura) VALUES 
('Cobertura A'),
('Cobertura B'),
('Cobertura C');

INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado) VALUES
(12345678, 'Apellido1', 'Nombre1', '1990-01-01', 1, 1001, 111111111, 'usuario1@mail.com', 'contraseña1', 1),
(23456789, 'Apellido2', 'Nombre2', '1985-02-15', 2, 1002, 222222222, 'usuario2@mail.com', 'contraseña2', 1),
(34567890, 'Apellido3', 'Nombre3', '1988-05-20', 3, 1003, 333333333, 'usuario3@mail.com', 'contraseña3', 1);

INSERT INTO Sede (nombreSede, estado) VALUES 
('Sede A', 1),
('Sede B', 1),
('Sede C', 1);

INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES 
('Especialidad A', 1),
('Especialidad B', 1),
('Especialidad C', 1);

INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES 
('Profesional1', 'ApellidoProf1', 'contraseñaProf1', 1),
('Profesional2', 'ApellidoProf2', 'contraseñaProf2', 1),
('Profesional3', 'ApellidoProf3', 'contraseñaProf3', 1);

INSERT INTO Consultas (nombreConsultas) VALUES 
('Consulta A'),
('Consulta B'),
('Consulta C');

INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado) VALUES
(1, 1, '2023-01-15', 1, 1, 1),
(2, 2, '2023-02-20', 2, 2, 1),
(3, 3, '2023-03-25', 3, 3, 1);

INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES 
('Lunes', '08:00:00', '16:00:00'),
('Martes', '09:00:00', '17:00:00'),
('Miércoles', '10:00:00', '18:00:00');

INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES
(1, 1, 1, 1, 1),
(1, 2, 2, 2, 1),
(2, 2, 1, 3, 1),
(2, 3, 2, 1, 1),
(3, 1, 3, 2, 1),
(3, 3, 1, 3, 1);


SELECT * FROM MedicoPorEspecialidad


SELECT P.nombre, P.apellido, P.legajo, P.Contraseña, P.estado
FROM Profesionales AS P