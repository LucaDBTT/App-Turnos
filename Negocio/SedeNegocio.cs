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
        public List<Sede> ListarSedes( string id = "")
        {
            List<Sede> Lista = new List<Sede>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("select s.idSede, s.nombreSede from Sede s ");
                if (id != "")
                    datos.Comando.CommandText += "where s.idSede =" + id;
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Sede aux = new Sede();

                    aux.IdSede = (long)datos.lector["idSede"];
                    aux.NombreSede = (string)datos.lector["nombreSede"];
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

        public void AgregarMedico(Sede nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {

                    Datos.SetearQuery("INSERT INTO Sede ( nombreSede ) VALUES ( @Nombre )");


                    Datos.setearParametros("@Nombre", nuevo.NombreSede);


                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Modificar(Sede nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearQuery("UPDATE Sede SET nombreSede = @nombre WHERE idSede = @sede");

                Datos.setearParametros("@nombre", nuevo.NombreSede);
               
                Datos.setearParametros("@sede", nuevo.IdSede);
               
                Datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void bajaFisica(int idSede)
        {
            AccesoDatos datos = new AccesoDatos();
          

            try
            {
                
                datos.SetearQuery("delete from Sede where idSede = @legajo");
                datos.setearParametros("@legajo", idSede);
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
