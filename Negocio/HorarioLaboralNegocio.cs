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

    }
}
