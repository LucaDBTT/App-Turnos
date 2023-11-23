using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TurnosNegocio
    {
        public DataTable ObtenerSlotsTurnoPorMedico(int idMedico)
        {
            DataTable dataTable = new DataTable();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("SELECT idSlot, fecha, horaInicio, horafin, CONVERT(varchar, fecha, 103) + ' ' + CONVERT(varchar, horaInicio, 108) AS fechaHoraInicio FROM SlotsTurnos WHERE idMedicoPorEspecialidad = @idMedico and estado=0;");
                datos.Comando.Parameters.AddWithValue("@idMedico", idMedico);

                datos.Comando.Connection = datos.Conexion;
                datos.Conexion.Open();

                using (datos.Lector = datos.Comando.ExecuteReader())
                {
                    dataTable.Load(datos.Lector);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return dataTable;
        }

        public void OcuparTurno(long idSlot)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.SetearQuery("update SlotsTurnos set estado=1 where idSlot = @idSlot");
                datos.setearParametros("@idSlot", idSlot);
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

        public SlotsTurnos ObtenerSlotPorId(long idSlot)
        {
            AccesoDatos datos = new AccesoDatos();
            SlotsTurnos slot = null;

            try
            {
                datos.SetearQuery("SELECT idSlot, idMedicoPorEspecialidad, DniPaciente, fecha, horaInicio, horaFin, Estado " +
                                  "FROM SlotsTurnos " +
                                  "WHERE idSlot = @idSlot");

                // Corregir la conversión a Int64
                datos.setearParametros("@idSlot", idSlot);
                datos.EjecutarLectura();

                if (datos.lector.Read())
                {
                    slot = new SlotsTurnos
                    {
                        IdSlot = (long)datos.lector["idSlot"],
                        //DniPaciente = (long)datos.lector["DniPaciente"],
                        IdMedicoPorEspecialidad = (long)datos.lector["idMedicoPorEspecialidad"],
                        Fecha = (DateTime)datos.lector["fecha"],
                        HoraInicio = (TimeSpan)datos.lector["horaInicio"],
                        HoraFin = (TimeSpan)datos.lector["horaFin"],
                        Estado = (bool)datos.lector["Estado"]
                    };
                }

                return slot;
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



