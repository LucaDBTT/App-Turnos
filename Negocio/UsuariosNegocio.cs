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
                datos.SetearQuery("select idUsuario,tipoUsuario from Usuarios where Usuario = @user and pass=@pass");
                datos.setearParametros("@user", usuario.User);
                datos.setearParametros("@pass", usuario.Pass);

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.lector["idUsuario"];
                    usuario.TipoUsuario = (int)(datos.lector["tipoUsuario"])== 2 ? TipoUsuarios.ADMIN :TipoUsuarios.NORMAL  ;
                    return true;

                }
                return false; 
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
