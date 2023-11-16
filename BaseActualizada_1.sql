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
legajo bigint not null,
idEspecialidad bigint not null,
idSede bigint not null,
idHorario bigint not null,
foreign key (idSede) references Sede(idSede),
foreign key (legajo) references Profesionales(legajo),
foreign key (idEspecialidad) references Especialidades(idEspecialidad),
foreign key (idHorario) references HorarioLaboral (idHorario),
primary key (legajo, idEspecialidad)
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