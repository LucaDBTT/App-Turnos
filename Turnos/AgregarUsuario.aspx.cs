using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Dominio;
using Negocio;

namespace Turnos
{
    public partial class AgregarUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dni1 = Request.QueryString["dni"];
            if (!IsPostBack)
            {
                // Configuración para agregar
                CoberturasNegocio coberturasNegocio = new CoberturasNegocio();
                ddlCoberturas.DataSource = coberturasNegocio.ListarCoberturas();
                ddlCoberturas.DataTextField = "Nombre";
                ddlCoberturas.DataValueField = "IdCobertura";
                ddlCoberturas.DataBind();



            }

            // Configuración para modificar
            string dni = Request.QueryString["dni"] != null ? Request.QueryString["dni"].ToString() : "";
            if (dni != "" && !IsPostBack) { 
                     UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario seleccionado = new Usuario();
                    seleccionado = (negocio.ListarUsuarios(dni))[0];

                    // Precargamos los datos
                    txtDni.Text = seleccionado.dni.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtNumeroAfiliado.Text = seleccionado.NroAfiliado.ToString();  // Asegúrate de tener la propiedad NroAfiliado en tu clase Usuario
                    ddlCoberturas.SelectedValue = seleccionado.Cobertura.idCobertura.ToString();
                    txtCorreo.Text = seleccionado.Mail;  // Asegúrate de tener la propiedad Mail en tu clase Usuario
                    txtTelefono.Text = seleccionado.Telefono.ToString();  // Asegúrate de tener la propiedad Telefono en tu clase Usuario
                    txtContraseña.Attributes["value"] = seleccionado.Contrasena;
                
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

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

                // Agregar o modificar según sea necesario
                if (!string.IsNullOrEmpty(Request.QueryString["dni"]))
                {
                    string dni = Request.QueryString["dni"];
                    usuario.dni = long.TryParse(dni, out long dniComoLong) ? dniComoLong : 0;
                    usuarioNegocio.Modificar(usuario);
                }
                else
                {
                    usuarioNegocio.AgregarUsuario(usuario);
                }

                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
}