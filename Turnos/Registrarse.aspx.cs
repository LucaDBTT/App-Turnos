using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configuración para agregar
                CoberturasNegocio coberturasNegocio = new CoberturasNegocio();
                ddlCoberturas.DataSource = coberturasNegocio.ListarCoberturas();
                ddlCoberturas.DataTextField = "Nombre";
                ddlCoberturas.DataValueField = "IdCobertura";
                ddlCoberturas.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Verificar si los campos obligatorios están llenos
                if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtFechaNacimiento.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || ddlCoberturas.SelectedIndex == 0 || string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtCorreo.Text))
                {
                    lblMensajeError.Text = "Por favor completa todos los campos obligatorios antes de continuar...";
                    return;
                }

                // Validar que el DNI sea numérico
                if (!long.TryParse(txtDni.Text, out _))
                {
                    lblMensajeError.Text = "El DNI debe contener solo números.";
                    return;
                }

                // Validar que la fecha de nacimiento no sea la fecha actual
                if (DateTime.TryParseExact(txtFechaNacimiento.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento))
                {
                    if (fechaNacimiento.Date == DateTime.Today)
                    {
                        lblMensajeError.Text = "La fecha de nacimiento no puede ser la fecha actual.";
                        return;
                    }
                }
                else
                {
                    lblMensajeError.Text = "Formato de fecha de nacimiento no válido.";
                    return;
                }

                if (datos.ExisteCorreo(txtCorreo.Text))
                {
                    lblMensajeError.Text = "Este correo electrónico ya está asociado a un usuario.";
                    return;
                }
                if (datos.ExisteDni(txtDni.Text))
                {
                    lblMensajeError.Text = "El DNI ingresado ya está registrado para otro paciente.";
                    return;
                }



                // Continuar con el resto del código para guardar los datos del paciente
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                ServicioEmail emailService = new ServicioEmail();
                usuarios nuevo = new usuarios(txtCorreo.Text, txtContraseña.Text, usuario.dni, false, false, false);
                UsuariosNegocio negocio = new UsuariosNegocio();

                // Obtener valores de los controles en el formulario
                usuario.dni = long.Parse(txtDni.Text);
                usuario.FechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                // Instanciar un objeto Cobertura y asignar su Id
                usuario.Cobertura = new Cobertura();
                usuario.Cobertura.idCobertura = long.Parse(ddlCoberturas.SelectedValue);

                usuario.Contrasena = txtContraseña.Text;
                usuario.Mail = txtCorreo.Text;
                usuario.Estado = true;
                if (long.TryParse(txtNumeroAfiliado.Text, out long numeroAfiliado))
                {
                    usuario.NroAfiliado = numeroAfiliado;  // Nuevo campo NumeroAfiliado
                }

                // Convertir a tipo numérico si es necesario
                if (long.TryParse(txtTelefono.Text, out long telefono))
                {
                    usuario.Telefono = telefono;  // Nuevo campo Telefono
                }

                usuarioNegocio.AgregarUsuario(usuario);

                nuevo.Mail = txtCorreo.Text;
                nuevo.Pass = txtContraseña.Text;
                nuevo.dni = usuario.dni;
                nuevo.IdEntidad = usuarioNegocio.ObtenerUltimoIdPaciente();
                negocio.RegistrarUsuarios(nuevo);
                emailService.armarCorreo(nuevo.Mail, "Bienvenid@ a JPSalud", "Hola" + usuario.Nombre + "nos complacete tenerte como usuario");
                emailService.enviarMail();

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}