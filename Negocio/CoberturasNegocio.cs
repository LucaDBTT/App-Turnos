using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CoberturasNegocio
    {

        public List<Coberturas> ListarCoberturas(string id = "")
        {
            List<Coberturas> Lista = new List<Coberturas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("SELECT c.idCoberturas, c.nombreCobertura FROM Coberturas c");

                if (!string.IsNullOrEmpty(id))
                {
                    datos.Comando.CommandText += " AND c.nombreCobertura = @Id";
                    datos.setearParametros("@Id", Convert.ToInt32(id));
                }

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Coberturas aux = new Coberturas();

                    aux.idCobertura = (long)datos.lector["idCoberturas"];
                    aux.Nombre = (string)datos.lector["nombreCobertura"];
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
