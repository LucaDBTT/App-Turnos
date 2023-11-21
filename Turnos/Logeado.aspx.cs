using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Turnos
{
    public partial class Logeado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "debes loguearte...");
                Response.Redirect("Login.aspx", false);
            }
            MostrarBotonesSegunRol();
        }

        private void MostrarBotonesSegunRol()
        {
            // Verificar el rol del usuario y mostrar u ocultar los botones según sea necesario
            if (EsAdministrador())
            {
                Admin.Visible = false;
                User.Visible = true;
            }
            else if (EsUsuario())
            {
                User.Visible = false;
                Admin.Visible = true;
            }
        }

        private bool EsAdministrador()
        {
            // Verifica si la sesión contiene un usuario y si ese usuario es un administrador
            return Session["Usuario"] != null && ((Dominio.usuarios)Session["Usuario"]).TipoUsuario == Dominio.TipoUsuarios.ADMIN;
        }

        private bool EsUsuario()
        {
            // Verifica si la sesión contiene un usuario y si ese usuario es un usuario regular
            return Session["Usuario"] != null && ((Dominio.usuarios)Session["Usuario"]).TipoUsuario == Dominio.TipoUsuarios.NORMAL;
        }
        protected void User_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDefault.aspx", false);
        }

        protected void Admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }


    }
}