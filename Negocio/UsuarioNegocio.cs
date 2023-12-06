using System;
using System.Collections.Generic;
using System.Data;
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
                datos.SetearQuery("SELECT u.idUsuario,u.dni,u.mail,u.tipoUsuario,COALESCE(p.nombre, m.nombre, a.nombre) AS Nombre,COALESCE(p.apellido, m.apellido, a.apellido) AS Apellido, tp.nombreTipoUsuario FROM Usuarios u LEFT JOIN Pacientes p ON u.idPaciente = p.idPaciente LEFT JOIN Profesionales m ON u.idProfesional = m.legajo LEFT JOIN Administrador a ON u.idAdministrador = a.idAdministrador INNER JOIN TiposUsuario tp ON tp.idTipoUsuario = u.tipoUsuario where u.estado = 1");

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (long)datos.lector["idUsuario"];
                    aux.dni = (long)datos.lector["dni"];
                    aux.Mail = (string)datos.lector["mail"];
                    aux.TipoUsuario = (int)datos.lector["tipoUsuario"];
                    aux.TipoUsuarioNombre = (string)datos.lector["nombreTipoUsuario"];

                    // Dependiendo del tipo de usuario, asignar los datos correspondientes
                    switch (aux.TipoUsuario)
                    {
                        case 1: // Paciente
                            aux.Nombre = datos.lector["Nombre"] != DBNull.Value ? (string)datos.lector["Nombre"] : string.Empty;
                            aux.Apellido = datos.lector["Apellido"] != DBNull.Value ? (string)datos.lector["Apellido"] : string.Empty;
                            break;

                        case 2: // Administrador
                            aux.Nombre = datos.lector["Nombre"] != DBNull.Value ? (string)datos.lector["Nombre"] : string.Empty;
                            aux.Apellido = datos.lector["Apellido"] != DBNull.Value ? (string)datos.lector["Apellido"] : string.Empty;
                            break;

                        case 3: // Profesional
                            aux.Nombre = datos.lector["Nombre"] != DBNull.Value ? (string)datos.lector["Nombre"] : string.Empty;
                            aux.Apellido = datos.lector["Apellido"] != DBNull.Value ? (string)datos.lector["Apellido"] : string.Empty;
                            break;

                        // Puedes agregar más casos según sea necesario

                        default:
                            break;
                    }

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
                    Datos.SetearQuery("INSERT INTO Pacientes (dni, apellido, nombre, fechaNac, idCobertura, nroAfiliado, telefono, estado) VALUES (@Dni, @Apellido, @Nombre, @FechaNac, @IdCobertura, @NroAfiliado, @Telefono, @Estado)");

                    Datos.setearParametros("@Dni", nuevo.dni);
                    Datos.setearParametros("@Apellido", nuevo.Apellido);
                    Datos.setearParametros("@Nombre", nuevo.Nombre);
                    Datos.setearParametros("@FechaNac", nuevo.FechaNacimiento);
                    Datos.setearParametros("@IdCobertura", nuevo.Cobertura.idCobertura);
                    Datos.setearParametros("@NroAfiliado", nuevo.NroAfiliado);
                    Datos.setearParametros("@Telefono", nuevo.Telefono);

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
                datos.SetearQuery("UPDATE Pacientes SET apellido = @apellido, nombre = @nombre, fechaNac = @fechaNac, idCobertura = @idCobertura, nroAfiliado = @nroAfiliado, telefono = @telefono, estado = @estado WHERE dni = @dni");

                datos.setearParametros("@apellido", nuevo.Apellido);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@fechaNac", nuevo.FechaNacimiento);
                datos.setearParametros("@idCobertura", nuevo.Cobertura.idCobertura);
                datos.setearParametros("@nroAfiliado", nuevo.NroAfiliado);
                datos.setearParametros("@telefono", nuevo.Telefono);

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

        public long ObtenerUltimoIdPaciente()
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    Datos.SetearQuery("SELECT MAX(idPaciente) FROM Pacientes");

                    Datos.EjecutarLectura();

                    if (Datos.lector.Read())
                    {
                        long ultimoId = Convert.ToInt64(Datos.lector[0]);
                        return ultimoId;
                    }

                    return -1; // Retorna -1 si no hay registros en la tabla Pacientes
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    }

    
