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

                datos.SetearQuery("select M.id_MedicoPorEspecialidad, M.legajo, p.apellido, p.nombre, p.Contraseña, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado from MedicoPorEspecialidad AS M inner join Profesionales AS P ON M.legajo = P.legajo inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad inner join Sede as S ON S.idSede = M.idSede inner join HorarioLaboral as H ON M.idHorario = H.idHorario WHERE M.estado = 1 AND P.estado = 1");
                if (legajo != "")
                    datos.Comando.CommandText += "and M.legajo=" + legajo;
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    MedicoPorEspecialidad aux = new MedicoPorEspecialidad();
                    aux.idMedicoPorEspecialidad = (long)datos.lector["id_MedicoPorEspecialidad"];
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

        public void AgregarMedico(MedicoPorEspecialidad nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {

                    Datos.SetearQuery("INSERT INTO MedicoPorEspecialidad (legajo, idEspecialidad, idSede, idHorario, estado) VALUES (@Legajo, @IdEspecialidad, @IdSede, @IdHorario, @Estado)");

                    Datos.setearParametros("@Legajo", nuevo.Legajo);
                    Datos.setearParametros("@IdEspecialidad", nuevo.IdEspecialidad);
                    Datos.setearParametros("@IdSede", nuevo.IdSede);
                    Datos.setearParametros("@IdHorario", nuevo.IdHorario);
                    Datos.setearParametros("@Estado", 1);
                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void bajaLogica(long id_MedicoPorEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("update MedicoPorEspecialidad set estado= 0 where id_MedicoPorEspecialidad = @id_MedicoPorEspecialidad");
                datos.setearParametros("@id_MedicoPorEspecialidad", id_MedicoPorEspecialidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }



    }
}

