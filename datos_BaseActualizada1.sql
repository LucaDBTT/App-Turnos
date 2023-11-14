-- Datos para la tabla Coberturas
INSERT INTO Coberturas (nombreCobertura) VALUES 
    ('Cobertura B�sica'),
    ('Cobertura Est�ndar'),
    ('Cobertura Premium');

-- Datos para la tabla Usuarios
INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contrase�a, estado) VALUES
    (123456789, 'Gonz�lez', 'Ana', '1990-05-15', 1, 987654, 555123456, 'ana@example.com', 'contrase�a123', 1),
    (987654321, 'L�pez', 'Juan', '1985-08-20', 2, 123456, 555789012, 'juan@example.com', 'clave456', 1),
    (111223344, 'Mart�nez', 'Mar�a', '1998-02-10', 3, 654321, 555456789, 'maria@example.com', 'pass789', 1);

-- Datos para la tabla Sede
INSERT INTO Sede (nombreSede, estado) VALUES
    ('Sede Central', 1),
    ('Sede Norte', 1),
    ('Sede Sur', 1);

-- Datos para la tabla Especialidades
INSERT INTO Especialidades (nombreEspecialidad, estado) VALUES
    ('Cardiolog�a', 1),
    ('Dermatolog�a', 1),
    ('Pediatr�a', 1);

-- Datos para la tabla Profesionales
INSERT INTO Profesionales (nombre, apellido, idEspecialidad, idSede, Contrase�a, estado) VALUES
    ('Carlos', 'Ram�rez', 1, 1, 'claveProf1', 1),
    ('Laura', 'G�mez', 2, 2, 'claveProf2', 1),
    ('Javier', 'Fern�ndez', 3, 3, 'claveProf3', 1);

-- Datos para la tabla Consultas
INSERT INTO Consultas (nombreConsultas) VALUES
    ('Consulta General'),
    ('Examen F�sico'),
    ('An�lisis de Sangre');

-- Datos para la tabla Turnos
INSERT INTO Turnos (idUsuario, idProfesional, fechaTurno, idSede, idConsulta, Estado) VALUES
    (1, 1, '2023-11-15', 1, 1, 1),
    (2, 2, '2023-11-16', 2, 2, 1),
    (3, 3, '2023-11-17', 3, 3, 1);

-- Datos para la tabla HorarioLaboral
INSERT INTO HorarioLaboral (idProfesional, diaSemana, horaInicio, horaFin) VALUES
    (1, 'Lunes', '08:00:00', '16:00:00'),
    (2, 'Martes', '09:00:00', '17:00:00'),
    (3, 'Mi�rcoles', '10:00:00', '18:00:00');