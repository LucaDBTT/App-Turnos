using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class WebMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el usuario de la sesión
            if (Session["Usuario"] is Dominio.usuarios usuario)
            {
                // Mostrar u ocultar elementos según el tipo de usuario
                switch (usuario.TipoUsuario)
                {
                    case Dominio.TipoUsuarios.admin:
                        MostrarHeaderAdmin();
                        break;
                    case Dominio.TipoUsuarios.paciente:
                        MostrarHeaderUsuario();
                        break;
                    case Dominio.TipoUsuarios.medico:
                        MostrarHeaderMedico();
                        break;
                    default:
                        OcultarTodosLosHeaders();
                        break;
                }

                // Mostrar el nombre de usuario en la barra de navegación
                MostrarNombreUsuario(usuario.User);
            }
            else
            {
                // Lógica para manejar el caso cuando el usuario no está en sesión
                OcultarTodosLosHeaders();
            }
        }

        private void MostrarNombreUsuario(string nombre)
        {
            // Asignar el nombre de usuario al elemento HTML
            spanNombreUsuario.InnerText =nombre + " ";
            spanNombreMedico.InnerText = nombre +" ";
            spanNombreAdmin.InnerText = "Administrador" + " ";
        }

        private void MostrarHeaderAdmin()
        {
            headerAdmin.Visible = true;
            headerUser.Visible = false;
            headerMedico.Visible = false;
        }

        private void MostrarHeaderUsuario()
        {
            headerAdmin.Visible = false;
            headerUser.Visible = true;
            headerMedico.Visible = false;
        }

        private void MostrarHeaderMedico()
        {
            headerAdmin.Visible = false;
            headerUser.Visible = false;
            headerMedico.Visible = true;
        }

        private void OcultarTodosLosHeaders()
        {
            headerAdmin.Visible = false;
            headerUser.Visible = false;
            headerMedico.Visible = false;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión y redirigir a la página de inicio o login
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/Login.aspx"); // Cambia esto a la página que desees después del logout
        }
    }
}