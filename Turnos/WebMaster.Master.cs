using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class WebMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el usuario de la sesión
            if (Session["Usuario"] is Dominio.usuarios usuario)
            {
                // Verificar si el usuario es administrador
                bool esAdmin = usuario.TipoUsuario == Dominio.TipoUsuarios.admin;

                // Mostrar u ocultar elementos según el tipo de usuario
                headerAdmin.Visible = esAdmin;
                headerUser.Visible = !esAdmin;
            }
            else
            {
                // Lógica para manejar el caso cuando el usuario no está en sesión
                headerAdmin.Visible = false;
                headerUser.Visible = false;
            }

        }
    }
}