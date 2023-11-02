using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    class MedicoNegocio
    {
        public List<Medico> ListarMedicos()
        {
            List<Medico> Lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearQuery("select p.legajo ,p.apellido, p.nombre, e.nombreEspecialidad , s.nombreSede\r\nfrom Profesionales p\r\ninner join Especialidades e on e.idEspecialidad = p.idEspecialidad\r\ninner join Sede s on s.idSede = p.idSede");
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    Medico aux = new Medico();

                    aux.Legajo = (int)datos.lector["legajo"];
                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.Apellido = (string)datos.lector["apellido"];
                    aux.Sede = new Sede();
                    aux.Sede.NombreSede = (string)datos.lector["nombreSede"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Nombre = (string)datos.lector["nombreEspecialidad"];
                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}