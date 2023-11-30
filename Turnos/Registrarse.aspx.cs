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
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                ServicioEmail emailService = new ServicioEmail();
                usuarios nuevo = new usuarios(txtCorreo.Text,txtContraseña.Text,usuario.dni,false,false,false);
                UsuariosNegocio negocio = new UsuariosNegocio();


                // Obtener valores de los controles en el formulario
                usuario.dni = long.Parse(txtDni.Text);
                usuario.FechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                // Instanciar un objeto Cobertura y asignar su Id
                usuario.Cobertura = new Coberturas();
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

                nuevo.Mail= txtCorreo.Text;
                nuevo.Pass = txtContraseña.Text;
                nuevo.TipoUsuario = TipoUsuarios.paciente;
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