
CREATE PROCEDURE sp_ObtenerDatosPacienteYTurnos
    @DniPaciente BIGINT
AS
BEGIN
    SELECT
        P.nombre AS NombrePaciente,
        P.apellido AS ApellidoPaciente,
		e.nombreEspecialidad,
        S.fecha,
        S.horaInicio,
        S.horaFin
    FROM
        Pacientes P
        INNER JOIN SlotsTurnos S ON P.dni = S.DniPaciente
		inner join Especialidades e on e.idEspecialidad = S.idMedicoPorEspecialidad
    WHERE
        P.dni = @DniPaciente;
END

EXEC sp_ObtenerDatosPacienteYTurnos @DniPaciente = '123456789';


