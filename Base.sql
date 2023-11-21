CREATE DATABASE DB_ProyectoFinal;
GO

USE DB_ProyectoFinal;
GO

CREATE TABLE Coberturas (
    idCobertura bigint not null identity(1,1) primary key,
    nombreCobertura varchar(50) not null
);

create TABLE Pacientes (
    idPaciente bigint not null identity(1,1) primary key, 
    dni bigint not null unique,
    apellido varchar(50) not null,
    nombre varchar(50) not null,
    fechaNac date not null,
    idCobertura bigint not null,
    nroAfiliado bigint not null,
    telefono bigint not null,
    estado bit not null,
    foreign key (idCobertura) references Coberturas(idCobertura)
);
--tipoUsuario 1=admin 2=medico 3=paciente o capaz solo uno y 2
create table Usuarios(
 idUsuario bigint not null  primary key identity(1,1),
 Usuario varchar(50) not null ,
 pass varchar (20) not null, 
 tipoUsuario int not null,
)

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




-- INSERTS
-- Inserting data into Coberturas table
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura1');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura2');

-- Inserting data into Pacientes table
INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado)
VALUES (123456789, 'Perez', 'Juan', '1990-01-01', 1, 987654, 123456789, 1);

-- Inserting data into Usuarios table
INSERT INTO Usuarios (Usuario, pass, tipoUsuario) VALUES ('admin', 'adminpass', 1);
INSERT INTO Usuarios (Usuario, pass, tipoUsuario) VALUES ('medico1', 'medicopass', 2);

-- Inserting data into Sede table
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede1', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede2', 1);

-- Inserting data into Especialidades table
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Cardiología', 1);
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Dermatología', 1);

-- Inserting data into Profesionales table
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Dr. Carlos', 'Gonzalez', 'pass123', 1);

-- Inserting data into Consultas table
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta General');
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta Especializada');

-- Inserting data into Turnos table
INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado)
VALUES (1, 1, '2023-01-15', 1, 1, 1);

-- Inserting data into HorarioLaboral table
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Lunes', '08:00', '16:00');
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Martes', '09:00', '17:00');

-- Inserting data into MedicoPorEspecialidad table
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado)
VALUES (1, 1, 1, 1, 1);
