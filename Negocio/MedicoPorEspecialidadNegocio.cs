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
        public List<MedicoPorEspecialidad> ListarMedicosPorEspecialidad(string legajo = "")
        {
            List<MedicoPorEspecialidad> Lista = new List<MedicoPorEspecialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("select M.legajo, p.apellido, p.nombre, p.Contraseña, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado\r\nfrom MedicoPorEspecialidad AS M inner join Profesionales AS P ON M.legajo = P.legajo inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad inner join Sede as S ON S.idSede = M.idSede inner join HorarioLaboral as H ON M.idHorario = H.idHorario WHERE P.estado = 1");
                if (legajo != "")
                    datos.Comando.CommandText += "and M.legajo=" + legajo;
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    MedicoPorEspecialidad aux = new MedicoPorEspecialidad();

                    aux.Legajo = (long)datos.lector["legajo"];
                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.Apellido = (string)datos.lector["apellido"];
                    aux.Contraseña = (string)datos.lector["Contraseña"];
                    aux.Estado = (bool)datos.lector["estado"];

                    // Crear la instancia de Especialidad y asignar valores
                    aux.IdEspecialidad = (long)datos.lector["idEspecialidad"];
                    aux.NombreEspecialidad = (string)datos.lector["nombreEspecialidad"];

                    // Crear la instancia de Sede y asignar valores
                    aux.IdSede = (long)datos.lector["idSede"];
                    aux.NombreSede = (string)datos.lector["nombreSede"];

                    // Crear la instancia de HorarioLaboral y asignar valores
                    aux.IdHorario = (long)datos.lector["idHorario"];
                    aux.DiaSemana = (string)datos.lector["diaSemana"];
                    aux.HoraInicio = (TimeSpan)datos.lector["horaInicio"];
                    aux.HoraFin = (TimeSpan)datos.lector["horaFin"];

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

        public void Modificar(MedicoPorEspecialidad nuevo)
        {
          /*  AccesoDatos Datos = new AccesoDatos();

            try
            {
                 Datos.SetearQuery("update MedicoPorEspecialidad set idEspecialidad = @idEspecialidad where legajo = @legajo");

                 Datos.setearParametros("@nombre", nuevo.Nombre);
                 Datos.setearParametros("@apellido", nuevo.Apellido);
                 Datos.setearParametros("@idEspecialidad", nuevo.IdEspecialidad);
                Datos.setearParametros("@idSede", nuevo.IdSede);
                
                 Datos.setearParametros("@legajo", nuevo.Legajo);
                
                 Datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }  */
        }
    }
}

