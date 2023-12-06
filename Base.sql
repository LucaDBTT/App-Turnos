drop database DB_ProyectoFinal

CREATE DATABASE DB_ProyectoFinal;
GO
USE DB_ProyectoFinal;
GO
CREATE TABLE TiposUsuario (
    idTipoUsuario int not null primary key,
    nombreTipoUsuario varchar(50) not null
);
CREATE TABLE Coberturas (
    idCobertura bigint not null identity(1,1) primary key,
    nombreCobertura varchar(50) not null,
	estado bit not null
);
CREATE TABLE Profesionales ( 
    legajo bigint not null primary key identity(1,1),
	dni bigint not null unique,
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    Contrase�a varchar(30) not null,
    estado bit not null,
	tipoUsuario int not null default 3,

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
	tipoUsuario int not null default 1,
    foreign key (idCobertura) references Coberturas(idCobertura)
);
CREATE TABLE Administrador (
    idAdministrador bigint not null primary key identity(1,1),
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    dni bigint not null unique,
    telefono bigint not null,
    estado bit not null,
	tipoUsuario int not null default 2,
);

select * from Usuarios
insert into Usuarios (idPaciente,idProfesional,idAdministrador,dni,mail,pass,tipoUsuario,estado) values (null,null,1,1111,'admin@','1111',2,1)


select M.id_MedicoPorEspecialidad, M.legajo, p.apellido, p.nombre, p.Contrase�a, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado 
from MedicoPorEspecialidad AS M 
inner join Profesionales AS P ON M.legajo = P.legajo
inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad
inner join Sede as S ON S.idSede = M.idSede 
inner join HorarioLaboral as H ON M.idHorario = H.idHorario 
WHERE M.estado = 1 AND P.estado = 1
group by E.nombreEspecialidad


create table Usuarios(
 idUsuario bigint not null  primary key identity(1,1),
 idPaciente bigint,
 idProfesional bigint ,
 idAdministrador bigint,
 dni bigint not null,
 mail varchar(50) not null unique ,
 pass varchar (20) not null, 
 tipoUsuario int not null,
 estado bit not null,
 foreign key (idPaciente) references Pacientes(idPaciente),
 foreign key (idProfesional) references Profesionales(legajo),
 foreign key (idAdministrador) references Administrador(idAdministrador)
)

SELECT COUNT(*) FROM Usuarios WHERE mail = @Correo AND estado = 1

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

create TABLE HorarioLaboral (
    idHorario bigint not null identity(1,1) primary key,
    Fecha date null ,
	diaSemana varchar(15) not null,
    horaInicio time not null,
    horaFin time not null,
    CONSTRAINT UQ_HorarioLaboral UNIQUE (Fecha, horaInicio, horaFin)
);






create TABLE MedicoPorEspecialidad(
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

create TABLE SlotsTurnos (
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

select * from Coberturas
-- Inserciones para la tabla Coberturas
INSERT INTO Coberturas (nombreCobertura,estado) VALUES
('Obra Social 1',1),
('Obra Social 2',1),
('Obra Social 3',1);

-- Inserciones para la tabla Profesionales
INSERT INTO Profesionales (dni, nombre, apellido, Contrase�a, estado) VALUES
(987654321, 'Juan', 'G�mez', 'contrase�a1', 1),
(9543534345, 'Mar�a', 'L�pez', 'contrase�a2', 1),
(9866677, 'Pedro', 'Rodr�guez', 'contrase�a3', 1);

-- Inserciones para la tabla Pacientes
INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado) VALUES
(123456789, 'Paciente1', 'Nombre1', '1990-01-01', 1, 12345, 111222333, 1),
(987654321, 'Paciente2', 'Nombre2', '1985-05-05', 2, 54321, 444555666, 1),
(111222333, 'Paciente3', 'Nombre3', '1998-12-15', 3, 67890, 777888999, 1);

-- Inserciones para la tabla Administrador
INSERT INTO Administrador (nombre, apellido, dni, telefono, estado) VALUES
('Admin', 'Apellido', 999888777, 123456789, 1);

-- Inserciones para la tabla Usuarios
INSERT INTO Usuarios (idPaciente, idProfesional, idAdministrador,dni, mail, pass, tipoUsuario, estado) VALUES
(NULL, null, 1, 987654321, 'admin@mail.com', 'password1', 2, 1),
(NULL, 1, NULL, 987654321, 'medico1@mail.com', 'password2', 2, 1),
(NULL, NULL, 1 ,6756757657,'admin@mail.com', 'password3', 3, 1);

-- Inserciones para la tabla Sede
INSERT INTO Sede (nombreSede, estado) VALUES
('Sede 1', 1),
('Sede 2', 1),
('Sede 3', 1);

-- Inserciones para la tabla Especialidades
INSERT INTO Especialidades (nombreEspecialidad, estado, URLimagen) VALUES
('Dermatologia', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/dermatologia.jpg'),
('Traumatologia', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/traumatologia.jpg'),
('Clinica Medica', 1, 'https://prestacionesmedicaspilar.com/img/especialidades/clinica_medica.jpg');

-- Inserciones para la tabla Consultas
INSERT INTO Consultas (nombreConsultas) VALUES
('Consulta 1'),
('Consulta 2'),
('Consulta 3');

-- Inserciones para la tabla HorarioLaboral
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES
('Lunes', '08:00:00', '17:00:00'),
('Martes', '09:00:00', '18:00:00'),
('Mi�rcoles', '10:00:00', '19:00:00');

-- Inserciones para la tabla MedicoPorEspecialidad
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES
(1, 1, 1, 1, 1),
(2, 2, 2, 2, 1),
(3, 3, 3, 3, 1);

-- Inserciones para la tabla SlotsTurnos
INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado) VALUES
(1, null, '2023-01-01', '15:00:00', '14:00:00', 0),
(2, null, '2023-03-02', '12:30:00', '13:30:00', 0),
(3, null, '2023-03-03', '12:00:00', '13:00:00', 0);

select * from Usuarios
delete  from Pacientes
INSERT INTO TiposUsuario (idTipoUsuario, nombreTipoUsuario) VALUES
(1, 'Paciente'),
(2, 'Administrador'),
(3, 'Profesional');
select * from Sede
update Usuarios set estado = 1
SELECT u.idUsuario,u.dni,u.mail,u.tipoUsuario,COALESCE(p.nombre, m.nombre, a.nombre) 
AS Nombre,COALESCE(p.apellido, m.apellido, a.apellido) AS Apellido, tp.nombreTipoUsuario 
FROM Usuarios u LEFT JOIN Pacientes p ON u.idPaciente = p.idPaciente LEFT JOIN Profesionales m 
ON u.idProfesional = m.legajo LEFT JOIN Administrador a ON u.idAdministrador = a.idAdministrador INNER JOIN TiposUsuario tp ON tp.idTipoUsuario = u.tipoUsuario where u.estado = 1




create procedure SP_LimpiarTurnos
as 
begin
update SlotsTurnos
set Estado=1
where GETDATE() > fecha and estado =0 ; 

update SlotsTurnos
set fecha = DATEADD(DAY,7,fecha)
where GETDATE() > fecha and estado =1 ; 
end

CREATE OR ALTER TRIGGER DividirHorarioEnTurnos
ON MedicoPorEspecialidad
AFTER INSERT
AS
BEGIN
    DECLARE @idMedicoPorEspecialidad bigint;
    DECLARE @fecha date;
    DECLARE @horaInicio time;
    DECLARE @horaFin time;
    DECLARE @IDHorario bigint;
    DECLARE @dia varchar(15);

    SELECT @IDHorario = i.idHorario, @dia = diaSemana, @idMedicoPorEspecialidad = i.id_MedicoPorEspecialidad
    FROM inserted AS i;

    DECLARE @hoy DATE = GETDATE();

    -- Calcular la fecha del pr�ximo d�a especificado a partir de la fecha actual
    DECLARE @dias int;
    SET @dias = CASE @dia
        WHEN 'Lunes' THEN (8 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'Martes' THEN (9 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'Mi�rcoles' THEN (10 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'Jueves' THEN (11 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'Viernes' THEN (12 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'S�bado' THEN (13 - DATEPART(WEEKDAY, @hoy)) % 7
        WHEN 'Domingo' THEN (14 - DATEPART(WEEKDAY, @hoy)) % 7
        ELSE 0
    END;

    SET @fecha = DATEADD(DAY, @dias, @hoy);

    SELECT @horaInicio = horaInicio, @horaFin = horaFin
    FROM HorarioLaboral
    WHERE idHorario = @IDHorario;

    DECLARE @intervaloMinutos int = 60;
    DECLARE @horaActual time = @horaInicio;
    DECLARE @fechaProximaSemana date;

    SET @fechaProximaSemana = DATEADD(DAY, 7, @fecha);

    WHILE @horaActual <= @horaFin
    BEGIN
        INSERT INTO SlotsTurnos (idMedicoPorEspecialidad, fecha, horaInicio, horaFin, Estado)
        VALUES (@idMedicoPorEspecialidad, @fechaProximaSemana, @horaActual, DATEADD(MINUTE, @intervaloMinutos, @horaActual), 0);
        
        SET @horaActual = DATEADD(MINUTE, @intervaloMinutos, @horaActual);
    END;
END;

