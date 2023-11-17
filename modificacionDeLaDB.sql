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
 
create TABLE MedicoPorEspecialidad (
legajo bigint not null,
idEspecialidad bigint not null,
idSede bigint not null  ,
idHorario bigint not null unique,
foreign key (idSede) references Sede(idSede),
foreign key (legajo) references Profesionales(legajo),
foreign key (idEspecialidad) references Especialidades(idEspecialidad),
foreign key (idHorario) references HorarioLaboral (idHorario),
primary key (legajo, idEspecialidad )
);


select p.legajo, p.apellido, p.nombre, e.idEspecialidad, e.nombreEspecialidad, s.idSede, s.nombreSede, H.idHorario ,H.diaSemana, H.horaInicio, H.horaFin, p.Contraseña, p.estado 
from Profesionales p  
inner join Especialidades e on e.idEspecialidad = p.idEspecialidad 
inner join Sede s on s.idSede = p.idSede 
inner join HorarioLaboral H on p.idHorario = H.idHorario
where p.estado=1 

select M.legajo, p.apellido, p.nombre, p.Contraseña, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado
from MedicoPorEspecialidad AS M
inner join Profesionales AS P ON M.legajo = P.legajo
inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad
inner join Sede as S ON S.idSede = M.idSede
inner join HorarioLaboral as H ON M.idHorario = H.idHorario
WHERE P.estado = 1
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura A');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura B');
-- Puedes agregar más coberturas según sea necesario
INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado)
VALUES (123456789, 'Apellido', 'Nombre', '2000-01-01', 1, 1001, 123456789, 'correo@example.com', 'contraseña', 1);
-- Ajusta los valores según sea necesario, especialmente para la llave foránea idCobertura
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede 1', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede 2', 1);
-- Agrega las sedes que necesites
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad 1', 1);
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad 2', 1);
-- Agrega más especialidades si es necesario
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Profesional', 'ApellidoProfesional', 'password', 1);
-- Inserta los profesionales que correspondan
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta A');
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta B');
-- Añade más tipos de consulta según sea necesario
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Lunes', '08:00:00', '16:00:00');
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Martes', '09:00:00', '17:00:00');
-- Ingresa más horarios laborales según sea necesario
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario)
VALUES (1, 1, 1, 1);
-- Asegúrate de que los valores de legajo, idEspecialidad, idSede e idHorario existan en sus respectivas tablas




INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura C');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura D');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura E');
INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado)
VALUES (987654321, 'Apellido2', 'Nombre2', '1995-05-15', 2, 1002, 987654321, 'correo2@example.com', 'contraseña2', 1);

INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado)
VALUES (111111111, 'Apellido3', 'Nombre3', '1980-10-20', 1, 1003, 111111111, 'correo3@example.com', 'contraseña3', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede 3', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede 4', 1);
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad 3', 1);
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad 4', 1);
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Profesional2', 'ApellidoProfesional2', 'password2', 1);
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Profesional3', 'ApellidoProfesional3', 'password3', 1);
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta C');
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta D');
INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado)
VALUES (2, 2, '2023-11-22', 2, 2, 1);

INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado)
VALUES (3, 3, '2023-11-25', 1, 1, 1);
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Miércoles', '10:00:00', '18:00:00');
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Jueves', '08:30:00', '16:30:00');

INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario)
VALUES (1, 4, 2, 1);

INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario)
VALUES (3, 4, 1, 1);

select * from HorarioLaboral