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
    public partial class UserDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] != null && ((Dominio.usuarios)Session["Usuario"]).TipoUsuario == Dominio.TipoUsuarios.admin))
            {
                Session.Add("Error", "no eres usuario");
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}