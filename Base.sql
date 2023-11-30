drop database DB_ProyectoFinal
CREATE DATABASE DB_ProyectoFinal;
GO

USE DB_ProyectoFinal;
GO

CREATE TABLE Coberturas (
    idCobertura bigint not null identity(1,1) primary key,
    nombreCobertura varchar(50) not null
);
CREATE TABLE Profesionales ( 
    legajo bigint not null primary key identity(1,1),
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    Contraseña varchar(30) not null,
    estado bit not null,
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
CREATE TABLE Administrador (
    idAdministrador bigint not null primary key identity(1,1),
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    dni bigint not null unique,
    telefono bigint not null,
    estado bit not null
    -- Puedes agregar más columnas según tus necesidades
);
--tipoUsuario 1=admin 2=medico 3=paciente o capaz solo uno y 2
create table Usuarios(
 idUsuario bigint not null  primary key identity(1,1),
 idPaciente bigint,
 idProfesional bigint ,
 idAdministrador bigint,
 dni bigint not null,
 mail varchar(50) not null ,
 pass varchar (20) not null, 
 tipoUsuario int not null,
 foreign key (idPaciente) references Pacientes(idPaciente),
 foreign key (idProfesional) references Profesionales(legajo),
 foreign key (idAdministrador) references Administrador(idAdministrador)
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


-- Inserciones para la tabla Coberturas
INSERT INTO Coberturas (nombreCobertura) VALUES
('Obra Social 1'),
('Obra Social 2'),
('Obra Social 3');

-- Inserciones para la tabla Profesionales
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES
('Juan', 'Gómez', 'contraseña1', 1),
('María', 'López', 'contraseña2', 1),
('Pedro', 'Rodríguez', 'contraseña3', 1);

-- Inserciones para la tabla Pacientes
INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado) VALUES
(123456789, 'Paciente1', 'Nombre1', '1990-01-01', 1, 12345, 111222333, 1),
(987654321, 'Paciente2', 'Nombre2', '1985-05-05', 2, 54321, 444555666, 1),
(111222333, 'Paciente3', 'Nombre3', '1998-12-15', 3, 67890, 777888999, 1);

-- Inserciones para la tabla Administrador
INSERT INTO Administrador (nombre, apellido, dni, telefono, estado) VALUES
('Admin', 'Apellido', 999888777, 123456789, 1);

-- Inserciones para la tabla Usuarios
INSERT INTO Usuarios (idPaciente, idProfesional, idAdministrador,dni, mail, pass, tipoUsuario) VALUES
(1, NULL, NULL,123456789, 'paciente1@mail.com', 'password1', 1),
(NULL, 1, NULL,987654321, 'medico1@mail.com', 'password2', 2),
(NULL, NULL, 1,6756757657,'admin@mail.com', 'password3', 3);

-- Inserciones para la tabla Sede
INSERT INTO Sede (nombreSede, estado) VALUES
('Sede 1', 1),
('Sede 2', 1),
('Sede 3', 1);

-- Inserciones para la tabla Especialidades
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES
('Especialidad 1', 1, 'imagen1.jpg'),
('Especialidad 2', 1, 'imagen2.jpg'),
('Especialidad 3', 1, 'imagen3.jpg');

-- Inserciones para la tabla Consultas
INSERT INTO Consultas (nombreConsultas) VALUES
('Consulta 1'),
('Consulta 2'),
('Consulta 3');

-- Inserciones para la tabla HorarioLaboral
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES
('Lunes', '08:00:00', '17:00:00'),
('Martes', '09:00:00', '18:00:00'),
('Miércoles', '10:00:00', '19:00:00');

-- Inserciones para la tabla MedicoPorEspecialidad
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES
(1, 1, 1, 1, 1),
(2, 2, 2, 2, 1),
(3, 3, 3, 3, 1);

-- Inserciones para la tabla SlotsTurnos
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) VALUES
(1, 123456789, '2023-01-01', '15:00:00', '14:00:00', 0),
(2, 987654321, '2023-03-02', '12:30:00', '13:30:00', 0),
(3, null, '2023-03-03', '12:00:00', '13:00:00', 0);


select * from Pacientes
select * from SlotsTurnos 


select u.apellido, u.nombre, st.fecha, st.horaInicio, st.horaFin
from Pacientes u
inner join SlotsTurnos st on u.dni = st.DniPaciente
