-- Inserciones en la tabla Coberturas
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura1');
INSERT INTO Coberturas (nombreCobertura) VALUES ('Cobertura2');

-- Inserciones en la tabla Usuarios
INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado) 
VALUES (12345678, 'Apellido1', 'Nombre1', '1990-01-01', 1, 123, 123456789, 'correo1@example.com', 'contraseña1', 1);

INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado) 
VALUES (87654321, 'Apellido2', 'Nombre2', '1995-02-15', 2, 456, 987654321, 'correo2@example.com', 'contraseña2', 1);

-- Inserciones en la tabla Sede
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede1', 1);
INSERT INTO Sede (nombreSede, estado) VALUES ('Sede2', 1);

-- Inserciones en la tabla Especialidades
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad1', 1);
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES ('Especialidad2', 1);

-- Inserciones en la tabla Profesionales
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Profesional1', 'Apellido1', 'contraseña1', 1);
INSERT INTO Profesionales (nombre, apellido, Contraseña, estado) VALUES ('Profesional2', 'Apellido2', 'contraseña2', 1);

-- Inserciones en la tabla Consultas
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta1');
INSERT INTO Consultas (nombreConsultas) VALUES ('Consulta2');

-- Inserciones en la tabla Turnos
INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado) 
VALUES (1, 1, '2023-01-15', 1, 1, 1);

INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado) 
VALUES (2, 2, '2023-02-20', 2, 2, 1);

-- Inserciones en la tabla HorarioLaboral
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Lunes', '08:00:00', '12:00:00');
INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES ('Martes', '14:00:00', '18:00:00');

-- Inserciones en la tabla MedicoPorEspecialidad
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario) VALUES (1, 1, 1, 1);
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario) VALUES (2, 2, 2, 2);
INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario) VALUES (2, 1, 1, 1);

