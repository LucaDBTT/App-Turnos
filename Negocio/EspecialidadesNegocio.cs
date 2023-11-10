using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EspecialidadesNegocio
    {

            public List<Especialidad> ListarEspecialidades(string id = "")
            {
                List<Especialidad> Lista = new List<Especialidad>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                datos.SetearQuery("select e.idEspecialidad , e.nombreEspecialidad   from Especialidades e ");
                if (id != "")
                    datos.Comando.CommandText += "where e.idEspecialidad =" + id;
                datos.EjecutarLectura();

                while (datos.lector.Read())
                    {
                        Especialidad aux = new Especialidad();

                        aux.id = (long)datos.lector["idEspecialidad"];
                        aux.Nombre = (string)datos.lector["nombreEspecialidad"];
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

        public void AgregarEspecialidad(Especialidad nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {

                    Datos.SetearQuery("INSERT INTO Especialidades  ( nombreEspecialidad ) VALUES ( @Nombre )");


                    Datos.setearParametros("@Nombre", nuevo.Nombre);


                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Modificar(Especialidad nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearQuery("UPDATE Especialidades SET nombreEspecialidad = @nombre WHERE idEspecialidad = @id");

                Datos.setearParametros("@nombre", nuevo.Nombre);

                Datos.setearParametros("@id", nuevo.id);

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

        public void bajaFisica(int id)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.SetearQuery("delete from Especialidades where idEspecialidad = @id");
                datos.setearParametros("@id", id);
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
