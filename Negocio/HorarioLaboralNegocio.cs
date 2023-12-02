using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class HorarioLaboralNegocio
    {
        public List<HorarioLaboral> ListarHorarios()
        {
            List<HorarioLaboral> Lista = new List<HorarioLaboral>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Selecciona todos los horarios laborales.
                datos.SetearQuery("SELECT idHorario, diaSemana, horaInicio, horaFin FROM HorarioLaboral");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    HorarioLaboral aux = new HorarioLaboral();

                    aux.IdHorario = (long)datos.lector["idHorario"];
                    aux.DiaSemana = (string)datos.lector["diaSemana"];
                    aux.HoraInicio = (TimeSpan)datos.lector["horaInicio"];
                    aux.HoraFin = (TimeSpan)datos.lector["horaFin"];

                    Lista.Add(aux);
                }

                return Lista;
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

        public long AgregarHorarioLaboral(HorarioLaboral nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("INSERT INTO HorarioLaboral (diaSemana, horaInicio, horaFin) VALUES (@diaSemana, @horaInicio, @horaFin); SELECT SCOPE_IDENTITY();");

                    Datos.setearParametros("@diaSemana", nuevo.DiaSemana);
                    Datos.setearParametros("@horaInicio", nuevo.HoraInicio);
                    Datos.setearParametros("@horaFin", nuevo.HoraFin);

                    // Ejecutar la acción y obtener el nuevo ID
                    long id = Convert.ToInt64(Datos.ejecutarScalar());

                    // Asignar el ID generado al objeto HorarioLaboral
                    nuevo.IdHorario = id;

                    return id;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
