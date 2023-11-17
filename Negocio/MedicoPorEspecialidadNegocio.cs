using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
     public class MedicoPorEspecialidadNegocio
    {
        public List<MedicoPorEspecialidad> ListarMedicosPorEspecialidad()
        {
            List<MedicoPorEspecialidad> Lista = new List<MedicoPorEspecialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("select M.legajo, p.apellido, p.nombre, p.Contraseña, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado\r\nfrom MedicoPorEspecialidad AS M inner join Profesionales AS P ON M.legajo = P.legajo inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad inner join Sede as S ON S.idSede = M.idSede inner join HorarioLaboral as H ON M.idHorario = H.idHorario WHERE P.estado = 1");
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    MedicoPorEspecialidad aux = new MedicoPorEspecialidad();
                    aux.medico = new Medico();
                    aux.medico.Legajo = (long)datos.lector["legajo"];
                    aux.medico.Nombre = (string)datos.lector["nombre"];
                    aux.medico.Apellido = (string)datos.lector["apellido"];
                    aux.medico.Contraseña = (string)datos.lector["Contraseña"];
                    aux.medico.Estado = (bool)datos.lector["estado"];

                    // Crear la instancia de Especialidad y asignar valores
                    aux.Especialidades = new Especialidad
                    {
                        id = (long)datos.lector["idEspecialidad"],
                        Nombre = (string)datos.lector["nombreEspecialidad"]
                    };

                    // Crear la instancia de Sede y asignar valores
                    aux.Sede = new Sede
                    {
                        IdSede = (long)datos.lector["idSede"],
                        NombreSede = (string)datos.lector["nombreSede"]
                    };

                    // Crear la instancia de HorarioLaboral y asignar valores
                    aux.HorariosLaborales = new HorarioLaboral
                    {
                        IdHorario = (long)datos.lector["idHorario"],
                        DiaSemana = (string)datos.lector["diaSemana"],
                        HoraInicio = (TimeSpan)datos.lector["horaInicio"],
                        HoraFin = (TimeSpan)datos.lector["horaFin"]
                    };

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }




    }
}
