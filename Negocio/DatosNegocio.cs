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
                datos.SetearQuery(" SELECT P.nombre AS NombrePaciente,P.apellido AS ApellidoPaciente,e.nombreEspecialidad AS Especialidad, S.fecha, S.horaInicio, S.horaFin FROM Pacientes P INNER JOIN SlotsTurnos S ON P.dni = S.DniPaciente inner join Especialidades e on e.idEspecialidad = S.idMedicoPorEspecialidad WHERE P.dni = @DniPaciente;");
                datos.setearParametros("@DniPaciente", dni);

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
