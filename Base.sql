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
	URLimagen varchar (80)
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

CREATE TABLE HorarioLaboral (
    idHorario bigint not null identity(1,1) primary key,
    diaSemana varchar(15) not null,
    horaInicio time not null,
    horaFin time not null,
    CONSTRAINT UQ_HorarioLaboral UNIQUE (diaSemana, horaInicio, horaFin)
);
 
CREATE TABLE MedicoPorEspecialidad(
    id_MedicoPorEspecialidad bigint not null identity(1,1) primary key,
    legajo bigint not null,
    idEspecialidad bigint not null,
    idSede bigint not null,
    idHorario bigint not null,
    estado BIT NOT NULL,
    foreign key (idSede) references Sede(idSede),
    foreign key (legajo) references Profesionales(legajo),
    foreign key (idEspecialidad) references Especialidades(idEspecialidad),
    foreign key (idHorario) references HorarioLaboral (idHorario)
);

CREATE TABLE SlotsTurnos (
    idSlot bigint not null identity(1,1) primary key,
    idMedicoPorEspecialidad bigint not null,
	DniPaciente bigint null,
    fecha date not null,
    horaInicio time not null,
    horaFin time not null,
    Estado bit not null,
    foreign key (idMedicoPorEspecialidad) references MedicoPorEspecialidad(id_MedicoPorEspecialidad),
	foreign key (DniPaciente) references Pacientes(dni)
);


SELECT * FROM Especialidades


INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura A');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura B');
-- Puedes continuar agregando más según sea necesario

-- Inserciones en Pacientes
INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado)
VALUES (123456789, 'Gómez', 'Juan', '1990-01-15', 1, 987654, 555123456, 1);

INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado)
VALUES (987654321, 'López', 'Ana', '1985-05-20', 2, 123456, 555789012, 1);

-- Inserciones en Usuarios
INSERT INTO Usuarios (Usuario, pass, tipoUsuario) VALUES ('admin', 'adminpass', 1);
INSERT INTO Usuarios (Usuario, pass, tipoUsuario) VALUES ('medico1', 'medicopass1', 2);
INSERT INTO Usuarios (Usuario, pass, tipoUsuario) VALUES ('paciente1', 'pacientepass1', 3);

-- Inserciones en Sede
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede Principal', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede Secundaria', 1);

-- Inserciones en Especialidades
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES ('Cardiología', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/Cardiologia.jpg');
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES ('Dermatología', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/dermatologia.jpg');
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES ('Traumatología', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/traumatologia.jpg');
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES ('Clínica Medica', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/clinica_medica.jpg');

-- Inserciones en Profesionales
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Médico', 'Uno', 'passmedico1', 1);
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Médico', 'Dos', 'passmedico2', 1);

-- Inserciones en Consultas
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta General');
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta Especializada');

-- Inserciones en HorarioLaboral
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Lunes', '08:00:00', '12:00:00');
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Martes', '10:00:00', '15:00:00');

-- Inserciones en MedicoPorEspecialidad
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES (1, 1, 1, 1, 1);
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES (2, 2, 2, 2, 1);

INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-11-27', '10:00:00', '11:00:00', 0);

INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '11:00:00', '12:00:00', 0);
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '12:00:00', '13:00:00', 0);
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '13:00:00', '14:00:00', 0);
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '14:00:00', '15:00:00', 0);
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '15:00:00', '16:00:00', 0);
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) 
VALUES (1, NULL, '2023-12-04', '16:00:00', '17:00:00', 0);
