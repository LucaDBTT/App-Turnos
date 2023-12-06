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
                datos.SetearQuery("SELECT c.idCobertura, c.nombreCobertura FROM Coberturas c");

                if (!string.IsNullOrEmpty(id))
                {
                    datos.Comando.CommandText += " AND c.nombreCobertura = @Id";
                    datos.setearParametros("@Id", Convert.ToInt32(id));
                }

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Coberturas aux = new Coberturas();

                    aux.idCobertura = (long)datos.lector["idCobertura"];
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

        public long AgregarCobertura(Coberturas nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("INSERT INTO Coberturas (nombreCobertura, estado) VALUES (@Nombre, 1); SELECT SCOPE_IDENTITY();");

                    Datos.setearParametros("@Nombre", nuevo.Nombre);



                    long legajo = Convert.ToInt64(Datos.ejecutarScalar());

                    // Asignar el ID generado al objeto Medico
                    nuevo.idCobertura= legajo;

                    return legajo;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void bajaLogica(int cobertura)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {


                datos.SetearQuery("update Coberturas set estado=0 where idCobertura = @cobertura");
                datos.setearParametros("@cobertura", cobertura);
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

        public void Modificar(Coberturas nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearQuery("UPDATE Coberturas SET nombreCobertura = @nombre WHERE idCobertura = @cobertura");

                Datos.setearParametros("@nombre", nuevo.Nombre);

                Datos.setearParametros("@cobertura", nuevo.idCobertura);

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
    }
}
