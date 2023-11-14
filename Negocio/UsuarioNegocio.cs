using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> ListarUsuarios(string dni = "")
        {
            List<Usuario> Lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("SELECT u.idUsuario, u.dni, u.apellido, u.nombre, u.fechaNac, u.idCobertura, u.nroAfiliado, u.telefono, u.mail, u.contraseña, u.estado, c.nombreCobertura FROM Usuarios u INNER JOIN Coberturas c ON u.idCobertura = c.idCobertura WHERE u.estado = 1");

                if (!string.IsNullOrEmpty(dni))
                    datos.Comando.CommandText += " AND u.dni = " + dni;

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (long)datos.lector["idUsuario"];
                    aux.dni = (long)datos.lector["dni"];
                    aux.Apellido = (string)datos.lector["apellido"];
                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.FechaNacimiento = (DateTime)datos.lector["fechaNac"];
                    aux.Cobertura = new Coberturas
                    {
                        idCobertura = (long)datos.lector["idCobertura"],
                        Nombre = (string)datos.lector["nombreCobertura"]
                    };
                    aux.NroAfiliado = (long)datos.lector["nroAfiliado"];
                    aux.Telefono = (long)datos.lector["telefono"];
                    aux.Mail = (string)datos.lector["mail"];
                    aux.Contrasena = (string)datos.lector["contraseña"];
                    aux.Estado = (bool)datos.lector["estado"];

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

        public void AgregarUsuario(Usuario nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("INSERT INTO Usuarios (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, mail, contraseña, estado) VALUES (@Dni, @Apellido, @Nombre, @FechaNac, @IdCobertura, @NroAfiliado, @Telefono, @Mail, @Contraseña, @Estado)");

                    Datos.setearParametros("@Dni", nuevo.dni);
                    Datos.setearParametros("@Apellido", nuevo.Apellido);
                    Datos.setearParametros("@Nombre", nuevo.Nombre);
                    Datos.setearParametros("@FechaNac", nuevo.FechaNacimiento);
                    Datos.setearParametros("@IdCobertura", nuevo.Cobertura.idCobertura);
                    Datos.setearParametros("@NroAfiliado", nuevo.NroAfiliado);
                    Datos.setearParametros("@Telefono", nuevo.Telefono);
                    Datos.setearParametros("@Mail", nuevo.Mail);
                    Datos.setearParametros("@Contraseña", nuevo.Contrasena);
                    Datos.setearParametros("@Estado", nuevo.Estado);

                    Datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE Usuarios SET apellido = @apellido, nombre = @nombre, fechaNac = @fechaNac, idCobertura = @idCobertura, nroAfiliado = @nroAfiliado, telefono = @telefono, mail = @mail, contraseña = @contraseña, estado = @estado WHERE dni = @dni");

                datos.setearParametros("@apellido", nuevo.Apellido);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@fechaNac", nuevo.FechaNacimiento);
                datos.setearParametros("@idCobertura", nuevo.Cobertura.idCobertura);
                datos.setearParametros("@nroAfiliado", nuevo.NroAfiliado);
                datos.setearParametros("@telefono", nuevo.Telefono);
                datos.setearParametros("@mail", nuevo.Mail);
                datos.setearParametros("@contraseña", nuevo.Contrasena);
                datos.setearParametros("@estado", nuevo.Estado);
                datos.setearParametros("@dni", nuevo.dni);

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

        public void BajaLogica(long dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE Usuarios SET estado = 0 WHERE dni = @dni");
                datos.setearParametros("@dni", dni);
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

    
