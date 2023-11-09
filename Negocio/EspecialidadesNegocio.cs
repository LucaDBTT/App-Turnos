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

            public List<Especialidad> ListarEspecialidades()
            {
                List<Especialidad> Lista = new List<Especialidad>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.SetearProcedimiento("SP_Especialidades");
                    datos.EjecutarLectura();

                    while (datos.lector.Read())
                    {
                        Especialidad aux = new Especialidad();

                        aux.Id = (long)datos.lector["idEspecialidad"];
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

    }
}
