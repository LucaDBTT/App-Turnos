using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Dominio;

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


        public void AgregarMedico(Medico nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("insert into Profesionales (nombre, apellido, idEspecialidad,idSede,contraseña, estado) VALUES ('" + nuevo.Nombre + "','" + nuevo.Apellido + "',,'" + nuevo.Especialidad.Id + "','" + nuevo.Sede.ídSede + "',,'" + nuevo.Contraseña + "', '" + nuevo.Estado + "')");
                    
                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Modificar(Medico nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            
            try
            {
                Datos.SetearQuery("UPDATE PROFESIONALES SET nombre = @Nombre, apellido = @apellido, idEspecialidad = @idEspecialidad,idSede = @idSede,contraseña = @contraseña, estado = @estado WHERE legajo = @legajo");
                
                Datos.setearParametros("@nombre", nuevo.Nombre);
                Datos.setearParametros("@apellido", nuevo.Apellido);
                Datos.setearParametros("@idEspecialidad", nuevo.Especialidad.Id);
                Datos.setearParametros("@idSede", nuevo.Sede.ídSede);
                Datos.setearParametros("@contraseña", nuevo.Contraseña);
                Datos.setearParametros("@legajo", nuevo.Legajo);
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

        public void bajaFisica(int legajo)
        {
            AccesoDatos datos = new AccesoDatos();
           // DialogResult dialogo = MessageBox.Show("Esta seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                //if (dialogo == DialogResult.Yes)
                
                    datos.SetearQuery("delete from PROFECIONALES where legajo = @legajo");
                    datos.setearParametros("@legajo", legajo);
                    datos.ejecutarAccion();
                   // MessageBox.Show("Articulo eliminado con exito");

                
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

