using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuariosNegocio
    {
        public bool loguear (usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("select idUsuario,tipoUsuario, mail, dni from Usuarios where mail = @User and pass= @Pass");
                datos.setearParametros("@User", usuario.User);
                datos.setearParametros("@Pass", usuario.Pass);
                



                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)(long)datos.Lector["idUsuario"];
                    usuario.User = (string)datos.Lector["mail"];
                    usuario.dni = (long)datos.Lector["dni"]; 
                    
                    usuario.TipoUsuario = (int)(datos.Lector["tipoUsuario"]) == 1
                     ? TipoUsuarios.paciente
    :                (int)(datos.Lector["tipoUsuario"]) == 2
                     ? TipoUsuarios.admin
                     : TipoUsuarios.medico;
                     return true;

                }
                return false; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void RegistrarUsuarios (usuarios nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("insert into Usuarios (idProfesional,dni, mail, pass, tipoUsuario) values (@IdEntidad, @dni, @mail,@pass, @tipoUsuario) ");

                    Datos.setearParametros("@dni", nuevo.dni);
                    Datos.setearParametros("@mail", nuevo.User);
                    Datos.setearParametros("@pass", nuevo.Pass);
                    Datos.setearParametros("@tipoUsuario", nuevo.TipoUsuario);
                    Datos.setearParametros("@IdEntidad", nuevo.IdEntidad);

                    Datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



    }
}
