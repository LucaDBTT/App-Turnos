using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class SedeNegocio
    {
        public List<Sede> ListarSedes()
        {
            List<Sede> Lista = new List<Sede>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("SP_Sedes");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Sede aux = new Sede();

                    aux.ídSede = (long)datos.lector["IdSede"];
                    aux.NombreSede = (string)datos.lector["NombreSede"];
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
