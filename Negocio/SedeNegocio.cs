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
        public List<Sede> ListarSedes(string id = "")
        {
            List<Sede> Lista = new List<Sede>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("SELECT s.idSede, s.nombreSede FROM Sede s WHERE s.estado = 1");

                if (!string.IsNullOrEmpty(id))
                {
                    datos.Comando.CommandText += " AND s.idSede = @Id";
                    datos.setearParametros("@Id", Convert.ToInt32(id));
                }

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


        public long AgregarSede(Sede nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("INSERT INTO Sede (nombreSede, estado) VALUES (@Nombre, 1); SELECT SCOPE_IDENTITY();");

                    Datos.setearParametros("@Nombre", nuevo.NombreSede);

                   
                    
                    long legajo = Convert.ToInt64(Datos.ejecutarScalar());

                    // Asignar el ID generado al objeto Medico
                    nuevo.IdSede = legajo;

                    return legajo;
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
                Datos.SetearQuery("UPDATE Sedes SET nombreSede = @nombre WHERE idSede = @sede");

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

        public void bajaLogica(int sede)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {


                datos.SetearQuery("update Sede set estado=0 where idSede = @idSede");
                datos.setearParametros("@idSede", sede);
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
