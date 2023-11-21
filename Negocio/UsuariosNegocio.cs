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
                datos.SetearQuery("select idUsuario,tipoUsuario from Usuarios where Usuario = @User and pass= @Pass");
                datos.setearParametros("@User", usuario.User);
                datos.setearParametros("@Pass", usuario.Pass);

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)(long)datos.Lector["idUsuario"];
                    usuario.TipoUsuario = (int)(datos.Lector["tipoUsuario"])== 2 ? TipoUsuarios.ADMIN :TipoUsuarios.NORMAL;
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



    }
}
