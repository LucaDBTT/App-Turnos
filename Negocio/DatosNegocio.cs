using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DatosNegocio
    {
        public DataTable ObtenerDatosPacienteYTurnos(long dni)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                // Configurar el stored procedure y parámetros
                datos.SetearQuery(" SELECT P.nombre AS NombrePaciente, P.apellido AS ApellidoPaciente,  E.nombreEspecialidad AS Especialidad, S.idSlot, S.fecha, S.horaInicio, S.horaFin FROM Pacientes P INNER JOIN SlotsTurnos S ON P.dni = S.DniPaciente INNER JOIN MedicoPorEspecialidad AS ME ON S.idMedicoPorEspecialidad = ME.id_MedicoPorEspecialidad INNER JOIN Especialidades E ON E.idEspecialidad = ME.idEspecialidad WHERE P.dni = @DniPaciente;");
                datos.setearParametros("@DniPaciente", dni);

                // Ejecutar la lectura
                datos.EjecutarLectura();

                // Crear DataTable para almacenar los resultados
                DataTable dataTable = new DataTable();
                dataTable.Load(datos.lector);

                return dataTable;
            }
        }

        public DataTable ObtenerDatosHistoricos(long dni)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                // Configurar el stored procedure y parámetros
                datos.SetearQuery("SELECT H.fechaTurno as Fecha, H.DniPaciente as 'Dni del paciente', H.nombreMedico as 'Nombre del medico', H.apellidoMedico as 'Apellido del medico', H.estadoTurno as 'Estado del turno', H.nombreSede as Sede FROM HistorialTurnos H WHERE H.DniPaciente = @DniPaciente");
                datos.setearParametros("@DniPaciente", dni);

                // Ejecutar la lectura
                datos.EjecutarLectura();

                // Crear DataTable para almacenar los resultados
                DataTable dataTable = new DataTable();
                dataTable.Load(datos.lector);
                return dataTable;
            }
        }


        public DataTable ObtenerAgendaMedicos(long dni)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                // Configurar el stored procedure y parámetros
                datos.SetearQuery(" SELECT P.nombre AS NombrePaciente, P.apellido AS ApellidoPaciente, e.nombreEspecialidad AS Especialidad, S.fecha, S.horaInicio, S.horaFin FROM Pacientes P INNER JOIN SlotsTurnos S ON P.dni = S.DniPaciente INNER JOIN Especialidades e ON e.idEspecialidad = S.idMedicoPorEspecialidad INNER JOIN Profesionales pr ON pr.legajo = S.idMedicoPorEspecialidad WHERE pr.dni = @dni ORDER BY S.fecha DESC, S.horaInicio DESC;");
                datos.setearParametros("@dni", dni);

                // Ejecutar la lectura
                datos.EjecutarLectura();

                // Crear DataTable para almacenar los resultados
                DataTable dataTable = new DataTable();
                dataTable.Load(datos.lector);

                return dataTable;
            }

        }
    }
}
