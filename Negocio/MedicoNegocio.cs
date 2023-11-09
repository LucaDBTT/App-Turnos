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
    public class MedicoNegocio
    {
        public List<Medico> ListarMedicos(string legajo="")
        {
            List<Medico> Lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
           
            try
            {

                datos.SetearQuery("select p.legajo, p.apellido, p.nombre,e.idEspecialidad, e.nombreEspecialidad,s.idSede, s.nombreSede, p.Contraseña,p.estado from Profesionales p  inner join Especialidades e on e.idEspecialidad = p.idEspecialidad inner join Sede s on s.idSede = p.idSede where p.estado=1 ");
                if (legajo != "")
                    datos.Comando.CommandText += "and p.legajo=" + legajo;
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    Medico aux = new Medico();

                    aux.Legajo = (long)datos.lector["legajo"];
                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.Apellido = (string)datos.lector["apellido"];
                    aux.Sede = new Sede();
                    aux.Sede.NombreSede = (string)datos.lector["nombreSede"];
                    aux.Sede.IdSede = (long)datos.lector["idSede"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Nombre = (string)datos.lector["nombreEspecialidad"];
                    aux.Especialidad.Id = (long)datos.lector["idEspecialidad"];
                    aux.Estado = (bool)datos.lector["estado"];
                    aux.Contraseña = (string)datos.lector["Contraseña"];
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

                    Datos.SetearQuery("INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, contraseña, estado) VALUES ( @Nombre, @Apellido, @IdEspecialidad, @IdSede, @Contraseña, @Estado)");

                   
                    Datos.setearParametros("@Nombre", nuevo.Nombre);
                    Datos.setearParametros("@Apellido", nuevo.Apellido);
                    Datos.setearParametros("@IdEspecialidad", nuevo.Especialidad.Id);
                    Datos.setearParametros("@IdSede", nuevo.Sede.IdSede);
                    Datos.setearParametros("@Contraseña", nuevo.Contraseña);
                    Datos.setearParametros("@Estado", nuevo.Estado);

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
                Datos.setearParametros("@idSede", nuevo.Sede.IdSede);
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
                
                    datos.SetearQuery("delete from Profesionales where legajo = @legajo");
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




        public void bajaLogica(int legajo)
        {
            AccesoDatos datos = new AccesoDatos();
           

            try
            {
                

                datos.SetearQuery("update Profesionales set estado=0 where legajo =@legajo");
                datos.setearParametros("@legajo", legajo);
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

